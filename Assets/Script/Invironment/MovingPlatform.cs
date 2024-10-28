using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{


    public GameObject Player;

    private void Start()
    {
        Player = CharacterManager.Instance.Player.gameObject; 
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject == Player)
        {

            Player.transform.parent = transform;
        
        }


    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject == Player)
        {

            Player.transform.parent = null;

        }

    }


}
