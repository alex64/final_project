using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralMagicElement : MonoBehaviour
{
    private GeneralMagicElement instance;

    public GeneralMagicElement Instance { get => instance; set => instance = value; }

    public virtual void Start() {
        Instance = this;
    }
}
