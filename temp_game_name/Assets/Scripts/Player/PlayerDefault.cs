using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDefault : MonoBehaviour
{

    [SerializeField]
    private Animator playerAnimation;

    public Animator PlayerAnimation { get => playerAnimation; set => playerAnimation = value; }

    protected void TriggerAnimation(string animationName)
    {
        PlayerAnimation.SetTrigger(animationName);
    }
}
