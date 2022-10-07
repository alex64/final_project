using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMagicAction : PlayerDefault
{
    private PlayerData playerData;
    private bool canPerformAction = true;
    //[SerializeField]
    //private TreeManager treeManager;
    private GeneralMagicElement magicEnvElement;
    private Transform weapon;

    [SerializeField]
    private float delayNextDig = 0.5f;

    [SerializeField] private UnityEvent OnTriggerShovel;

    // Start is called before the first frame update
    void Start()
    {
        PlayerCollision.onCollision += SetMagicElement;
        PlayerCollision.onExit += ClearMagicElement;
        playerData = GetComponent<PlayerData>();
        weapon = transform.GetChild(0) //PlayerAvatar
            .GetChild(0) //MaleCharacter
                .GetChild(4) //root
                    .GetChild(0) //pelvis
                        .GetChild(0) //spine_01
                            .GetChild(0) //spine_02
                                .GetChild(0) //spine_03
                                    .GetChild(2) //clavicle_r
                                        .GetChild(1) //upperarm_r
                                            .GetChild(0) //lowerarm_r
                                                .GetChild(0) //hand_r
                                                    .GetChild(2); //weapon_r
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.O)) 
        {
            /*if(playerData.CollidedWithActionElement)
            {
                if(playerData.HasMagicItem && !treeManager.HasLightingRod && treeManager.IsGrown) 
                {
                    Debug.Log("Adding Ligthing Rod");
                    treeManager.AddLightingRod();
                }
                else 
                {
                    Debug.Log("Cannot attach magic item or already has it");
                }
            }*/
            //if(playerData.CollidedWithActionElement && playerData.HasMagicItem)
            if(magicEnvElement != null && playerData.HasMagicItem)
            {
                if(magicEnvElement is TreeManager) {
                    TreeManager treeManager = (TreeManager)magicEnvElement;
                    if(treeManager.HasLightingRod && treeManager.IsGrown) 
                    {
                        Debug.Log("Adding Ligthing Rod");
                        treeManager.AddLightingRod();
                    }
                    else 
                    {
                        Debug.Log("Cannot attach magic item or already has it");
                    }
                } 
            }
            else if(playerData.HasShovel) 
            {
                if(canPerformAction) {
                    TriggerAnimation("Dig_Trigger");
                    canPerformAction = false;
                    ToggleShovel(true);
                    if(magicEnvElement != null && magicEnvElement is RiverManager) 
                    {
                        OnTriggerShovel?.Invoke();
                    }
                    Invoke("DelayNextDig", delayNextDig); 
                }
            }
            else
            {
                Debug.Log("Cannot use magic item");
            }
        }
        
    }

    private void SetMagicElement(GeneralMagicElement element) 
    {
        if(magicEnvElement == null) 
        {
            magicEnvElement = element;
        }
        
    }

    private void ClearMagicElement() {
        magicEnvElement = null;
    }

    private void DelayNextDig() 
    {
        canPerformAction = true;
        ToggleShovel(false);
        TriggerAnimation("Idle_Trigger");
    }

    private void ToggleShovel(bool activateShovel) 
    {
        weapon.GetChild(0).gameObject.SetActive(!activateShovel);
        weapon.GetChild(1).gameObject.SetActive(activateShovel);
    }
}
