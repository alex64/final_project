using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryLogCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("DESTROY LOG");
        if(other.gameObject.tag == ("Player")){
            Destroy(gameObject);
        }
    }
}
