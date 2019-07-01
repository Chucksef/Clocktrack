using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class DBManager : MonoBehaviour {

    [Header("Panels and Objects")]
    public GameObject readout;
    public Dropdown clientDropdown;
    public Dropdown projectDropdown;

    [Header("DB Objects")]
    public List<Client> clientList;

    public SimpleObjectPool clientPool;
    public SimpleObjectPool projectPool;
    public SimpleObjectPool sessionPool;

    public Client[] allClients;
    public ClientDatabase clientDatabase;

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
                clientDatabase = JsonUtility.FromJson<ClientDatabase>(readData);
                allClients = clientDatabase.allClients;

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
                clientDatabase = JsonUtility.FromJson<ClientDatabase>(readData);
                allClients = clientDatabase.allClients;

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

    private void SaveGameData()
    {

        string dataAsJson = JsonUtility.ToJson(clientDatabase);
        string filePath = Path.Combine(Application.streamingAssetsPath, fileName);
        File.WriteAllText(filePath, dataAsJson);

        if (Application.platform == RuntimePlatform.Android)
        {
            WWW writer = new WWW(filePath);
            while (!writer.isDone) { }
            var androidPath = Application.persistentDataPath;
            File.WriteAllText(androidPath + "data.json", dataAsJson);
        }
        else
        {
            if (File.Exists(filePath))
            {
                File.WriteAllText(filePath, dataAsJson);
            }
            else
            {
                Debug.LogError("No Database File Found!");
            }
        }
    }

    public void RefreshDisplay()
    {
        if (projectDropdown.value > 0)
        {
            PopulateSessionList(clientDropdown.value -1, projectDropdown.value -1);
        }
        else if (clientDropdown.value > 0)
        {
            PopulateProjectList(clientDropdown.value - 1);
        }
        else
        {
            PopulateClientList();
        }

    }

    public void ReloadAndReset()
    {
        LoadData();
        clientDropdown.value = 0;
        projectDropdown.value = 0;
        RefreshDisplay();
    }

    public void AddClient(Client newClient)
    {
        List<Client> newClientList = new List<Client>();
        foreach (Client item in clientDatabase.allClients)
        {
            newClientList.Add(item);
        }
        newClientList.Add(newClient);

        clientDatabase.allClients = newClientList.ToArray();
        SaveGameData();
        ReloadAndReset();
    }

    public void AddProject(Project newProject, int clientIdx)
    {
        List<Project> newProjectList = new List<Project>();
        foreach (Project item in clientDatabase.allClients[clientIdx].allProjects)
        {
            newProjectList.Add(item);
        }
        newProjectList.Add(newProject);

        clientDatabase.allClients[clientIdx].allProjects = newProjectList.ToArray();
        Debug.Log(clientDatabase.allClients[clientIdx].allProjects.ToString());
        SaveGameData();
        ReloadAndReset();
    }

    public void RemoveClient(int clientIdx)
    {

    }

    public void RemoveProject(int clientIdx, int projectIdx)
    {

    } 

    public void RemoveSession(int clientIdx, int projectIdx, int sessionIdx)
    {

    }

    private void DestroyReadoutChildren()
    {
        foreach(Transform child in readout.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
	
    private void PopulateClientList()
    {
        DestroyReadoutChildren();
        for (int i = 0; i < clientList.Count; i++)
        {
            Client client = clientList[i];

            GameObject newClient = clientPool.GetObject();
            newClient.transform.SetParent(readout.transform, false);

            ClientItem clientItem = newClient.GetComponent<ClientItem>();
            clientItem.SetupClient(client, i);
        }
    }

    private void PopulateProjectList(int clientID)
    {
        DestroyReadoutChildren();
        Client client = clientList[clientID]; //
        for (int i = 0; i < client.allProjects.Length; i++)
        {
            Project project = client.allProjects[i];
            GameObject newProject = projectPool.GetObject();
            newProject.transform.SetParent(readout.transform, false);

            ProjectItem projectItem = newProject.GetComponent<ProjectItem>();
            projectItem.SetupProject(project, clientID, i);

        }
    }

    private void PopulateSessionList(int clientID, int projectID)
    {
        DestroyReadoutChildren();
        Project project = clientList[clientID].allProjects[projectID];
        for (int i = 0; i < project.allSessions.Length; i++)
        {
            Session session = project.allSessions[i];
            GameObject newSession = sessionPool.GetObject();
            newSession.transform.SetParent(readout.transform, false);

            SessionItem sessionItem = newSession.GetComponent<SessionItem>();
            sessionItem.SetupSession(session, clientID, projectID, i);

        }
    }


}
