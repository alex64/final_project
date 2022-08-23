using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    private PlayerData playerData;
    [SerializeField]
    private TreeManager treeManager;

    // Start is called before the first frame update
    void Start()
    {
        playerData = GetComponent<PlayerData>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerData.CollideWithTree && Input.GetKeyDown(KeyCode.O))
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
