using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static int playerHP;
    public static int PlayerHP { get => playerHP; set => playerHP = value; }


    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {   
            instance = this;
            DontDestroyOnLoad(gameObject);
        }else
        {
            Destroy(gameObject);
        }
    }

    public static void setPlayerHP(int hp)
    {
        playerHP = hp;
        Debug.Log(playerHP);
    }
}
