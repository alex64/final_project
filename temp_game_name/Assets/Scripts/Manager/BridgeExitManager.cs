using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BridgeExitManager : MonoBehaviour
{
    public static event Action exitLevel;

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Player")){
            Debug.Log("EXIT");
            exitLevel?.Invoke();
        }
    }
}
