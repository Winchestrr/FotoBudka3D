using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CustomButton : MonoBehaviour
{
    public CanvasGroup bgdAlpha;

    public float fadeSpeed;

    private void Start()
    {
        bgdAlpha = gameObject.GetComponent<CanvasGroup>();
    }

    public void FadeIn()
    {
        StopAllCoroutines();
        StartCoroutine(FadeInIE());
    }

    public void FadeOut()
    {
        StopAllCoroutines();
        StartCoroutine(FadeOutIE());
    }

    IEnumerator FadeInIE()
    {
        bgdAlpha.alpha = Mathf.Lerp(bgdAlpha.alpha, 1, fadeSpeed * Time.deltaTime);

        if(bgdAlpha.alpha >= 0.95f)
        {
            bgdAlpha.alpha = 1;
            yield return new WaitForEndOfFrame();
        }
        else
        {
            yield return new WaitForEndOfFrame();
            StartCoroutine(FadeInIE());
        }
    }

    IEnumerator FadeOutIE()
    {
        bgdAlpha.alpha = Mathf.Lerp(bgdAlpha.alpha, 0, fadeSpeed * Time.deltaTime);

        if (bgdAlpha.alpha <= 0.05f)
        {
            bgdAlpha.alpha = 0;
            yield return new WaitForEndOfFrame();
        }
        else
        {
            yield return new WaitForEndOfFrame();
            StartCoroutine(FadeOutIE());
        }
    }
}
