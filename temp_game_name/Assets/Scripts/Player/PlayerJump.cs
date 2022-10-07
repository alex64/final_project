using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : PlayerDefault
{

    [SerializeField]
    [Range(1f, 200f)]
    private float delayNextJump = 1f;

    [SerializeField]
    [Range(1f, 2000f)]
    private float jumpForce = 40f;

    private bool canJump = true;
    private bool inDelayJump = false;
    private Rigidbody playerRB;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            canJump = false;
            TriggerAnimation("Jump_Trigger");
        }
    }

    private void FixedUpdate() {
        if (!canJump && !inDelayJump)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Acceleration);
            inDelayJump = true;
            TriggerAnimation("Idle_Trigger");
            Invoke("DelayNextJump", delayNextJump);
        }
    }

    private void DelayNextJump()
    {
        inDelayJump = false;
        canJump = true;
    }
}
