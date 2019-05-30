using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Project
{
    public string name;
    public float payRate;
    public Session[] allSessions;
    public float GetAllWorkTime(bool billed = false, bool paid = false)
    {
        float awt = 0f;
        if (allSessions.Length > 0)
        {
            if (billed == false && paid == false)
            {
                for (int i = 0; i < allSessions.Length; i++)
                {
                    awt += allSessions[i].GetWorkTime();
                }
            }
            else if (billed == true && paid == false)
            {

            }
    }
                return awt;


    }
}
