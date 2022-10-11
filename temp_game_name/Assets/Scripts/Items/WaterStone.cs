using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterStone : MonoBehaviour
{
    [SerializeField] private GameObject waterStone;

    void Start()
    {
        BossData.bossDeath += ShowWaterStone;
    }

    public void ShowWaterStone(){
        Debug.Log("WIN");
        GameObject waterStoneGO = Instantiate(waterStone, transform.position, transform.rotation);
    }
}
