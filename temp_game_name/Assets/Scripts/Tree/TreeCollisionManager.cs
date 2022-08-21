using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCollisionManager : MonoBehaviour
{
    [SerializeField] private GameObject angryLog;

    private void OnCollisionEnter(Collision other)
    {
        GameObject truckTree = gameObject.transform.GetChild(0).gameObject;
        //Debug.Log("CRASH");
        if(other.gameObject.tag == ("Player")){
            Destroy(truckTree);
            Invoke("CreateAngryLog", 2f);
            
        }
    }

    private void CreateAngryLog(){
        Instantiate(angryLog, transform);
    }
}
