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

    public void FlyOut(GameObject hideMe)
    {
        StartCoroutine(uiAnimator.FlyOut(hideMe.GetComponent<RectTransform>(), "right"));
    }

    public void Quit()
    {
        Application.Quit();
    }
}
