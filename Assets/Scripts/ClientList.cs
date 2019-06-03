using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class ClientList : MonoBehaviour {

    public List<Client> clientList;
    public SimpleObjectPool clientPool;

    private Client[] allClients;
    private string fileName = "data.json";

	// Use this for initialization
	void Start ()
    {
        LoadData();
        RefreshDisplay();
	}

    private void LoadData()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, fileName);
        string readData;

        if (Application.platform == RuntimePlatform.Android)
        {
            WWW reader = new WWW(filePath);
            while (!reader.isDone) { }
            readData = reader.text;

            if (readData != "")
            {
                ClientDatabase loadedData = JsonUtility.FromJson<ClientDatabase>(readData);
                allClients = loadedData.allClients;

                clientList.Clear();
                for (int i = 0; i < allClients.Length; i++)
                {
                    clientList.Add(allClients[i]);
                }
            }
        }
        else
        {
            if (File.Exists(filePath))
            {
                readData = File.ReadAllText(filePath);
                ClientDatabase loadedData = JsonUtility.FromJson<ClientDatabase>(readData);
                allClients = loadedData.allClients;

                clientList.Clear();
                for (int i = 0; i < allClients.Length; i++)
                {
                    clientList.Add(allClients[i]);
                }
            }
            else
            {
                Debug.LogError("No Database File Found!");
            }
        }
    }

    public void RefreshDisplay()
    {
        AddClients();
    }
	
    private void AddClients()
    {
        for (int i = 0; i < clientList.Count; i++)
        {
            Client client = clientList[i];
            GameObject newClient = clientPool.GetObject();
            newClient.transform.SetParent(gameObject.transform, false);

            ClientItem clientItem = newClient.GetComponent<ClientItem>();
            clientItem.Setup(client, this);
            
        }
    }

}
