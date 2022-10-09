using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RiverBorderCollider : GeneralMagicElement
{
    [SerializeField]
    [Range(0, 2)]
    private int riverPosition;

    public int RiverPosition { get => riverPosition; set => riverPosition = value; }

    public static event Action<int> onPlayerCollision;

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("Player")) 
        {
            //Debug.Log("Player collision: " + riverPosition);
            onPlayerCollision?.Invoke(riverPosition);
        }
    }
}
