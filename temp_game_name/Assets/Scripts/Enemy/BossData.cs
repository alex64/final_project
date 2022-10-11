using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BossData : EnemyData
{
    public static event Action bossDeath;

    public override void LowerHP(int damage) {
        Hp -= damage;
        if(Hp == 0) {
            bossDeath?.Invoke();
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
}
