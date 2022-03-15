using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MainSystem : MonoBehaviour
{
    public ModelsLoader _loader;
    public GameObject currentModel;
    public GameObject cinemachineGO;
    private CinemachineFreeLook _cmFreeLook;

    public int currentModelIndex;

    [Header("Zoom")]
    public float zoomSpeed;
    public float zoomInMax;
    public float zoomOutMax;

    

    private void Start()
    {
        _loader = GameObject.Find("SYSTEMS").GetComponent<ModelsLoader>();
        currentModel = Instantiate(_loader.modelsList[0]);

        _cmFreeLook = cinemachineGO.GetComponent<CinemachineFreeLook>();
    }

    private void Update()
    {
        RotateCamera();
        
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


    public void RotateCamera()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            _cmFreeLook.m_YAxis.m_MaxSpeed = 5;
            _cmFreeLook.m_XAxis.m_MaxSpeed = 700;
        }
        else
        {
            _cmFreeLook.m_YAxis.m_MaxSpeed =
                Mathf.Lerp(_cmFreeLook.m_YAxis.m_MaxSpeed, 0, 10 * Time.deltaTime);
            _cmFreeLook.m_XAxis.m_MaxSpeed =
                Mathf.Lerp(_cmFreeLook.m_XAxis.m_MaxSpeed, 0, 10 * Time.deltaTime);
        }
    }

    public void Zoom()
    {

    }
}
