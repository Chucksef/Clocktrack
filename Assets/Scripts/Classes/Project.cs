using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Project
{
    public string Name;
    public float PayRate;
    public Session[] allSessions;

    //ALL FUNCTIONS GO HERE...

    /// <summary>
    /// Gets the time spent working, in seconds, of all SESSIONS in a PROJECT that match the passed booleans: (invoiced, paid)
    /// </summary>
    /// <returns></returns>
    public float GetPartialWorkTime(bool invoiced, bool paid)
    {
        float pwt = 0f;
        if (allSessions.Length > 0)
        {
            for (int i = 0; i < allSessions.Length; i++)
            {
                if (allSessions[i].Invoiced == invoiced && allSessions[i].Paid == paid)
                {
                    pwt += allSessions[i].GetWorkTime();
                }
            }
        }
        return pwt;
    }

    /// <summary>
    /// Gets the total time spent working, in seconds, of all SESSIONS in a PROJECT
    /// </summary>
    /// <returns></returns>
    public float GetTotalWorkTime(){
        float twt = 0;
        twt += GetPartialWorkTime(false, false);
        twt += GetPartialWorkTime(false, true);
        twt += GetPartialWorkTime(true, false);
        twt += GetPartialWorkTime(true, true);
        return twt;
    }
}
