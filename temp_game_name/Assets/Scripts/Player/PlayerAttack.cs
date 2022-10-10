using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerAttack : PlayerDefault
{

    private KeyCode attackCode = KeyCode.Return;

    public static event Action<bool> onAttack;

    [SerializeField] private AudioClip sfxAttack;
    private AudioSource sfxSource;
    
    private void Awake()
    {
        sfxSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(attackCode)) 
        {
            TriggerAnimation("Attack_Trigger");
            onAttack?.Invoke(true);
            PlaySFX(1.3f);
        }
        if(Input.GetKeyUp(attackCode)) 
        {
            TriggerAnimation("Idle_Trigger");
            onAttack?.Invoke(false);
        }
    }

    private void PlaySFX(float volume)
    {
        Debug.Log("sfxSource: " + sfxSource);
        Debug.Log("sfxAttack: " + sfxAttack);
        sfxSource.PlayOneShot(sfxAttack, volume);
    }
}
