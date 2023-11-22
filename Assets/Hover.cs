using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hover : MonoBehaviour
{
    [SerializeField] float hoverTime = 1;
    [SerializeField] float distance = 1;
    [SerializeField] LeanTweenType tweenType = LeanTweenType.easeInOutSine;
    [SerializeField] bool hoverOnStart = false;
    float initialY;

    private void Start()
    {
        if (hoverOnStart) BeginHovering();
    }

    public void BeginHovering()
    {
        initialY = transform.localPosition.y;
        LeanTween.moveLocalY(gameObject, initialY + (distance/2), hoverTime/2).setEase(tweenType).setOnComplete(HoverDown);
    }

    void HoverDown()
    {
        LeanTween.moveLocalY(gameObject, transform.localPosition.y - distance, hoverTime).setEase(tweenType).setOnComplete(HoverUp);
    }

    private void HoverUp()
    {
        LeanTween.moveLocalY(gameObject, transform.localPosition.y + distance, hoverTime).setEase(tweenType).setOnComplete(HoverDown);
    }
}
