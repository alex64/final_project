using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField]
    private float damageTime = 3f;

    [SerializeField]
    private GeneralMagicElement manager;

    private PlayerData playerData;
    //private TreeManager treeManager;
    public static event Action<GeneralMagicElement> onCollision;
    public static event Action onExit;
    public static event Action onDamage;

    private bool isDamaged = false;

    private void Start() 
    {
        playerData = GetComponent<PlayerData>();
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("MagicItem"))
        {
            playerData.HasMagicItem = true;
            Destroy(other.gameObject);
        }
        if(other.gameObject.CompareTag("ShovelItem"))
        {
            playerData.HasShovel = true;
            Destroy(other.gameObject);
        }
        if(other.gameObject.CompareTag("Finish"))
        {
            other.gameObject.GetComponent<EndItemManager>().CreateFinishMessage();
            //other.gameObject.GetComponent<ChestManager>().CreateFinishMessage();
            //Destroy(other.gameObject);
        }
        if(other.gameObject.CompareTag("Enemy"))
        {
            PlayerDamaged();
        }
    }

    private void OnCollisionStay(Collision other) {
        if(other.gameObject.CompareTag("FallingTree"))
        {
            //Debug.Log("Collision stay with: " + other.gameObject.tag);
            onCollision?.Invoke(manager);
        }
        if(other.gameObject.CompareTag("RiverSide"))
        {
            onCollision?.Invoke(other.gameObject.GetComponent<GeneralMagicElement>().Instance);
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.CompareTag("FallingTree")  
                || other.gameObject.CompareTag("RiverSide"))
        {
            onExit?.Invoke();
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        if(other.gameObject.CompareTag("Fire") && !isDamaged)
        {
            PlayerDamaged();
        }
    }

    private void PlayerDamaged()
    {
        isDamaged = true;
        onDamage?.Invoke();
        Invoke("RecoileDamage", damageTime);
    }

    private void RecoileDamage()
    {
        isDamaged = false;
    }
}
