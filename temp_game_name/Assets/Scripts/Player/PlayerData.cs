using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    private bool hasMagicItem = false;
    private bool hasShovel = false;
    //private bool collideWithTree = false;
    private bool collidedWithActionElement = false;
    
    //public bool CollideWithTree { get => collideWithTree; set => collideWithTree = value; }
    public bool CollidedWithActionElement { get => collidedWithActionElement; set => collidedWithActionElement = value; }

    public bool HasMagicItem { get => hasMagicItem; set => hasMagicItem = value; }

    private bool isAttacking = false;
    public bool IsAttacking { get => isAttacking; set => isAttacking = value; }
    public bool HasShovel { get => hasShovel; set => hasShovel = value; }

    private void Start() {
        PlayerAttack.onAttack += PlayerIsAttacking;
    }
    
    private void PlayerIsAttacking(bool isAttacking)
    {
        IsAttacking = isAttacking;
        //Debug.Log("Player: " + IsAttacking);
    }
}
