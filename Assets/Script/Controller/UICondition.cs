using UnityEngine;


public class UICondition : MonoBehaviour
{

    public Condition health;
    public Condition stamina;
    public Condition invisible;
    public Condition SpeedUp;

    private void Start()
    {

        CharacterManager.Instance.Player.condition.uiCondition = this;
    }


}


