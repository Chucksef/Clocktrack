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
    private ClientList clientList;
    
    void Start()
    {

    }

    public void Setup(Client currentClient, ClientList currentClientList)
    {
        client = currentClient;
        clientName.text = client.First_Name + " " + client.Last_Name;
        totalProjects.text = client.GetProjectCount().ToString();

        float allTime = 0f;
        for (int i = 0; i < client.allProjects.Length; i++)
        {
            allTime += client.allProjects[i].GetTotalWorkTime();
        }

        totalTime.text = allTime.ToString();

        clientList = currentClientList;


    }
}
