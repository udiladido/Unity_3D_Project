using System;
using UnityEngine;


[RequireComponent(typeof(PlayerController))]
public class Player : MonoBehaviour
{
    public PlayerController controller;
    public PlayerCondition condition;

    public ItemDataSO itemData;
    public Action addItem;

    private void Awake()
    {

        CharacterManager.Instance.Player = this;
        controller = GetComponent<PlayerController>();
        condition = GetComponent<PlayerCondition>();
    }




}
