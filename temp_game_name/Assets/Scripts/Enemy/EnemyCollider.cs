using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Player")) 
        {
            //Debug.Log("IsAttacking: " + other.gameObject.GetComponent<PlayerData>().IsAttacking);
        }
        
    }
}
