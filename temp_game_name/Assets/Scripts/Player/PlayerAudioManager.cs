using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioManager : MonoBehaviour
{
    [SerializeField] private float attackVolumen = 0.04f;
    [SerializeField] private AudioClip attackAudio;
    private AudioSource audioPlayer;

    // Start is called before the first frame update
    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
        PlayerAttack.onAttack += PlayerAttackAudio;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlayerAttackAudio(bool attack){
        if(audioPlayer != null)
        {
            PlayAudio(attackAudio, attackVolumen);
        }
    }

    private void PlayAudio(AudioClip audioClip, float attackVolumen){
        if(!audioPlayer.isPlaying){
            audioPlayer.PlayOneShot(audioClip, attackVolumen);
        }
    }
}
