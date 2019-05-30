using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Entry
{
    public DateTime startTime;
    public DateTime stopTime;

    //ALL FUNCTIONS GO HERE...

    ///summary
    ///Gets the absolute duration of an ENTRY
    ///summary
    public float GetDuration(string units = "seconds")
    {
        TimeSpan span = stopTime.Subtract(startTime);
        float dur = float.Parse(span.TotalSeconds.ToString());
        units = units.toLower();
        switch (units)
        {
        	case "minutes":
        	case "min":
        	case "m":
        		//put cude for minutes here.
        		break;
        	case "hours":
        	case "hr":
        	case "hrs":
        	case "h":
        		//put cude for hours here.
        		break;
        	case "days" :
        	case "d":
        		//put cude for days here.
        		break;
        	default:
        		//put code for seconds here.
        		break;

        }
        return dur;
    }
}
