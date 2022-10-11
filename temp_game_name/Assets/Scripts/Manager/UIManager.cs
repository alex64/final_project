using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private void Start() {
        PlayerData.onPlayerDead += ShowGameOverScene;
        PlayerCollision.onVictory += ShowVictoryScene;
    }

    public void OnClickMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }

    public void OnClickPlay(){
        SceneManager.LoadScene("Subnivel01");
    }

    public void OnClickCredits(){
        SceneManager.LoadScene("Credits");
    }

    public void ShowGameOverScene(){
        SceneManager.LoadScene("GameOver");
    }

    public void ShowVictoryScene(){
        SceneManager.LoadScene("Victory");
    }
}
