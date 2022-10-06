using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private Animator playerAttackAnimator;

    private KeyCode attackCode = KeyCode.KeypadEnter;

    public static event Action<bool> onAttack;

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
            onAttack?.Invoke(true);
        }
        if(Input.GetKeyUp(attackCode)) 
        {
            TriggerAnimation("Idle_Trigger");
            onAttack?.Invoke(false);
        }
    }

    private void TriggerAnimation(string animationName)
    {
        playerAttackAnimator.SetTrigger(animationName);
    }
}
