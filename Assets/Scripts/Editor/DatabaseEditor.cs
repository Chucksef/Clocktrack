using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class DatabaseEditor : EditorWindow
{
    public ClientDatabase clientDatabase;
    private string DataProjectFilePath = "/StreamingAssets/data.json";

    [MenuItem("Window/Game Data Editor")]
    static void Init()
    {
        DatabaseEditor window = (DatabaseEditor)EditorWindow.GetWindow(typeof(DatabaseEditor));
        window.Show();
    }

    private void OnGUI()
    {
        if (clientDatabase != null)
        {
            SerializedObject serializedObject = new SerializedObject(this);
            SerializedProperty serializedProperty = serializedObject.FindProperty("clientDatabase");

            EditorGUILayout.PropertyField(serializedProperty, true);

            serializedObject.ApplyModifiedProperties();

            if (GUILayout.Button("Save Data"))
            {
                SaveGameData();
            }
        }
        if (GUILayout.Button("Load Data"))
        {
            LoadGameData();
        }
    }

    private void LoadGameData()
    {
        string filePath = Application.dataPath + DataProjectFilePath;

        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            clientDatabase = JsonUtility.FromJson<ClientDatabase>(dataAsJson);
        }
        else
        {
            clientDatabase = new ClientDatabase();
        }
    }

    private void SaveGameData()
    {
        string dataAsJson = JsonUtility.ToJson(clientDatabase);
        string filePath = Application.dataPath + DataProjectFilePath;
        File.WriteAllText(filePath, dataAsJson);
    }
}
