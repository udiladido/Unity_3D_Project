using System.Collections;
using UnityEngine;


public class ClockingEffect : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Material[] mtrlOrg;  // Material �迭�� ����
    [SerializeField] private Material mtrlDissolve;
    [SerializeField] private Material mtrlPhase;
    [SerializeField] private float fadeTime = 2f;
    [SerializeField] private float holdTime;

    private Material[] originalMaterials;  // ���� ���� �����


    void Start()
    {
        // ������ �� ���� ������ ����
        originalMaterials = _renderer.materials;  // materials(������) ���
        
    }


    public void DissolveStart(float DurationTime)
    {

        holdTime = DurationTime;

        // ��� ������ mtrlDissolve�� ����
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

            // ��� ������ mtrlPhase�� ����
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

            // ��� ������ ���� �� ����
            Material[] currentMaterials = _renderer.materials;
            for (int i = 0; i < currentMaterials.Length; i++)
            {
                currentMaterials[i].SetFloat("_SpiltValue", currentValue);
            }

            yield return null;
        }

        // ��� ������ ���� ���� �� ����
        Material[] finalMaterials = _renderer.materials;
        for (int i = 0; i < finalMaterials.Length; i++)
        {
            finalMaterials[i].SetFloat("_SpiltValue", end);
        }

        yield return new WaitForSeconds(holdTime);

        // ���� ������ ����
        _renderer.materials = originalMaterials;
    }
}