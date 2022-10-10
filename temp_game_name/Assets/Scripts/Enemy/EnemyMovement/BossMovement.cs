using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BossMovement : EnemyWalker
{

    private bool alreadySpoted = false;
    private string localLastAnimation;

    public static event Action onBossAtack;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        DamageAnimation = "bossDamaged";
        IdleAnimation = "bossIdle";
        AttackAnimation = "bossAttacking";
        MoveAnimation = "bossMoving";
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void SpotPlayerAction()
    {
        if(!alreadySpoted)
        {
            alreadySpoted = true;
            ToggleMovement(true);
            Invoke("BossAttack", 1f);
        }
        
    }

    private void BossAttack()
    {
        localLastAnimation = lastAnimationTrigger;
        SetAnimation(AttackAnimation);
        onBossAtack?.Invoke();
        Invoke("BossAttackingStop", 2.5f);
    }

    private void BossAttackingStop()
    {
        Debug.Log("Stop Attacking");
        alreadySpoted = false;
        SetAnimation(localLastAnimation);
        ToggleMovement(false);
    }

    private void ToggleMovement(bool stop)
    {
        StopMoving = stop;
        IsMoving = !stop;
    }
}
