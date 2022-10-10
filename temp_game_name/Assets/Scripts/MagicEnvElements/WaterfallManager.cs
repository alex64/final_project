using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterfallManager : GeneralMagicElement
{
    [SerializeField] private GameObject iceWaterfall;

    public bool isWaterfallActive()
    {
        return gameObject.activeSelf;
    }

    public void setWaterfallActive(bool activate)
    {
        gameObject.SetActive(activate);
        iceWaterfall.SetActive(activate);
    }
}
