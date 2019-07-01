using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ClientItem : MonoBehaviour {

    public Text clientName;
    public Text totalProjects;
    public Text totalTime;

    private Client client;
    public int clientIndex;

    public void SetupClient(Client currentClient, int c)
    {
        clientIndex = c;
        client = currentClient;
        clientName.text = client.First_Name + " " + client.Last_Name;
        totalProjects.text = "Projects: "+client.GetProjectCount().ToString();

        float allTime = 0f;
        for (int i = 0; i < client.allProjects.Length; i++)
        {
            allTime += client.allProjects[i].GetTotalWorkTime();
        }

        totalTime.text = "Hours: "+(Mathf.Round((allTime/3600)*100)/100).ToString();
    }
}
