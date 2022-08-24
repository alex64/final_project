using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotemTrigger : MonoBehaviour
{
    [SerializeField] private TreeManager treeManager;
    [SerializeField] private float timeInTotem = 2f;
    [SerializeField] private TotemType totemType;
    
    enum TotemType {Rain, Thunder};
    private float time = 0f;

    private void OnTriggerEnter(Collider other) {
        Debug.Log("TEst");
        if(other.gameObject.CompareTag("Player")){
            time = 0f;
        }
    }

    private void OnTriggerStay(Collider other) {
        if(other.gameObject.CompareTag("Player")){
            time += Time.deltaTime;
            if(time >= timeInTotem){
                Debug.Log("Time");
                switch(totemType){
                    case TotemType.Rain:
                        //Set Ligt Blue
                        if(treeManager.IsDestroyed || !treeManager.IsGrown) 
                        {
                            treeManager.GrowTree();
                            time = 0;
                        }
                        break;
                    case TotemType.Thunder:
                        Debug.Log("Thunder");
                        //Set Ligt Yellow
                        if(!treeManager.IsGrown && !treeManager.IsDestroyed) 
                        {
                            treeManager.DestroyTree();
                            time = 0;
                        }
                        if(treeManager.IsGrown && treeManager.HasLightingRod && !treeManager.IsBridgeCreated) 
                        {
                            Debug.Log("Create Bridge");
                            treeManager.CreateBridge();
                            time = 0;
                        }
                        break;
                }
            }
        }
    }

    private void SetLights() 
    {

    }
}
