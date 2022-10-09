using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverManager : GeneralMagicElement
{
    public bool isRiverActive()
    {
        return gameObject.activeSelf;
    }

    public void setRiverActive(bool activate)
    {
        /*if(activate) 
        {
            //IF possible, animation for evaporation
        }*/
        gameObject.SetActive(activate);
    }

    public float getYPosition()
    {
        return transform.position.y;
    }
}
