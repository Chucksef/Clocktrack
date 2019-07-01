using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class LongClickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool pointerDown;
    private float pointerDownTimer;

    private GameObject can;
    private GameObject panel_DeleteConfirm;
    private Transform panel_PopupBackground;
    private UIAnimator uiAnimator;
    private DeleteConfirm delcon;
    private ClientItem client;
    private ProjectItem project;
    private SessionItem session;

    [SerializeField]
    private float requiredHoldTime;

    [SerializeField]
    private Image fillImage;

    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Reset();
    }

    public void Reset()
    {
        pointerDown = false;
        pointerDownTimer = 0;
        fillImage.fillAmount = 0;
    }

    private void Start()
    {
        can = GameObject.Find("Canvas");
        panel_DeleteConfirm = can.transform.GetChild(7).gameObject;
        panel_PopupBackground = can.transform.GetChild(6);
        delcon = panel_DeleteConfirm.GetComponent<DeleteConfirm>();
        uiAnimator = GameObject.Find("UIAnimator").GetComponent<UIAnimator>();
    }

    private void Update()
    {
        if (pointerDown)
        {
            pointerDownTimer += Time.deltaTime;
            if(pointerDownTimer >= requiredHoldTime)
            {
                Reset();
                panel_PopupBackground.gameObject.SetActive(true);
                StartCoroutine(uiAnimator.FlyIn(panel_DeleteConfirm.GetComponent<RectTransform>(), new Vector2(0,0),0f));
                SendData();
            }
            fillImage.fillAmount = pointerDownTimer / requiredHoldTime;
        }
    }

    private void SendData()
    {
        session = gameObject.GetComponent<SessionItem>();
        if(session == null)
        {
            project = gameObject.GetComponent<ProjectItem>();
            if (project == null)
            {
                client = gameObject.GetComponent<ClientItem>();
                if(client == null)
                {
                    Debug.LogError("NO CLIENT DATA PRESENT");
                }
                else
                {
                    int clientIndex = client.clientIndex;
                    delcon.setupDeleteRefs(client.clientIndex);
                }
            }
            else
            {
                int projectIndex = project.projectIndex;
                int clientIndex = project.clientIndex;
                delcon.setupDeleteRefs(project.clientIndex, project.projectIndex);
            }
        }
        else
        {
            int sessionIndex = session.sessionIndex;
            int projectIndex = session.projectIndex;
            int clientIndex = session.clientIndex;
            delcon.setupDeleteRefs(session.clientIndex, session.projectIndex, session.sessionIndex);
        }

    }

}