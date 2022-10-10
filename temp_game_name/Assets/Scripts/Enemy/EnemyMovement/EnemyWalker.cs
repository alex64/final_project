using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalker : EnemyGeneralMovement
{
    [SerializeField]
    [Range(1f, 10f)]
    private float runDelay = 2f;

    [SerializeField]
    [Range(-50f, 0)]
    private float minMovRange = -50f;
    [SerializeField]
    [Range(0, 50f)]
    private float maxMovRange = 50f;

    private float moveX = 0f;
    private float moveZ = 0f;
    private Vector3 moveDirection;
    private bool isMoving = false;
    
    
    

    // Start is called before the first frame update
    protected override void Start()
    {  
        base.Start();
        DamageAnimation = "damageTriggerWalker";
        IdleAnimation = "idleTriggerWalker";
    }

    // Update is called once per frame
    void Update()
    {
        //Invoke("RotateMovement",runDelay);
        Invoke("WalkerMovement",runDelay);
    }

    /*protected override void FixedUpdate()
    {
        base.FixedUpdate();
        Invoke("WalkerMovement",runDelay);
    }*/

    private Vector3 randomDirection()
    {
        moveX = Random.Range(minMovRange, maxMovRange);
        moveZ = Random.Range(minMovRange, maxMovRange);
        return new Vector3(moveX, 0, moveZ);
    }

    /*private void WalkerMovement()
    {
        if(!isMoving) 
        {
            moveDirection = randomDirection();
            Debug.Log(moveDirection);
            isMoving = true;
            IsRotating = true;
        }
        if(!IsRotating) 
        { 
            Vector3 diffMovement = transform.position - moveDirection;
            //MoveTranslation(diffMovement);
            //MoveForce(diffMovement);
            MoveForce(moveDirection);
            if(diffMovement.magnitude < 1) {
                Debug.Log("Reached destination");
                isMoving = false;
                EnemyAnimator.SetTrigger("idleTriggerWalker");
            }
        }
    }

    private void RotateMovement()
    {
        if(IsRotating)
        {
            Rotate(moveDirection);
        }
        
    }*/

    private void WalkerMovement()
    {
        if(!isMoving) 
        {
            moveDirection = randomDirection();
            Debug.Log(moveDirection);
            isMoving = true;
            IsRotating = true;
        }
        if(IsRotating) 
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
                EnemyAnimator.SetTrigger("idleTriggerWalker");
            }
            
        }
        
        
    }
}
