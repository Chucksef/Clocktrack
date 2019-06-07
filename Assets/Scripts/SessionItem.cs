using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SessionItem : MonoBehaviour
{

    public Text sessionDate;
    public Text sessionTimeSpan;
    public Image sessionInvoiced;
    public Image sessionPaid;

    private Session session;

    public void SetupSession(Session currentSession)
    {
        session = currentSession;

        sessionDate.text = session.StartTime.Split( )[0];
        string start = session.StartTime.Split()[1];
        start = start.Substring(0, start.Length - 3);
        string end = session.StopTime.Split()[1];
        end = end.Substring(0, end.Length - 3);
        sessionTimeSpan.text = start + " " + session.StartTime.Split()[2].ToLower() + " - " + end + " " + session.StopTime.Split()[2].ToLower();
        sessionInvoiced.gameObject.SetActive(session.Invoiced);
        sessionPaid.gameObject.SetActive(session.Paid);
    }
}
