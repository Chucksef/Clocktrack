using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Client {
    public string FirstName;
    public string LastName;
    public string Company;
    public string Email;
    public string Phone;
    public Project[] allProjects;

    //ALL FUNCTIONS GO HERE...

    ///summary
    ///Gets the number of PROJECTS attributed to a client
    ///summary
    public int GetProjectCount()
    {
    	return allProjects.Length + 1;
    }
}
