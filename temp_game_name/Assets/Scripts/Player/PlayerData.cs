using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    //[SerializeField]
    private int hp = 3;
    public int Hp { get => hp; set => hp = value; }

    private bool hasShovel = false;
    public bool HasShovel { get => hasShovel; set => hasShovel = value; }

    private bool collidedWithActionElement = false;
    public bool CollidedWithActionElement { get => collidedWithActionElement; set => collidedWithActionElement = value; }

    private bool hasMagicItem = false;
    public bool HasMagicItem { get => hasMagicItem; set => hasMagicItem = value; }

    private bool isAttacking = false;
    public bool IsAttacking { get => isAttacking; set => isAttacking = value; }

    private void Start() {
        GameManager.setPlayerHP(hp);
        PlayerAttack.onAttack += PlayerIsAttacking;
        PlayerCollision.onDamage += LowerHP;
    }
    
    private void PlayerIsAttacking(bool isAttacking)
    {
        IsAttacking = isAttacking;
        //Debug.Log("Player: " + IsAttacking);
    }

    private void LowerHP()
    {
        Hp--;
        //HUDManager.instance.DecreaseLife(Hp);
        Debug.Log("Player Life: " + Hp);
        if(Hp == 0) 
        {

        }
    }
}
