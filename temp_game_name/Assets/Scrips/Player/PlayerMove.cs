using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 2f;

    [SerializeField] 
    private Animator playerAnimator;

    private bool isMoving = false;

    private Dictionary<KeyCode, Vector3> movementList = new Dictionary<KeyCode, Vector3>();
    private Queue moveQueue = new Queue();

    // Start is called before the first frame update
    void Start()
    {
        movementList.Add(KeyCode.W, Vector3.forward);
        movementList.Add(KeyCode.S, Vector3.back);
        movementList.Add(KeyCode.A, Vector3.left);
        movementList.Add(KeyCode.D, Vector3.right);
    }

    // Update is called once per frame
    void Update()
    {
        foreach(KeyValuePair<KeyCode, Vector3> movement in movementList) 
        {
            if(Input.GetKeyDown(movement.Key)) 
            {
                playerAnimator.SetTrigger("Moving_Trigger");
            }
            if(Input.GetKeyUp(movement.Key))
            {
                if (!IsAnimation("Idle_Trigger"))
                //if(moveQueue.Count == 0)
                {
                    playerAnimator.SetTrigger("Idle_Trigger");
                }
            }
            if(Input.GetKey(movement.Key))
            {
                /*if(!IsAnimation("Moving_Trigger")) {
                    playerAnimator.SetTrigger("Moving_Trigger");
                }*/
                RotatePlayer(movement.Value);
                Movement(Vector3.forward);
            }
            
        }
    }

    private void Movement(Vector3 direction)
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    public void RotatePlayer(Vector3 direction)
    {
        Quaternion newRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, 2f * Time.deltaTime);
    }

    private bool IsAnimation(string animName)
    {
        return playerAnimator.GetCurrentAnimatorStateInfo(0).IsName(animName);
    }
}
