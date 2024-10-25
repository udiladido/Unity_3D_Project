using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCondition : MonoBehaviour
{

    public UICondition uiCondition;

    Condition health { get { return uiCondition.health; } }
    Condition stamina { get { return uiCondition.stamina; } }

    public event Action onTakeDamage;

    public void Update()
    {

        stamina.Add(stamina.passiveValue * Time.deltaTime);


        if (health.curValue < 0.0f)
        {
            Die();
        }

    }



    public void TakePhysicalDamage(int damageAmount)
    {
        health.Subtract(damageAmount);
        onTakeDamage?.Invoke();

    }

    public void Die()
    { 
    
    
    
    }

}