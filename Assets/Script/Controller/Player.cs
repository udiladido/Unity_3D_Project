using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class Player : MonoBehaviour
{
    public PlayerController controller;

    private void Awake()
    {

        CharacterManager.Instance.Player = this;
        controller = GetComponent<PlayerController>();

    }




}
