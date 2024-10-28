using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReSpawn : MonoBehaviour
{


    Vector3 spawnPosition = new Vector3(30f, -4f, -30f);

    public void Start()
    {
        CharacterManager.Instance.Player.condition.OnDead += Respawn;

    }


    public void Respawn()
    {

      transform.position = spawnPosition;

    }


}
