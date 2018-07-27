using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderWaterEffect : MonoBehaviour {
    
    public Material underwaterView;
    public float transitionTime;

    IEnumerator currentFadeValueCoroutine;

    float noiseFrequency;
    float noiseScale;
    float noiseSpeed;

    private void OnEnable()
    {
        underwaterView.SetFloat("_NoiseScale", 0);
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, underwaterView);
    }

    public void SwitchUnderwaterView (float targetValue)
    {
        if (currentFadeValueCoroutine != null)
        {
            StopCoroutine(currentFadeValueCoroutine);
        }

        currentFadeValueCoroutine = FadeValue(underwaterView.GetFloat("_NoiseScale"),targetValue, "_NoiseScale");
        StartCoroutine(currentFadeValueCoroutine);
    }

    public IEnumerator FadeValue (float currentValue, float targetValue, string propertyName)
    {

        float timer = 0.0f;

        while (timer < transitionTime)
        {
            timer += Time.deltaTime;
            float percent = Mathf.Clamp01(timer / transitionTime);

            currentValue = Mathf.Lerp(currentValue, targetValue, percent);
            underwaterView.SetFloat(propertyName, currentValue);
            //Debug.Log(currentValue);

            yield return null;
        }

    }

   
}
