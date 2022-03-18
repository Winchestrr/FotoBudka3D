using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ModelsLoader : MonoBehaviour
{
    public List<GameObject> modelsList = new List<GameObject>();

    public string inputDir;
    public string[] fileEntries;

    void OnEnable()
    {
        LoadModelsFromFile();
    }

    void LoadModelsFromFile()
    {
        inputDir = Application.dataPath + "/Resources/Input/";
        fileEntries = Directory.GetFiles(inputDir);

        foreach (string fileName in fileEntries)
        {
            string[] splitted = Path.GetFileName(fileName).Split('.');

            if (splitted.Length == 2)
            {
                GameObject model = Resources.Load<Object>("Input/" + splitted[0]) as GameObject;
                modelsList.Add(model);
            }
        }
    }
}
