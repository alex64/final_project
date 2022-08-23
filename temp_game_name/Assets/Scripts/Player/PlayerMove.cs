using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 2f;

    [SerializeField] 
    private Animator playerAnimator;

    private Dictionary<KeyCode, Vector3> movementList = new Dictionary<KeyCode, Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        movementList.Add(KeyCode.W, Vector3.forward);
        movementList.Add(KeyCode.A, Vector3.left);
        movementList.Add(KeyCode.S, Vector3.back);
        movementList.Add(KeyCode.D, Vector3.right);
    }

    // Update is called once per frame
    void Update()
    {
        bool triggerIdle = false;
        bool isMoving = false;
        foreach(KeyValuePair<KeyCode, Vector3> movement in movementList) 
        {
            if(Input.GetKeyDown(movement.Key)) 
            {
                isMoving = true;
                TriggerAnimation("Moving_Trigger");
                int rotateDirection = movement.Value.Equals(Vector3.left)?-1:movement.Value.Equals(Vector3.right)?1:0;
                RotatePlayer(rotateDirection);
            }
            if(Input.GetKeyUp(movement.Key))
            {
                triggerIdle = true;
            }
            if(Input.GetKey(movement.Key)) 
            {
                isMoving = true;
                bool movementDirection = movement.Value.Equals(Vector3.back)||movement.Value.Equals(Vector3.forward)?true:false;
                if(movementDirection) 
                {
                    Movement(movement.Value);
                }
            }
        }
        if (!IsAnimation("Idle_Trigger") && triggerIdle && !isMoving)
        {
            TriggerAnimation("Idle_Trigger");
        }
    }

    private void TriggerAnimation(string animationName)
    {
        playerAnimator.SetTrigger(animationName);
    }

    private void Movement(Vector3 direction)
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void RotatePlayer(int rotateDirection) 
    {
        transform.eulerAngles += Vector3.up * rotateDirection * 90f;
    }

    private void RotatePlayer(Vector3 direction)
    {
        Quaternion newRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, 100f * Time.deltaTime);
        
    }

    private bool IsAnimation(string animName)
    {
        return playerAnimator.GetCurrentAnimatorStateInfo(0).IsName(animName);
    }
}
