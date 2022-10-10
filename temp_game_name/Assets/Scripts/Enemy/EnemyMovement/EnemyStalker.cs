using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStalker : EnemyGeneralMovement
{
    // Start is called before the first frame update
    protected override void Start()
    {  
        base.Start();
        if(EnemyAnimator!= null) {
            EnemyAnimator.SetTrigger("movingTriggerRunner");
        }
    }

    // Update is called once per frame
    void Update()
    {
        ChasePlayer(true);
    }
}
