using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    private bool hasMagicItem = false;
    private bool collideWithTree = false;
    
    public bool CollideWithTree { get => collideWithTree; set => collideWithTree = value; }
    public bool HasMagicItem { get => hasMagicItem; set => hasMagicItem = value; }

    private bool isAttacking = false;
    public bool IsAttacking { get => isAttacking; set => isAttacking = value; }

    private void Start() {
        PlayerAttack.onAttack += PlayerIsAttacking;
    }
    
    private void PlayerIsAttacking(bool isAttacking)
    {
        IsAttacking = isAttacking;
        //Debug.Log("Player: " + IsAttacking);
    }
}
