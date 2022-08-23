using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    private bool hasMagicItem = true;//false;
    private bool collideWithTree = false;
    
    public bool CollideWithTree { get => collideWithTree; set => collideWithTree = value; }
    public bool HasMagicItem { get => hasMagicItem; set => hasMagicItem = value; }
}
