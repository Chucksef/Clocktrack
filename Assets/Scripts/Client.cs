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
    public int GetProjectCount()
    {
    	return allProjects.Length;
    }
}
