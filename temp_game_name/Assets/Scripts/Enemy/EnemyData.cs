using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour
{

    [SerializeField]
    private int hp = 3;

    // Start is called before the first frame update
    void Start()
    {
        PlayerAttackCollider.damageEnemyAction += Damage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Damage(int damage) {
        hp -= damage;
        if(hp == 0) {
            Destroy(gameObject);
        }
    }
}
