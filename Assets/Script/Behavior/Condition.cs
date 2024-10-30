using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Condition : MonoBehaviour
{

    public float curValue;
    public float maxValue;
    public float startValue;
    public float passiveValue;
    public Image uiBar;
    public TMP_Text CurrentHealth;


    private void Start()
    {
        curValue = startValue;
    }

    private void Update()
    {
        uiBar.fillAmount = GetPercentage();
        ShowAmount();
    }

    public void Add(float amount)
    {
        curValue = Mathf.Min(curValue + amount, maxValue);
    }

    public void Subtract(float amount)
    {
        curValue = Mathf.Max(curValue - amount, 0.0f);
    }

    public float GetPercentage()
    {
        return 1 - curValue / maxValue;
    }


    public void ShowAmount()
    {

        CurrentHealth.text = ((int)curValue).ToString();

    }



   

}
