using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class FadeIn : MonoBehaviour
{
    [SerializeField] CanvasGroup group;
    [SerializeField] float fadeTime;
    [SerializeField] LeanTweenType tweenType = LeanTweenType.easeInOutSine;
    [SerializeField] UnityEvent OnComplete;
    [SerializeField] bool FadeInOnStart;
    private void Awake()
    {
        group.alpha = 0;
    }

    void Start()
    {
        if (FadeInOnStart) BeginFadeIn(); ;
    }

    public void BeginFadeIn()
    {
        LeanTween.alphaCanvas(group, 1, fadeTime).setEase(tweenType).setOnComplete(() => { if (OnComplete != null) OnComplete.Invoke(); });
    }
}
