using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Project
{
    public string name;
    public float payRate;
    public Session[] allSessions;
    public float GetPartialWorkTime(bool invoiced = false, bool paid = false)
    {
        float pwt = 0f;
        if (allSessions.Length > 0)
        {
            for (int i = 0; i < allSessions.Length; i++)
            {
                if (allSessions[i].invoiced == invoiced && allSessions[i].paid == paid)
                {
                    pwt += allSessions[i].GetWorkTime();
                }
            }
        }
        return pwt;
    }
    public float GetTotalWorkTime(){
        float twt = 0;
        twt += GetPartialWorkTime(false, false);
        twt += GetPartialWorkTime(false, true);
        twt += GetPartialWorkTime(true, false);
        twt += GetPartialWorkTime(true, true);
        return twt;
    }
}
