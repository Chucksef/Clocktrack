using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Project
{
    public string name;
    public float payRate;
    public Session[] allSessions;

    //ALL FUNCTIONS GO HERE...

    ///summary
    ///Gets the time spent working, in seconds, of all SESSIONS in a PROJECT that match the passed booleans: (invoiced, paid)
    ///summary
    public float GetPartialWorkTime(bool invoiced, bool paid)
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

    ///summary
    ///Gets the total time spent working, in seconds, of all SESSIONS in a PROJECT
    ///summary
    public float GetTotalWorkTime(){
        float twt = 0;
        twt += GetPartialWorkTime(false, false);
        twt += GetPartialWorkTime(false, true);
        twt += GetPartialWorkTime(true, false);
        twt += GetPartialWorkTime(true, true);
        return twt;
    }
}
