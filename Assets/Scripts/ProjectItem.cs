using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ProjectItem : MonoBehaviour {

    public Text projectName;
    public Text projectRate;
    public Text projectSessions;
    public Text projectHours;

    private Project project;
    public int clientIndex;
    public int projectIndex;

    public void SetupProject(Project currentProject, int c, int p)
    {
        clientIndex = c;
        projectIndex = p;

        project = currentProject;
        projectName.text = project.Name;
        projectRate.text = "Rate: $" + (Mathf.Round(project.PayRate * 100)/100) + "/hr";
        projectSessions.text = "Sessions: " + (project.allSessions.Length);
        projectHours.text = "Hours: " + Mathf.Round((project.GetTotalWorkTime()/36))/100;
    }
}
