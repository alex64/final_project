using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainManager : MonoBehaviour
{

    [SerializeField]
    [Range(1f, 2f)]
    private float terrainChangeTrigger = 1f;

    [SerializeField]
    private Light terrainLight;

    private GameObject tree;

    enum TerrainType {Rain, Ligh}


    private float timeInTerrainChange = 0f;

    /*private void Start() {
        treeManager = GetComponent<TreeMnager>(); //Script from Tree
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            timeInTerrainChange = 0f;
        }
    }

    private void OnTriggerStay(Collider other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            timeInTerrainChange += Time.deltaTime;
            if(timeInTerrainChange >= terrainChangeTrigger) 
            {
                siwthc(terran) 
                treemanager.grow
                //Crecer arbol
                //Activeate camera blue

                //
                treeManager.lightFai
                treeManager.fall
                treeManger.createBrige
                //Tree falls
            }
        }

        
    }*/
}
