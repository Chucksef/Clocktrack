using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class Entry
{
    public string StartTime;
    public string StopTime;

    //ALL FUNCTIONS GO HERE...

    /// <summary>
    /// Gets the absolute duration of an ENTRY
    /// </summary>
    public int GetDuration(string units = "seconds")
    {
        TimeSpan span = System.Convert.ToDateTime(StopTime).Subtract(System.Convert.ToDateTime(StartTime));
        int dur = int.Parse(span.TotalSeconds.ToString());
        units = units.ToLower();
        switch (units)
        {
        	case "minutes":
        	case "min":
        	case "m":
        		//put code for minutes here.
        		break;
        	case "hours":
        	case "hr":
        	case "hrs":
        	case "h":
        		//put code for hours here.
        		break;
        	case "days" :
        	case "d":
        		//put code for days here.
        		break;
        	default:
        		//put code for seconds here.
        		break;

        }
        return dur;
    }
}
