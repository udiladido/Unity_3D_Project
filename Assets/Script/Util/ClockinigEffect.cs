using System.Collections;
using UnityEngine;


public class ClockingEffect : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Material[] mtrlOrg;  // Material 배열로 변경
    [SerializeField] private Material mtrlDissolve;
    [SerializeField] private Material mtrlPhase;
    [SerializeField] private float fadeTime = 2f;
    [SerializeField] private float holdTime;

    private Material[] originalMaterials;  // 원본 재질 저장용


    void Start()
    {
        // 시작할 때 현재 재질들 저장
        originalMaterials = _renderer.materials;  // materials(복수형) 사용
        
    }


    public void DissolveStart(float DurationTime)
    {

        holdTime = DurationTime;

        // 모든 재질을 mtrlDissolve로 변경
        Material[] newMaterials = new Material[originalMaterials.Length];
        for (int i = 0; i < newMaterials.Length; i++)
        {
            newMaterials[i] = mtrlDissolve;
        }
        _renderer.materials = newMaterials;

        StartCoroutine(DoFade(0, 1, fadeTime));

    }

    public void PhaseStart(float fadeTime)
    {

            // 모든 재질을 mtrlPhase로 변경
            Material[] newMaterials = new Material[originalMaterials.Length];
            for (int i = 0; i < newMaterials.Length; i++)
            {
                newMaterials[i] = mtrlPhase;
            }
            _renderer.materials = newMaterials;

            StartCoroutine(DoFade(0, 2, fadeTime));

    }


    IEnumerator DoFade(float start, float end, float duration)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float normalizedTime = elapsed / duration;

            float value;
            if (normalizedTime < 0.5f)
            {
                value = 4 * normalizedTime * normalizedTime * normalizedTime;
            }
            else
            {
                normalizedTime = 1 - normalizedTime;
                value = 1 - 4 * normalizedTime * normalizedTime * normalizedTime;
            }

            float currentValue = Mathf.Lerp(start, end, value);

            // 모든 재질에 대해 값 설정
            Material[] currentMaterials = _renderer.materials;
            for (int i = 0; i < currentMaterials.Length; i++)
            {
                currentMaterials[i].SetFloat("_SpiltValue", currentValue);
            }

            yield return null;
        }

        // 모든 재질에 대해 최종 값 설정
        Material[] finalMaterials = _renderer.materials;
        for (int i = 0; i < finalMaterials.Length; i++)
        {
            finalMaterials[i].SetFloat("_SpiltValue", end);
        }

        yield return new WaitForSeconds(holdTime);

        // 원본 재질로 복구
        _renderer.materials = originalMaterials;
    }
}