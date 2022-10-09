using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverBridgeManager : MonoBehaviour
{

    [SerializeField]
    private RiverManager riverManager;

    [SerializeField]
    private GameObject riverBorder;

    [SerializeField]
    private float maxAscendLevel = 0.1f;

    [SerializeField]
    [Range(0f, 1f)]
    private float speed = 0.1f;

    private bool isGoingUp = false;

    private void Start() 
    {
        RiverRockManager.onRockDestroyed += SetClearArea;
    }

    private void Update() 
    {

        if(isGoingUp && riverManager.isRiverActive()) 
        {
            if(transform.position.y < (riverManager.getYPosition() + maxAscendLevel)) 
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime);
            }
            else 
            {
                Debug.Log("Bridge stop");
                Destroy(riverBorder);
                isGoingUp = false;
            }
        }
    }

    private void SetClearArea()
    {
        Debug.Log("area cleared");
        isGoingUp = true;
    }
}
