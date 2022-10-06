using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerAttackCollider : MonoBehaviour
{

    private bool executingAction = false;
    public static event Action<int> damageEnemyAction; 

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.CompareTag("Enemy")) 
        {
            if(GetComponent<PlayerData>().IsAttacking && !executingAction) {
                executingAction = true;
                Invoke("DamageEnemy", 0.5f);
            }
            
        }
    }

    private void OnTriggerStay(Collider other) {
        if(other.gameObject.CompareTag("Enemy")) 
        {
            if(GetComponent<PlayerData>().IsAttacking && !executingAction) {
                executingAction = true;
                Invoke("DamageEnemy", 0.5f);
            }
            
        }
    }

    private void DamageEnemy() {
        Debug.Log("Lower Enemy HP");
        executingAction = false;
        damageEnemyAction?.Invoke(1);
    }
}
