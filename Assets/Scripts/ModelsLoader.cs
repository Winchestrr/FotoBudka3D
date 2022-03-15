using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ModelsLoader : MonoBehaviour
{
    public List<Object> modelsList = new List<Object>();

    public string inputDir;
    public string[] fileEntries;

    void OnEnable()
    {
        LoadModelsFromFile();
    }

    void LoadModelsFromFile()
    {
        inputDir = @"Assets/Resources/Input/";
        fileEntries = Directory.GetFiles(inputDir);

        foreach (string fileName in fileEntries)
        {
            string[] splitted = Path.GetFileName(fileName).Split('.');

            if (splitted.Length == 2)
            {
                Object model = Resources.Load<Object>("Input/" + splitted[0]);
                modelsList.Add(model);
            }
        }
    }
}
