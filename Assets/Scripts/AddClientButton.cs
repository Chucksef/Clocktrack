using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddClientButton : MonoBehaviour {

    public DBManager dbMan;
    public UIAnimator uiAnim;

    public InputField first;
    public InputField last;
    public InputField company;
    public InputField email;
    public InputField phone;

    public List<GameObject> inputs;

    private void Start()
    {
        inputs.Add(first.gameObject);
        inputs.Add(last.gameObject);
        inputs.Add(company.gameObject);
        inputs.Add(email.gameObject);
        inputs.Add(phone.gameObject);
    }

    public void SendInfoToDB()
    {
        bool sendable = true;
        foreach (GameObject go in inputs)
        {
            if(go.GetComponent<InputField>().text == "")
            {
                StartCoroutine(uiAnim.FlashWarningColor(go));
                sendable = false;
            }
        }

        if (sendable)
        {
            //build the client
            Client newClient = new Client();

            newClient.First_Name = first.text;
            newClient.Last_Name = last.text;
            newClient.Company = company.text;
            newClient.Email = email.text;
            newClient.Phone = phone.text;

            Debug.Log(newClient.First_Name);

            //Send the data to the database
            dbMan.AddClient(newClient);

            //Return to last screen
            StartCoroutine(uiAnim.FlyOut(gameObject.transform.parent.parent.gameObject.GetComponent<RectTransform>(),"right"));


        }
    }

}
