using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeManager : GeneralMagicElement
{
    [SerializeField]
    private GameObject lightingRod;
    [SerializeField]
    [Range(0f, -1f)]
    private float zPosition = -0.3f;

    [SerializeField]
    [Range(1f, 2f)]
    private float treeActionsDelay = 2f;

    [SerializeField] private GameObject treeLog;
    [SerializeField] private GameObject normalTree;
    [SerializeField] private GameObject bridge;
    [SerializeField] private GameObject thunder;
    [SerializeField][Range(0f, 5f)] private float growPositionY = 1f;

    private bool isGrown = false;
    private bool isDestroyed = false;
    private bool isBridgeCreated = false;
    private bool hasLightingRod = false;
    private bool isTreeRotation = false;
    private bool triggerDeleteRotationTree = false;

    public bool IsGrown { get => isGrown; set => isGrown = value; }
    public bool IsDestroyed { get => isDestroyed; set => isDestroyed = value; }
    public bool IsBridgeCreated { get => isBridgeCreated; set => isBridgeCreated = value; }
    public bool HasLightingRod { get => hasLightingRod; set => hasLightingRod = value; }

    private void Update() {
        if(isTreeRotation) 
        {
            TreeRotation();
            if(!triggerDeleteRotationTree) 
            {
                ActivateThunder();
                Invoke("DestroyTreeAction", treeActionsDelay);
                triggerDeleteRotationTree = true;
            }
        }
        
    }

    public void GrowTree(){
        if(isDestroyed) 
        {
            Invoke("DestroyTreeAction", treeActionsDelay);
            Invoke("InstantiateTreeAction", treeActionsDelay);
        }
        else 
        {
            changeTree();
        }
        
    }

    private void changeTree()
    {
        Debug.Log("Change Treee");
        transform.position += new Vector3(0f, 0.7f, 0f);
        transform.localScale = transform.localScale * 2;
        isGrown = true;
        isDestroyed = false;
    }

    public void DestroyTree(){
        Debug.Log("Destroy");
        isGrown = false;
        isDestroyed = true;
        ActivateThunder();
        Invoke("DestroyTreeAction", treeActionsDelay);
        Invoke("InstantiateTreeLogAction", treeActionsDelay);
    }

    private void ActivateThunder(){
        thunder.SetActive(true);
    }

    private void DeactivateThunder(){
        thunder.SetActive(false);
    }

    private void DestroyTreeAction(){
        Invoke("DeactivateThunder", 1f);
        GameObject fallingTree = gameObject.transform.GetChild(0).gameObject;
        Destroy(fallingTree);
        if(isBridgeCreated) 
        {
            isTreeRotation = false;
            InstantiateBridgeAction();
        }
    }

    private void InstantiateTreeAction(){
        GameObject newTree = Instantiate(normalTree, transform.position + new Vector3(0, growPositionY, 0), transform.rotation);
        newTree.transform.parent = gameObject.transform;
        changeTree();
    }

    private void InstantiateTreeLogAction(){
        GameObject newTree = Instantiate(treeLog, transform.position + new Vector3(0, -0.7f, 0), transform.rotation);
        newTree.transform.parent = gameObject.transform;
    }

    public void CreateBridge()
    {
        if(gameObject.transform.GetChild(1) != null)
        {
            Destroy(gameObject.transform.GetChild(1).gameObject);
        }
        isBridgeCreated = true;
        isTreeRotation = true;
    }

    private void TreeRotation(){
        Quaternion lookRotation = Quaternion.LookRotation(Vector3.down);
        GameObject pivot = gameObject.transform.GetChild(0).transform.GetChild(0).gameObject;
        pivot.transform.rotation = Quaternion.Lerp(pivot.transform.rotation, lookRotation, 1.5f * Time.deltaTime);
    }

    private void InstantiateBridgeAction(){
        bridge.SetActive(true);
    }

    public void AddLightingRod()
    {
        hasLightingRod = true;
        Invoke("CreateLightinRodModel", 1f);
    }

    private void CreateLightinRodModel()
    {
        GameObject lr = Instantiate(lightingRod, new Vector3(transform.position.x, 1, transform.position.z + zPosition), Quaternion.Euler(0, 180, 0));
        lr.transform.parent = gameObject.transform;
    }
}
