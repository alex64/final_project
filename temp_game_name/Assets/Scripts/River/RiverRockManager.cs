using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RiverRockManager : MonoBehaviour
{
    [SerializeField]
    private RiverManager riverManager;

    [SerializeField]
    private List<GameObject> rockList;

    public static event Action onRockDestroyed;

    private int position;
    private int rockCount = 0;

    private void Start() 
    {
        rockCount = rockList.Count;
        RiverBorderCollider.onPlayerCollision += SetPosition;
    }

    private void SetPosition(int pos) 
    {
        position = pos;
    }

    public void DestroyRock()
    {
        if(!riverManager.isRiverActive())
        {
            Invoke("RemoveRockObject", 0.25f);
            
        }
    }

    private void RemoveRockObject()
    {
        if(rockCount > 0 && rockList[position] != null) 
        {
            Debug.Log("Destroy rock: " + position);
            Destroy(rockList[position]);
            rockCount--;
            Debug.Log("Count: " + rockCount);
            if(rockCount == 0)
            {
                Debug.Log("All rocks destroyed");
                onRockDestroyed?.Invoke();
            }
        }
        
    }
}
