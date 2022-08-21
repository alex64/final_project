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
    [Range(-1f, -50f)]
    private float minMovRange = -50f;
    [SerializeField]
    [Range(1f, 50f)]
    private float maxMovRange = 50f;

    [SerializeField] 
    private Animator enemyAnimator;

    //Walker Variables
    private float moveX = 0f;
    private float moveZ = 0f;
    private Vector3 moveDirection;
    private bool isMoving = false;
    private bool isRotating = false;

    //Runner Variables
    [SerializeField]
    private Transform playerTransform;

    enum EnemyType { Walker, Runner, Stalker };

    [SerializeField] EnemyType enemyType;

    // Start is called before the first frame update
    void Start()
    {
        switch (enemyType)
        {
            case EnemyType.Runner:
                enemyAnimator.SetTrigger("movingTriggerRunner");
                break;
            case EnemyType.Stalker:
                enemyAnimator.SetTrigger("movingTriggerRunner");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (enemyType)
        {
            case EnemyType.Walker:
                Invoke("WalkerMovement",runDelay);
                break;
            case EnemyType.Runner:
                ChasePlayer(false);
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
        Vector3 chaseDirection = playerTransform.position - transform.position;
        transform.position += chaseDirection.normalized * (isChasePlayer?1:-1) * speed * Time.deltaTime; 
    }

    private void LookPlayer(bool isChasePlayer)
    {
        Quaternion newRotation = isChasePlayer?Quaternion.LookRotation(playerTransform.position - transform.position):Quaternion.LookRotation(transform.position - playerTransform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, 2f * Time.deltaTime);
    }

    private bool isAnimationActive(string animName)
    {
        return enemyAnimator.GetCurrentAnimatorStateInfo(0).IsName(animName);
    }
}