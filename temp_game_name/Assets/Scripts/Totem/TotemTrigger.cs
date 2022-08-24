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
                switch(totemType){
                    case TotemType.Rain:
                        if(treeManager.IsDestroyed || !treeManager.IsGrown) { //|| !treeManager.IsBridgeCreated){
                            treeManager.GrowTree();
                        }
                        break;
                    case TotemType.Thunder:
                        if(!treeManager.IsGrown && !treeManager.IsDestroyed) 
                        {
                            treeManager.DestroyTree();
                        }
                        break;
                }
            }
        }
    }
}
