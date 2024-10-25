using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{

    public GameObject TirdPersonCamera;
    public GameObject FirstPersonCamera;


    private PlayerController controller;


    private void Start()
    {
        controller = CharacterManager.Instance.Player.controller;
        controller.PovChange += ViewPointSwitch;

    }

    void ViewPointSwitch()
    {

        if (TirdPersonCamera.activeInHierarchy)
        {
            TirdPersonCamera.SetActive(false);
            FirstPersonCamera.SetActive(true);

        }
        else
        {
            TirdPersonCamera.SetActive(true);
            FirstPersonCamera.SetActive(false);


        }


    }
    


}
