using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Client {
    public string First_Name;
    public string Last_Name;
    public string Company;
    public string Email;
    public string Phone;
    public Project[] allProjects;

    //ALL FUNCTIONS GO HERE...

    /// <summary>
    /// Gets the number of PROJECTS attributed to a client
    /// </summary>
    public int GetProjectCount()
    {
    	return allProjects.Length;
    }
}
