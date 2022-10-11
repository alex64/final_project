using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void OnClickMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }

    public void OnClickPlay(){
        SceneManager.LoadScene("Subnivel01");
    }

    public void OnClickCredits(){
        SceneManager.LoadScene("Credits");
    }
}
