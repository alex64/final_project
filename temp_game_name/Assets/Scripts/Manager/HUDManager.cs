using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public static HUDManager instance;
    [SerializeField] private Image[] hearts;

    private void Awake()
    {
        if (instance == null)
        {   
            instance = this;
            Debug.Log(instance);
            DontDestroyOnLoad(gameObject);
        }else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void DecreaseLife(int heartsPlace){
        hearts[heartsPlace].gameObject.SetActive(false);
    }
}
