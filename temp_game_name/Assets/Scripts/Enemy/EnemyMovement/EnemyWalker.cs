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
    private Vector3 moveDirection = Vector3.zero;
    private Vector3 previousDirection = Vector3.zero;
    
    private bool isMoving = false;
    protected bool IsMoving { get => isMoving; set => isMoving = value; }

    private bool stopMoving = false;
    protected bool StopMoving { get => stopMoving; set => stopMoving = value; }


    // Start is called before the first frame update
    protected override void Start()
    {  
        base.Start();
        DamageAnimation = "damageTriggerWalker";
        IdleAnimation = "idleTriggerWalker";
        MoveAnimation = "movingTriggerWalker";
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if(!stopMoving)
        {
            //Invoke("WalkerMovement",runDelay);
            WalkerMovement();
        }
    }

    private Vector3 randomDirection()
    {
        moveX = Random.Range(minMovRange, maxMovRange);
        moveZ = Random.Range(minMovRange, maxMovRange);
        return new Vector3(moveX, 0, moveZ);
    }

    private void WalkerMovement()
    {
        if(!IsMoving) 
        {
            moveDirection = randomDirection();
            Debug.Log(moveDirection);
            IsMoving = true;
            IsRotating = true;
        }
        if(IsRotating) 
        {
            Rotate(moveDirection);
        }
        else 
        {   
            Vector3 diffMovement = moveDirection - transform.position;
            MoveTranslation(diffMovement);
            if(diffMovement.magnitude < 1) {
                Debug.Log("Reached destination");
                IsMoving = false;
                SetAnimation(IdleAnimation);
            }
            
        }
    }

    protected override void DamageAction()
    {
        IsMoving = false;
    }
}
