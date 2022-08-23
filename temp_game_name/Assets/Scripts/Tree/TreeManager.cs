using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeManager : MonoBehaviour
{
    [SerializeField]
    private GameObject lightingRod;
    [SerializeField]
    [Range(0.1f, 0.5f)]
    private float zPosition = 0.3f;
    

    [SerializeField] private GameObject treeLog;
    [SerializeField] private GameObject bridge;

    private bool isGrown = true; //false;
    private bool isDestroyed = false;
    private bool isBridgeCreated = false;
    private bool hasLightingRod = false;

    public bool IsGrown { get => isGrown; set => isGrown = value; }
    public bool IsDestroyed { get => isDestroyed; set => isDestroyed = value; }
    public bool IsBridgeCreated { get => isBridgeCreated; set => isBridgeCreated = value; }
    public bool HasLightingRod { get => hasLightingRod; set => hasLightingRod = value; }

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

    public void AddLightingRod()
    {
        //Add Model
        hasLightingRod = true;
        Invoke("CreateLightinRodModel", 1f);
    }

    private void CreateLightinRodModel()
    {
        Debug.Log("Creating item");
        GameObject lr = Instantiate(lightingRod, new Vector3(transform.position.x, 1, transform.position.z + zPosition), transform.rotation);
        lr.transform.parent = gameObject.transform;
    }
}
