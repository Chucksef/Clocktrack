using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class UIAnimator : MonoBehaviour
{

    //ALL PUBLIC VARIABLES HERE
    [Header("Main Canvas")]
    public Canvas cv;

    [Header("Main Panels")]
    public GameObject panel_MainMenu;
    public GameObject panel_SessionRecorder;
    public GameObject panel_DatabaseViewer;
    public GameObject panel_DatabaseManager;
    public GameObject panel_DateTimeEnter;


    [SerializeField]
    private GameObject[] rightPanels;
    [SerializeField]
    private GameObject[] bottomPanels;
    [SerializeField]
    private GameObject[] leftPanels;
    [SerializeField]
    private GameObject[] topPanels;

    [Header("Timing Values")]
    [Range(.1f, 1.25f)]
    public float animTime = .25f;
    [Range(.1f, 2.5f)]
    public float warnTime = 1.25f;

    [Header("Animation Curves")]
    public AnimationCurve easeAccel = AnimationCurve.Linear(0.0f, 0.0f, 1.0f, 1.0f);
    public AnimationCurve easeDecel = AnimationCurve.Linear(0.0f, 0.0f, 1.0f, 1.0f);

    [Header("Object Template")]
    public GameObject objectTemplate;

    Color warnColor = new Color(1, 0.2980392f, 0.2980392f);
    Color normalColor = new Color(1f, 1f, 1f);

    [Header("Warn Colorblock")]
    ColorBlock warnCB = new ColorBlock();
    ColorBlock goodCB = new ColorBlock();
    ColorBlock selectedCB = new ColorBlock();

    private float tempTime;


    //runs at start
    void Start()
    {
        panel_MainMenu.transform.localPosition = new Vector2(0, 0);

        //These lines store new colorblock data into goodCB and warnCB
        goodCB = objectTemplate.GetComponent<InputField>().colors; //both based on existing colorblock...
        selectedCB = goodCB;
        selectedCB.normalColor = normalColor;
        selectedCB.fadeDuration = 0f;
        selectedCB.highlightedColor = normalColor;
        selectedCB.disabledColor = normalColor;
        warnCB = goodCB;
        warnCB.normalColor = warnColor;
        warnCB.fadeDuration = 0f;
        warnCB.highlightedColor = warnColor;
        warnCB.disabledColor = warnColor;

        StartCoroutine(DelayedPositionOnLaunch());
    }


    public IEnumerator DelayedPositionOnLaunch()
    {
        yield return new WaitForSeconds(0.1f);
        //Wait, then put everythign in position.
        for (int i = 0; i < rightPanels.Length; i++)
        {
            StartCoroutine(FlyOut(rightPanels[i].GetComponent<RectTransform>(), "right", 0f));
        }
        for(int i = 0; i < bottomPanels.Length; i++)
        {
            StartCoroutine(FlyOut(bottomPanels[i].GetComponent<RectTransform>(), "down", 0f));
        }
        for (int i = 0; i < leftPanels.Length; i++)
        {
            StartCoroutine(FlyOut(leftPanels[i].GetComponent<RectTransform>(), "left", 0f));
        }
        for (int i = 0; i < topPanels.Length; i++)
        {
            StartCoroutine(FlyOut(topPanels[i].GetComponent<RectTransform>(), "top", 0f));
        }
    }

    /// <summary>
    /// Animates RectTransform from its current Position to specified coordinates (endPos)
    /// </summary>
    /// <param name="rt">The RectTransform to be animated</param>
    /// <param name="endPos">A Vector2 that contains the coordinates where the rt should finish animating</param>
    /// <param name="delay">A Float, in seconds, before the start of this animation</param>
    /// <returns></returns>
    public IEnumerator FlyIn(RectTransform rt, Vector2 endPos, float delay)
    {
        Vector2 startPos = rt.localPosition;
        if (delay > 0)
        {
            yield return new WaitForSeconds(delay);                                     //delays based on float
        }
        rt.gameObject.SetActive(true);
        for (float i = 0f; i < animTime; i = i + Time.deltaTime)
        {
            var timePCT = i / animTime;
            Vector2 currentPos = new Vector2(Mathf.Lerp(startPos.x, endPos.x, easeDecel.Evaluate(timePCT)), Mathf.Lerp(startPos.y, endPos.y, easeDecel.Evaluate(timePCT)));
            rt.localPosition = new Vector2(currentPos.x, currentPos.y);
            yield return null;
        }
        rt.localPosition = endPos;
    }

    /// <summary>
    /// Animates RectTransform from its current position to out of screen in whichever direction specified.
    /// </summary>
    /// <param name="rt">The RectTransform to be animated</param>
    /// <param name="dir">A string direction ("up", "right", "top", "south", etc...) the rt should move</param>
    /// <returns></returns>
    public IEnumerator FlyOut(RectTransform rt, string dir, float custTime = -1f)
    {
        //RectTransform objects to store the transforms of the main panel
        var rt_main = cv.GetComponent<RectTransform>();

        var rect_this = RectTransformUtility.PixelAdjustRect(rt, cv);                           //Rect object to store rt's height and width
        var rect_main = RectTransformUtility.PixelAdjustRect(rt_main, cv);                      //Rect object to store main panel's height and width

        Vector2 startPos = rt.localPosition;                                                    //Start Position is defined as where the panel starts
        Vector2 endPos;                                                                         //declares variable to set later

        dir = dir.ToLower();

        //Some math to figure out the rightPos (offscreen)
        switch (dir)
        {
            case "up":
            case "top":
            case "north":
                endPos.x = 0f;
                endPos.y = rect_main.height + (rect_this.height - rect_main.height) / 2;
                break;

            case "right":
            case "east":
                endPos.x = rect_main.width + (rect_this.width - rect_main.width) / 2;
                endPos.y = 0f;
                break;

            case "down":
            case "bottom":
            case "south":
                endPos.x = 0f;
                endPos.y = -(rect_main.height + (rect_this.height - rect_main.height) / 2);
                break;

            case "left":
            case "west":
                endPos.x = -(rect_main.width + (rect_this.width - rect_main.width) / 2);
                endPos.y = 0f;
                break;

            default:
                endPos.x = 5000f;
                endPos.y = 5000f;
                Debug.LogError("FlyOut(): No Valid Direction Declared");
                break;
        }
        if(custTime >= 0)
        {
            tempTime  = custTime + .00001f;
        }
        else
        {
            tempTime = animTime;
        }

        for (float i = 0f; i < tempTime; i = i + Time.deltaTime)
        {
            var timePCT = i / tempTime;
            Vector2 currentPos = new Vector2(Mathf.Lerp(startPos.x, endPos.x, easeAccel.Evaluate(timePCT)), Mathf.Lerp(startPos.y, endPos.y, easeAccel.Evaluate(timePCT)));
            rt.localPosition = new Vector2(currentPos.x, currentPos.y);
            yield return null;
        }

        rt.localPosition = endPos;
        rt.gameObject.SetActive(false);
        
    }

    /// <summary>
    /// Makes a GameObject flash the warning color briefly
    /// </summary>
    /// <param name="thisInput">The GameObject to flash</param>
    /// <returns></returns>
    public IEnumerator FlashWarningColor(GameObject thisInput)
    {
        var sel = thisInput.GetComponent<Selectable>();
        var lastCalcTime = Time.time;
        sel.colors = warnCB; //sets sel's colorblock to be equivalent to the warnCB
        var tempCB = goodCB;
        tempCB.fadeDuration = warnTime;
        sel.colors = tempCB;
        yield return new WaitForSeconds(warnTime);
        if (lastCalcTime + warnTime >= Time.time)
        {
            sel.colors = goodCB;
        }
    }

    /// <summary>
    /// Moves a Panel to its starting position
    /// </summary>
    /// <param name="thisPanel"></param>
    private void StartPosition(GameObject thisPanel)
    {
        //The following code places the passed game-object panel at the right-outside edge of the frame, centered vertically.
        //RectTransform objects to store the transforms of the 2 panels
        var thisRT = thisPanel.GetComponent<RectTransform>();
        var rt_cv = cv.GetComponent<RectTransform>();

        //Rect objects to store the width/height of the 2 panels
        var rect_results = RectTransformUtility.PixelAdjustRect(thisRT, cv);
        var rect_main = RectTransformUtility.PixelAdjustRect(rt_cv, cv);

        //Some math to figure out the rightPos (offscreen)
        var rightPos = rect_main.width + (rect_results.width - rect_main.width) / 2;
        thisRT.localPosition = new Vector3(rightPos, 0, 0);
        thisPanel.SetActive(false);
    }
}
