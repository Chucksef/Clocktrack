using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Entry
{
    public DateTime startTime;
    public DateTime stopTime;
    public float GetDuration()
    {
        TimeSpan span = stopTime.Subtract(startTime);
        float dur = float.Parse(span.TotalSeconds.ToString());
        return dur;
    }
}
