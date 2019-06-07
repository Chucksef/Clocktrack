using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddProjectButton : MonoBehaviour
{

    public DBManager dbMan;
    public UIAnimator uiAnim;

    public InputField projectName;
    public InputField hourlyRate;

    public List<GameObject> inputs;

    public Dropdown clientDD;

    private void Start()
    {
        inputs.Add(projectName.gameObject);
        inputs.Add(hourlyRate.gameObject);
    }

    public void SendInfoToDB()
    {
        bool sendable = true;
        foreach (GameObject go in inputs)
        {
            if (go.GetComponent<InputField>().text == "")
            {
                StartCoroutine(uiAnim.FlashWarningColor(go));
                sendable = false;
            }
        }

        Debug.Log("sendable: " + sendable);
        if (sendable)
        {
            //build the client
            Project newProject = new Project();

            newProject.Name = projectName.text;
            newProject.PayRate = float.Parse(hourlyRate.text);

            //Send the data to the database
            dbMan.AddProject(newProject, clientDD.value-1);

            //Return to last screen
            StartCoroutine(uiAnim.FlyOut(gameObject.transform.parent.parent.gameObject.GetComponent<RectTransform>(), "right"));


        }
    }

}
