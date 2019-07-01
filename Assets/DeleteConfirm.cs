using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteConfirm : MonoBehaviour {

    public DBManager dbMan;

    private Client[] allClients;

    private Client client;
    private Project project;
    private Session session;

    public void setupDeleteRefs(int c, int p = -1, int s = -1)
    {
        allClients = dbMan.allClients;

        if(s >= 0)
        {
            client = allClients[c];
            project = client.allProjects[p];
            session = project.allSessions[s];
            Debug.Log("Client: " + c + ", Project:" + p + ", Session: " + s);
        }
        else if(p >= 0)
        {
            client = allClients[c];
            project = client.allProjects[p];
            Debug.Log("Client: " + c + ", Project: " + p);
        }
        else if (c >= 0)
        {
            client = allClients[c];
            Debug.Log("Client's Name: " + client.First_Name);
        }
    }

}
