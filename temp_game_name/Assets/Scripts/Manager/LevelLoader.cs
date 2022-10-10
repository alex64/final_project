using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    private void Start()
    {
        BridgeExitManager.exitLevel+= LoadNextLevel;
    }

    private void LoadNextLevel(){
        transition.SetTrigger("EnterSceneChange");
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex){
        //Wait 
        yield return new WaitForSeconds(transitionTime);
        //Play animation
        transition.SetTrigger("Exit");
        //Load scene
        SceneManager.LoadScene(levelIndex);
    }
}
