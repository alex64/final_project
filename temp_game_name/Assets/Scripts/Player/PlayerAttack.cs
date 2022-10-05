using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private Animator playerAttackAnimator;

    private KeyCode attackCode = KeyCode.KeypadEnter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(attackCode)) 
        {
            TriggerAnimation("Attack_Trigger");
            Debug.Log("Attack Action");
        }
        if(Input.GetKeyUp(attackCode)) 
        {
            TriggerAnimation("Idle_Trigger");
        }
    }

    private void TriggerAnimation(string animationName)
    {
        playerAttackAnimator.SetTrigger(animationName);
    }
}
