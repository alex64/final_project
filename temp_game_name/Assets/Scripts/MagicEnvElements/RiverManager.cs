using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverManager : GeneralMagicElement
{
    [SerializeField] private GameObject riverSteam;

    public bool isRiverActive()
    {
        return gameObject.activeSelf;
    }

    public void setRiverActive(bool activate)
    {
        gameObject.SetActive(activate);
        if(!activate){
            riverSteam.SetActive(!activate);
        }
    }

    public float getYPosition()
    {
        return transform.position.y;
    }
}
