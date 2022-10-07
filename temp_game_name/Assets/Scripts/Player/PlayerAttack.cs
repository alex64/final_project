using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerAttack : PlayerDefault
{

    private KeyCode attackCode = KeyCode.Return;

    public static event Action<bool> onAttack;

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
}
