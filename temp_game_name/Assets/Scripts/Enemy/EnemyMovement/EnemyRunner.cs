using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRunner : EnemyGeneralMovement
{
    // Start is called before the first frame update
    protected override void Start()
    {  
        base.Start();
        EnemyAnimator.SetTrigger("movingTriggerRunner");
        DamageAnimation = "damagedTriggerRunner";
        IdleAnimation = "idleTriggerRunner";
    }

    // Update is called once per frame
    void Update()
    {
        ChasePlayer(false);
    }
}
