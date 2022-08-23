using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private PlayerData playerData;
    private TreeManager treeManager;

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
        if(other.gameObject.CompareTag("Finish"))
        {
            other.gameObject.GetComponent<EndItemManager>().CreateFinishMessage();
            //other.gameObject.GetComponent<ChestManager>().CreateFinishMessage();
            //Destroy(other.gameObject);
        }
    }

    private void OnCollisionStay(Collision other) {
        if(other.gameObject.CompareTag("FallingTree"))
        {
            Debug.Log("Collision stay falling Tree");
            playerData.CollideWithTree = true;
            /*treeManager = other.gameObject.GetComponent<TreeManager>();
            if(!treeManager.HasLightingRod && treeManager.IsGrown)
            {
                playerData.CollideWithTree = true;
            }*/
            //AddMagicItem();

        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.CompareTag("FallingTree"))
        {
            playerData.CollideWithTree = false;
        }
    }

    private void AddMagicItem()
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
    }
}
