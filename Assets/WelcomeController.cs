using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WelcomeController : MonoBehaviour
{
    [SerializeField] GameObject startButton, danielOelbaum, presents, hisPortfolio;
    CanvasGroup startCanvas, doCanvas, presentsCanvas, portfolioCanvas;

    private void Awake()
    {
        startCanvas = startButton.GetComponent<CanvasGroup>();
        doCanvas = danielOelbaum.GetComponent<CanvasGroup>();
        presentsCanvas = presents.GetComponent<CanvasGroup>();
        portfolioCanvas = hisPortfolio.GetComponent<CanvasGroup>();
        startCanvas.alpha = 0;
        doCanvas.alpha = 0;
        presentsCanvas.alpha = 0;
        portfolioCanvas.alpha = 0;
    }

    IEnumerator Start()
    {
        yield return new WaitForSeconds(2);
        LeanTween.alphaCanvas(doCanvas, 1, 1).setEase(LeanTweenType.easeInOutSine);   
        
        yield return new WaitForSeconds(2);

        LeanTween.alphaCanvas(presentsCanvas, 1, 1).setEase(LeanTweenType.easeInOutSine);

        yield return new WaitForSeconds(2);    
        
        LeanTween.alphaCanvas(portfolioCanvas, 1, 1).setEase(LeanTweenType.easeInOutSine);

        yield return new WaitForSeconds(2);

        LeanTween.alphaCanvas(startCanvas, 1, 1).setEase(LeanTweenType.easeInOutSine);

        yield return new WaitForSeconds(2);

        //danielOelbaum.GetComponent<Hover>().BeginHovering();
    }
}
