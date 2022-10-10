using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyCollider : MonoBehaviour
{
    private bool executingAction = false;

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.CompareTag("Sword")) 
        {
            PlayerData playerData = other.GetComponentInParent<PlayerData>();
            if(playerData.IsAttacking && !executingAction) {
                executingAction = true;
                Invoke("DamageEnemy", 0.5f);
            }
            
        }
    }

    private void OnTriggerStay(Collider other) {
        if(other.gameObject.CompareTag("Sword")) 
        {
            PlayerData playerData = other.GetComponentInParent<PlayerData>();
            if(playerData.IsAttacking && !executingAction) {
                executingAction = true;
                Invoke("DamageEnemy", 0.5f);
            }
        }
    }

    private void DamageEnemy() {
        Debug.Log("Lower Enemy HP");
        executingAction = false;
        GetComponent<EnemyGeneralMovement>().DamageMovement();
        GetComponent<EnemyData>().LowerHP(1);
    }
}
