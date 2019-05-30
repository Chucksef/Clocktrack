using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Session : Entry
{
    public bool invoiced;
    public bool paid;
    public string notes;

    public Entry[] allBreaks;

    //ALL FUNCTIONS GO HERE...

    ///summary
    ///Gets the total time, in seconds, of all the breaks taken during a Session
    ///summary
    public float GetTotalBreakTime()
    {
        float bt = 0f;
        if (allBreaks.Length > 0)
        {
            for (int i = 0; i < allBreaks.Length; i++)
            {
                bt += allBreaks[i].GetDuration();
            }
        }
        return bt;
    }

    ///summary
    ///Gets the time spent working, in seconds, during a Session
    ///summary
    public float GetWorkTime()
    {
        float wt = GetDuration() - GetBreakTime();
        return wt;
    }
}
