using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFireAttack : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem flameAttack;

    private void Start() 
    {
        BossMovement.onBossAtack += FlamethrowerAttack;
    }

    private void FlamethrowerAttack()
    {
        flameAttack.Play();
    }
}
