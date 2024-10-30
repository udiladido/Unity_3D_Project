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
    private ClockingEffect ClockingEffect;

    Condition health { get { return uiCondition.health; } }
    Condition stamina { get { return uiCondition.stamina; } }

    Condition invisible { get { return uiCondition.invisible; } }
    
    Condition SpeedUp { get { return uiCondition.SpeedUp; } }

    public event Action onTakeDamage;
    public event Action OnDead;


    public void Start()
    {
        ClockingEffect = GetComponent<ClockingEffect>();
    }


    public void Update()
    {

        stamina.Add(stamina.passiveValue * Time.deltaTime);


        if (health.curValue <= 0.0f)
        {

            Die();
            health.curValue = health.maxValue;
        }

    }


    public void Clocking(float time)
    {

        invisible.Subtract(time);
        ClockingEffect.DissolveStart(time);


    }

    public void increaseSpeed(float Duration)
    {

        SpeedUp.Subtract(Duration);
       

    }


    public void Heal(float amount)
    {
        health.Add(amount);
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