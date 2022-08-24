using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCollisionManager : MonoBehaviour
{
    [SerializeField] private GameObject angryLog;
    private Transform playerTransform;

    public Transform PlayerTransform { get => playerTransform; set => playerTransform = value; }

    private void OnCollisionEnter(Collision other)
    {
        GameObject truckTree = gameObject.transform.GetChild(0).gameObject;
        //Debug.Log("CRASH");
        GameObject playerGameObject = other.gameObject;
        if(playerGameObject.tag == ("Player")){
            PlayerTransform = playerGameObject.transform;
            Destroy(truckTree);
            Invoke("CreateAngryLog", 2f);
            
        }
    }

    private void CreateAngryLog(){
        angryLog.GetComponent<EnemyMove>().PlayerTransform = PlayerTransform;
        Instantiate(angryLog, transform);
    }
}
