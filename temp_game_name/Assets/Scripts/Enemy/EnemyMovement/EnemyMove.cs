using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField]
    [Range(1f, 2f)]
    private float speed = 2f;

    [SerializeField]
    [Range(1f, 10f)]
    private float runDelay = 2f;

    [SerializeField]
    [Range(-50f, 0)]
    private float minMovRange = -50f;
    [SerializeField]
    [Range(0, 50f)]
    private float maxMovRange = 50f;

    [SerializeField]
    [Range(1f, 2000f)]
    private float movementForce = 3f;

    [SerializeField] 
    private Animator enemyAnimator;

    //Walker Variables
    private float moveX = 0f;
    private float moveZ = 0f;
    private Vector3 moveDirection;
    private bool isMoving = false;
    private bool isRotating = false;
    private Rigidbody enemyRB;
    private string damageAnimation;
    private string idleAnimation;

    //Runner Variables
    [SerializeField]
    private Transform playerTransform;

    public enum EnemyType { Walker, Runner, Stalker };

    [SerializeField] 
    private EnemyType enemyType;

    public Transform PlayerTransform { get => playerTransform; set => playerTransform = value; }

    public EnemyType EnemyType1 { get => enemyType; set => enemyType = value; }

    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();

        switch (EnemyType1)
        {
            case EnemyType.Runner:
                enemyAnimator.SetTrigger("movingTriggerRunner");
                damageAnimation = "damagedTriggerRunner";
                idleAnimation = "idleTriggerRunner";
                break;
            case EnemyType.Stalker:
                if(enemyAnimator!= null) {
                    enemyAnimator.SetTrigger("movingTriggerRunner");
                }
                break;
            case EnemyType.Walker:
                damageAnimation = "damageTriggerWalker";
                idleAnimation = "idleTriggerWalker";
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (EnemyType1)
        {
            case EnemyType.Walker:
                //Invoke("WalkerMovement",runDelay);
                break;
            case EnemyType.Runner:
                //ChasePlayer(false);
                break;
            case EnemyType.Stalker:
                ChasePlayer(true);
                break;
        }
    }

    private void WalkerMovement()
    {
        if(!isMoving) 
        {
            moveDirection = randomDirection();
            Debug.Log(moveDirection);
            isMoving = true;
            isRotating = true;
        }
        if(isRotating) 
        {
            Rotate(moveDirection);
        }
        else 
        {
            /*if(!isAnimationActive("movingTriggerWalker"))
            {
                enemyAnimator.SetTrigger("movingTriggerWalker");
            }*/
            
            Vector3 diffMovement = moveDirection - transform.position;
            MoveTranslation(diffMovement);
            if(diffMovement.magnitude < 1) {
                Debug.Log("Reached destination");
                isMoving = false;
                enemyAnimator.SetTrigger("idleTriggerWalker");
            }
            
        }
        
        
    }

    private void MoveTranslation(Vector3 direction) 
    {
        transform.position += direction.normalized * speed * Time.deltaTime; 
    }

    private Vector3 randomDirection()
    {
        moveX = Random.Range(minMovRange, maxMovRange);
        moveZ = Random.Range(minMovRange, maxMovRange);
        return new Vector3(moveX, 0, moveZ);
    }

    private void Rotate(Vector3 direction)
    {
        Quaternion newRotation = Quaternion.LookRotation(direction - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, 1.5f * Time.deltaTime);
        if(Mathf.Abs(Quaternion.Dot(newRotation, transform.rotation)) > 0.99) {
            isRotating = false;
            enemyAnimator.SetTrigger("movingTriggerWalker");
        }
        
    }

    private void ChasePlayer(bool isChasePlayer) 
    {
        LookPlayer(isChasePlayer);
        Vector3 chaseDirection = PlayerTransform.position - transform.position;
        transform.position += chaseDirection.normalized * (isChasePlayer?1:-1) * speed * Time.deltaTime; 
    }

    private void LookPlayer(bool isChasePlayer)
    {
        Quaternion newRotation = isChasePlayer?Quaternion.LookRotation(PlayerTransform.position - transform.position):Quaternion.LookRotation(transform.position - PlayerTransform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, 2f * Time.deltaTime);
    }

    private bool isAnimationActive(string animName)
    {
        return enemyAnimator.GetCurrentAnimatorStateInfo(0).IsName(animName);
    }

    private bool isDamaged = false;

    public void DamageMovement() {
        isDamaged = true;
    }
    
    private void FixedUpdate() {
        if(isDamaged) 
        {
            enemyAnimator.SetTrigger(damageAnimation);
            Vector3 chaseDirection = transform.position - PlayerTransform.position;
            enemyRB.AddForce(transform.TransformDirection(chaseDirection.normalized) * movementForce, ForceMode.Force);
            isDamaged = false;
            enemyAnimator.SetTrigger(idleAnimation);
        }
    }
}
