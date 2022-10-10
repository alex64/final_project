using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneralMovement : MonoBehaviour
{
    [SerializeField]
    [Range(1f, 2f)]
    private float speed = 2f;

    [SerializeField]
    [Range(1f, 2000f)]
    private float movementForce = 3f;

    [SerializeField] 
    private Animator enemyAnimator;
    protected Animator EnemyAnimator { get => enemyAnimator; set => enemyAnimator = value; }

    [SerializeField]
    private Transform playerTransform;
    protected Transform PlayerTransform { get => playerTransform; set => playerTransform = value; }

    [SerializeField] 
    private List<Transform> raycastPointList;

    protected string lastAnimationTrigger;

    protected EnemyData enemyData;

    private string damageAnimation;
    protected string DamageAnimation { get => damageAnimation; set => damageAnimation = value; }

    private string idleAnimation;
    protected string IdleAnimation { get => idleAnimation; set => idleAnimation = value; }

    private string moveAnimation;
    protected string MoveAnimation { get => moveAnimation; set => moveAnimation = value; }

    private string attackAnimation;
    protected string AttackAnimation { get => attackAnimation; set => attackAnimation = value; }

    private Rigidbody enemyRB;
    private bool isDamaged = false;

    private bool isRotating = false;
    protected bool IsRotating { get => isRotating; set => isRotating = value; }
    
    // Start is called before the first frame update
    protected virtual void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        enemyData = GetComponent<EnemyData>();
    }

    protected virtual void FixedUpdate() {
        if(isDamaged) 
        {
            string lastTrigger = lastAnimationTrigger;
            SetAnimation(DamageAnimation);
            Vector3 chaseDirection = transform.position - PlayerTransform.position;
            enemyRB.AddForce(transform.TransformDirection(chaseDirection.normalized) * movementForce, ForceMode.Force);
            isDamaged = false;
            SetAnimation(lastTrigger);
        }

        EnemyRaycast();
    }

    public void MoveForce(Vector3 direction) 
    {

        Vector3 position =  Vector3.MoveTowards (enemyRB.position, direction, speed * Time.fixedDeltaTime);
        enemyRB.MovePosition(position);


        /*if (direction != Vector3.zero)// && enemyRB.velocity.magnitude < speed)
        {
            enemyRB.AddForce(transform.TransformDirection(direction) * movementForce, ForceMode.Force);
        }*/
    }

    public void MoveTranslation(Vector3 direction) 
    {
        transform.position += direction.normalized * speed * Time.deltaTime; 
    }

    public void Rotate(Vector3 direction)
    {
        Quaternion newRotation = Quaternion.LookRotation(direction - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, 1.5f * Time.deltaTime);
        if(Mathf.Abs(Quaternion.Dot(newRotation, transform.rotation)) > 0.99) {
            IsRotating = false;
            SetAnimation(MoveAnimation);
        }
        
    }

    public void ChasePlayer(bool isChasePlayer) 
    {
        LookPlayer(isChasePlayer);
        Vector3 chaseDirection = PlayerTransform.position - transform.position;
        transform.position += chaseDirection.normalized * (isChasePlayer?1:-1) * speed * Time.deltaTime; 
    }

    public void LookPlayer(bool isChasePlayer)
    {
        Quaternion newRotation = isChasePlayer?Quaternion.LookRotation(PlayerTransform.position - transform.position):Quaternion.LookRotation(transform.position - PlayerTransform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, 2f * Time.deltaTime);
    }

    public bool isAnimationActive(string animName)
    {
        return EnemyAnimator.GetCurrentAnimatorStateInfo(0).IsName(animName);
    }

    public void DamageMovement() {
        isDamaged = true;
        DamageAction();
    }

    protected virtual void DamageAction()
    {
        //Empty for inheritance
    }

    private void EnemyRaycast()
    {
        RaycastHit hit;
        foreach(Transform raycastPoint in raycastPointList) 
        {
            if (Physics.Raycast(raycastPoint.position, raycastPoint.TransformDirection(Vector3.forward), out hit, enemyData.RayDistance))
            {
                if (hit.transform.CompareTag("Player"))
                {
                    Debug.Log("Spoted player");
                    SpotPlayerAction();
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        foreach(Transform raycastPoint in raycastPointList)
        {
            Gizmos.color = Color.blue;
            if(raycastPoint != null && enemyData != null) 
            {
                Vector3 direction = raycastPoint.TransformDirection(Vector3.forward) * enemyData.RayDistance;
                Gizmos.DrawRay(raycastPoint.position, direction);
            }  
        }
    }

    protected virtual void SpotPlayerAction()
    {
        //Empty for inheritance
    }

    protected void SetAnimation(string animationTrigger)
    {
        lastAnimationTrigger = animationTrigger;
        EnemyAnimator.SetTrigger(animationTrigger);
    }
}
