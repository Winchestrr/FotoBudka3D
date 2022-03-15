using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSystem : MonoBehaviour
{
    public ModelsLoader _loader;

    public Object currentModel;
    public int currentModelIndex;

    private void Start()
    {
        _loader = GameObject.Find("SYSTEMS").GetComponent<ModelsLoader>();
        currentModel = Instantiate(_loader.modelsList[0]);
    }
    public void SwitchModel(string direction)
    {
        Destroy(currentModel);

        if (direction == "forward")
        {
            currentModelIndex++;

            if (currentModelIndex >= _loader.modelsList.Count)
                currentModelIndex = 0;
        }
        else
        {
            currentModelIndex--;

            if (currentModelIndex < 0)
                currentModelIndex = _loader.modelsList.Count - 1;
        }

        currentModel = Instantiate(_loader.modelsList[currentModelIndex]);
    }
}
