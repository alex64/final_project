using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerCollision : MonoBehaviour
{
    private PlayerData playerData;
    private TreeManager treeManager;
    public static event Action<GeneralMagicElement> onCollision;
    public static event Action onExit;

    private void Start() 
    {
        playerData = GetComponent<PlayerData>();
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("MagicItem"))
        {
            playerData.HasMagicItem = true;
            Destroy(other.gameObject);
        }
        if(other.gameObject.CompareTag("ShovelItem"))
        {
            playerData.HasShovel = true;
            Destroy(other.gameObject);
        }
        if(other.gameObject.CompareTag("Finish"))
        {
            other.gameObject.GetComponent<EndItemManager>().CreateFinishMessage();
            //other.gameObject.GetComponent<ChestManager>().CreateFinishMessage();
            //Destroy(other.gameObject);
        }
    }

    private void OnCollisionStay(Collision other) {
        if(other.gameObject.CompareTag("FallingTree") 
                || other.gameObject.CompareTag("RiverSide"))
        {
            //Debug.Log("Collision stay with: " + other.gameObject.tag);
            onCollision?.Invoke(other.gameObject.GetComponent<GeneralMagicElement>().Instance);
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.CompareTag("FallingTree")  
                || other.gameObject.CompareTag("RiverSide"))
        {
            //playerData.CollidedWithActionElement = false;
            onExit?.Invoke();
        }
    }

    /*private void AddMagicItem()
    {
        
        if(Input.GetKeyDown(KeyCode.O)) 
        {
            if(playerData.HasMagicItem && !treeManager.HasLightingRod && treeManager.IsGrown) 
            {
                Debug.Log("Adding Ligthing Rod");
                treeManager.AddLightingRod();
            }
            else 
            {
                Debug.Log("Cannot attach magic item or already has it");
            }
            
        }
    }*/
}
