using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {

    public UIAnimator uiAnimator;

	// Use this for initialization
	void Start () {
        Screen.fullScreen = false;
	}

    public void FlyIn(GameObject showMe)
    {
        StartCoroutine(uiAnimator.FlyIn(showMe.GetComponent<RectTransform>(), new Vector2(0, 0), 0f));
    }

    public void FlyOutRight(GameObject hideMe)
    {
        StartCoroutine(uiAnimator.FlyOut(hideMe.GetComponent<RectTransform>(), "right"));
    }
    public void FlyOutTop(GameObject hideMe)
    {
        StartCoroutine(uiAnimator.FlyOut(hideMe.GetComponent<RectTransform>(), "top"));
    }
    public void FlyOutBottom(GameObject hideMe)
    {
        StartCoroutine(uiAnimator.FlyOut(hideMe.GetComponent<RectTransform>(), "bottom"));
    }
    public void FlyOutLeft(GameObject hideMe)
    {
        StartCoroutine(uiAnimator.FlyOut(hideMe.GetComponent<RectTransform>(), "left"));
    }

    public void Quit()
    {
        Application.Quit();
    }
}
