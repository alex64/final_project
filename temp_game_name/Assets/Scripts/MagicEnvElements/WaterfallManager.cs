using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterfallManager : GeneralMagicElement
{
    public bool isWaterfallActive()
    {
        return gameObject.activeSelf;
    }

    public void setWaterfallActive(bool activate)
    {
        gameObject.SetActive(activate);
    }
}
