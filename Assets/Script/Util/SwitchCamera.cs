using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SwitchCamera : MonoBehaviour
{

    public GameObject TirdPersonCamera;
    public GameObject FirstPersonCamera;
    public Image pannel;

    private PlayerController controller;


    float time = 0f;
    public float F_time = 1f;


    private void Start()
    {
        controller = CharacterManager.Instance.Player.controller;
        controller.PovChange += ViewPointSwitch;

    }

    void ViewPointSwitch()
    {

        Fade();

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

    public void Fade()
    {

        StartCoroutine(FadeScreen());
    
    }
    IEnumerator FadeScreen()
    {

        pannel.gameObject.SetActive(true);
        time = 0f;
        Color alpha = pannel.color;
        while (alpha.a < 1f)
        { 
        
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            pannel.color = alpha;
            yield return null;
        }

        time = 0f;

        yield return  new WaitForSeconds(F_time);

        while (alpha.a > 0f)
        {

            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(1, 0, time);
            pannel.color = alpha;
            yield return null;
        }

        pannel.gameObject.SetActive(false);
        yield return null;
    
    }


    

}
