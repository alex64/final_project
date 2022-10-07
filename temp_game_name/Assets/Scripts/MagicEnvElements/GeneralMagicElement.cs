using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralMagicElement : MonoBehaviour
{
    private GeneralMagicElement instance;

    public GeneralMagicElement Instance { get => instance; set => instance = value; }

    private void Start() {
        Instance = this;
    }
}
