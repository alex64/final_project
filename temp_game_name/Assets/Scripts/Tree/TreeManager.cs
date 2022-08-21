using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeManager : MonoBehaviour
{
    [SerializeField] private GameObject treeLog;
    [SerializeField] private GameObject bridge;
    private bool isGrown = false;
    private bool isDestroyed = false;
    private bool isBridgeCreated = false;

    public bool IsGrown { get => isGrown; set => isGrown = value; }
    public bool IsDestroyed { get => isDestroyed; set => isDestroyed = value; }
    public bool IsBridgeCreated { get => isBridgeCreated; set => isBridgeCreated = value; }

    public void GrowTree(){
        transform.localScale = transform.localScale * 2;
        isGrown = true;
        isDestroyed = false;
    }

    public void DestroyTree(){
        Invoke("DestroyTreeAction", 2f);
        Invoke("InstantiateTreeLogAction", 2f);
        isDestroyed = true;
        isGrown = false;
    }

    private void DestroyTreeAction(){
        GameObject fallingTree = gameObject.transform.GetChild(0).gameObject;
        Destroy(fallingTree);
    }

    private void InstantiateTreeLogAction(){
        Instantiate(treeLog, transform);
    }

    public void CreateBridge(){
        Invoke("TreeRotation", 2f);
        Invoke("DestroyTreeAction", 0f);
        Invoke("InstantiateBridgeAction", 1f);
        isBridgeCreated = true;
    }

    private void TreeRotation(){
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(90, 0, 0), 2f * Time.deltaTime);
    }

    private void InstantiateBridgeAction(){
        Instantiate(bridge, transform);
    }
}
