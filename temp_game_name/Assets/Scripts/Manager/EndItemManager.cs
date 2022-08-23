using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndItemManager : MonoBehaviour
{
    [SerializeField]
    private GameObject finisObject;

    private bool isSignCreated = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateFinishMessage()
    {
        if(!isSignCreated) 
        {
            Invoke("CreateFinishModel", 0.5f);
            isSignCreated = true;
        }
        
    }

    private void CreateFinishModel()
    {
        Debug.Log("Create sign");
        Quaternion objectRotation = gameObject.transform.rotation;
        Destroy(gameObject.transform.GetChild(0).gameObject);
        GameObject sign = Instantiate(finisObject, transform.position, objectRotation);
        sign.transform.parent = gameObject.transform;
        
    }
}
