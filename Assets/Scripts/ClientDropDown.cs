using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClientDropDown : MonoBehaviour {

    public DBManager clientList;
    public Dropdown dd_Projects;
    public Button button_Projects;

    private List<string> clientNames;
    private List<string> projectNames;

    private Dropdown dd;

	// Use this for initialization
	void Start () {
        dd = gameObject.GetComponent<Dropdown>();
	}
	
	public void RefreshDropdownContents()
    {
        //clears out the clientNames List, then the dropdown options
        clientNames = new List<string> { "All Clients" };
        dd.ClearOptions();

        var allClients = clientList.allClients;

        for (int i = 0; i < allClients.Length; i++)
        {
            string name = allClients[i].First_Name + " " + allClients[i].Last_Name;
            clientNames.Add(name);
        }
        dd.AddOptions(clientNames);

    }

    public void CheckIfClientSelected()
    {
        dd_Projects.value = 0;
        if (dd.value > 0)
        {
            projectNames = new List<string> { "All Projects" };
            dd_Projects.ClearOptions();

            var allProjects = clientList.allClients[dd.value - 1].allProjects;

            for (int i = 0; i < allProjects.Length; i++)
            {
                string project = allProjects[i].Name;
                projectNames.Add(project);
            }

            dd_Projects.AddOptions(projectNames);
            dd_Projects.interactable = true;
            button_Projects.interactable = true;

            clientList.RefreshDisplay();
        }
        else
        {
            //insert code here to update the scrollview to only include client names
            dd_Projects.interactable = false;
            button_Projects.interactable = false;
            clientList.RefreshDisplay();
        }
    }
}
