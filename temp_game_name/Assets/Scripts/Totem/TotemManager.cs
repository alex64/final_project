using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotemManager : MonoBehaviour
{
    enum TotemType {Rain, Thunder, Fire, Ice};

    [SerializeField] 
    private GeneralMagicElement magicEnvElement;

    [SerializeField] 
    private float timeInTotem = 2f;

    [SerializeField] 
    private TotemType totemType;

    [SerializeField] 
    private GameObject totemLight;

    [SerializeField] private GameObject sunLight;

    private TreeManager treeManager;
    private RiverManager riverManager;
    private WaterfallManager waterfallManager;

    private float time = 0f;

    private void Start() 
    {
        AssignManager(magicEnvElement);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")){
            time = 0f;
        }
    }

    private void OnTriggerStay(Collider other) {
        if(other.gameObject.CompareTag("Player")){
            time += Time.deltaTime;
            if(time >= timeInTotem){
                //ToggleTotemLight(false);
                switch(totemType)
                {
                    case TotemType.Rain:
                        WaterTotemAction();
                        break;
                    case TotemType.Thunder:
                        ThunderTotmeAction();
                        break;
                    case TotemType.Fire:
                        FireTotemAction();
                        break;
                    case TotemType.Ice:
                        IceTotemAction();
                        break;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.CompareTag("Player")){
            //ToggleTotemLight(true);
        }
    }

    private void ToggleTotemLight(bool sunLightActive)
    {
        totemLight.SetActive(!sunLightActive);
        sunLight.SetActive(sunLightActive);
    }

    private void AssignManager(GeneralMagicElement magicEnvElement)
    {
        if(magicEnvElement is TreeManager) 
        {
            treeManager = (TreeManager)magicEnvElement;
            return;
        }
        if(magicEnvElement is RiverManager)
        {
            riverManager = (RiverManager)magicEnvElement;
        }
        if(magicEnvElement is WaterfallManager) 
        {
            waterfallManager = (WaterfallManager)magicEnvElement;
        }
    }

    private void WaterTotemAction() 
    {
        if(treeManager != null) {
            if(treeManager.IsDestroyed || !treeManager.IsGrown) 
            {
                treeManager.GrowTree();
                time = 0;
            }
        }
        if(riverManager != null)
        {
            if(!riverManager.isRiverActive())
            {
                riverManager.setRiverActive(true);
            }
            time = 0;
        }
    }

    private void ThunderTotmeAction()
    {
        //Set Ligt Yellow
        if(treeManager != null) 
        {
            if(!treeManager.IsGrown && !treeManager.IsDestroyed) 
            {
                treeManager.DestroyTree();
                time = 0;
            }
            if(treeManager.IsGrown && treeManager.HasLightingRod && !treeManager.IsBridgeCreated) 
            {
                treeManager.CreateBridge();
                time = 0;
            }
        }
    }

    private void FireTotemAction()
    {
        Debug.Log("Fire Totem Action");
        if(riverManager != null)
        {
            if(riverManager.isRiverActive())
            {
                riverManager.setRiverActive(false);
            }
            time = 0;
        }
    }

    private void IceTotemAction()
    {
        Debug.Log("Ice Totem Action");
        if(waterfallManager != null)
        {
            if(waterfallManager.isWaterfallActive())
            {
                waterfallManager.setWaterfallActive(false);
            }
            time = 0;
        }
    }
}
