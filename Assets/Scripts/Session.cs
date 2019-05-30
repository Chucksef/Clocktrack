using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Session : Entry
{
    public bool invoiced;
    public bool paid;
    public string notes;

    public Entry[] allBreaks;

    public float GetBreakTime()
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

    public float GetWorkTime()
    {
        float wt = GetDuration() - GetBreakTime();
        return wt;
    }
}
