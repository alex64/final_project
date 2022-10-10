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
    [Range(1f, 2000f)]
    private float damangeForce = 3f;

    [SerializeField] 
    private Animator enemyAnimator;
    protected Animator EnemyAnimator { get => enemyAnimator; set => enemyAnimator = value; }

    [SerializeField]
    private Transform playerTransform;
    protected Transform PlayerTransform { get => playerTransform; set => playerTransform = value; }
    

    private string damageAnimation;
    protected string DamageAnimation { get => damageAnimation; set => damageAnimation = value; }

    private string idleAnimation;
    protected string IdleAnimation { get => idleAnimation; set => idleAnimation = value; }

    private Rigidbody enemyRB;
    private bool isDamaged = false;

    private bool isRotating = false;
    protected bool IsRotating { get => isRotating; set => isRotating = value; }
    
    // Start is called before the first frame update
    protected virtual void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
    }

    protected virtual void FixedUpdate() {
        if(isDamaged) 
        {
            EnemyAnimator.SetTrigger(DamageAnimation);
            Vector3 chaseDirection = transform.position - PlayerTransform.position;
            enemyRB.AddForce(transform.TransformDirection(chaseDirection.normalized) * movementForce, ForceMode.Force);
            isDamaged = false;
            EnemyAnimator.SetTrigger(IdleAnimation);
        }
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
            EnemyAnimator.SetTrigger("movingTriggerWalker");
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
    }
}
