using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour
{

    [SerializeField]
    private int hp = 3;
    public int Hp { get => hp; set => hp = value; }

    [SerializeField]
    [Range(1f, 15f)]
    private float rayDistance = 10f;

    public float RayDistance { get => rayDistance; set => rayDistance = value; }

    public void LowerHP(int damage) {
        Hp -= damage;
        if(Hp == 0) {
            Destroy(gameObject);
        }
    }
}
