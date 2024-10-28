using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public interface IDamagable
{
    void TakePhysicalDamage(int damageAmount);

}


public class PlayerCondition : MonoBehaviour, IDamagable
{

    public UICondition uiCondition;

    Condition health { get { return uiCondition.health; } }
    Condition stamina { get { return uiCondition.stamina; } }

    public event Action onTakeDamage;
    public event Action OnDead;


    public void Update()
    {


        Debug.Log(health.curValue);
        stamina.Add(stamina.passiveValue * Time.deltaTime);


        if (health.curValue <= 0.0f)
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

        OnDead?.Invoke();


    }

}