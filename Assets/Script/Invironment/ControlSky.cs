using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSky : MonoBehaviour
{

    public Material dayMat;
    public Material nightMat;


    [Header("Time")]
    [Range(0.0f, 1.0f),Tooltip("0.5면 정오")]
    public float time;
    public float dayLength;
    public float startTime = 0.4f;
    private float timeRate;

    public Vector3 noon;

    [Header("Sun")]
    public Light sun;
    public AnimationCurve sunIntensity;
    public Color dayFog;

    [Header("Moon")]
    public Light moon;
    public AnimationCurve moonIntensity;
    public Color nightFog;

    [Header("Other Lighting")]
    public AnimationCurve lightingIntensityMultiplier;
    public AnimationCurve reflectionIntensityMultiplier;


    private void Start()
    {
        timeRate = 1.0f / dayLength;
        time = startTime;
    }


    private void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * 0.5f);
        time = (time + timeRate * Time.deltaTime) % 1.0f;

        UpdateLight(sun, sunIntensity);
        UpdateLight(moon, moonIntensity);

        GameObject go = moon.gameObject;
        ChangeSkyMat(go);


        RenderSettings.ambientIntensity = lightingIntensityMultiplier.Evaluate(time);
        RenderSettings.reflectionIntensity = reflectionIntensityMultiplier.Evaluate(time);


    }


    void UpdateLight(Light lightSource, AnimationCurve intensityCurve)
    {

        float intensity = intensityCurve.Evaluate(time);

        //0.5가 정오 / 360도로 회전하므로 이때의 각은 180도, 태양은 수직 90도에 있어야 하므로 0.25만큼 더해 줌, 밤은 0.75 
        lightSource.transform.eulerAngles = (time - (lightSource == sun ? 0.25f : 0.75f)) * noon * 4.0f;

        lightSource.intensity = intensity;

        GameObject go = lightSource.gameObject;


        if (lightSource.intensity == 0 && go.activeInHierarchy)
        {
            go.SetActive(false);
        
        }
        else if (lightSource.intensity > 0 && !go.activeInHierarchy)
        {
            go.SetActive(true);

        }


    }

    public void ChangeSkyMat(GameObject go)
    {

        if (go.activeInHierarchy)
            RenderSettings.skybox = nightMat;
        else
            RenderSettings.skybox = dayMat;


    }

}
