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
    public Camera cam;
    public GameObject camCenter;

    public int currentModelIndex;

    [Header("Zoom")]
    public float zoomSpeed;
    public float zoomInMax;
    public float zoomOutMax;

    public CinemachineFreeLook.Orbit[] _orbits;

    [Header("Drag")]
    public float dragSpeed;
    private  Vector3 _desiredMoveDir;

    private void Start()
    {
        _loader = GameObject.Find("SYSTEMS").GetComponent<ModelsLoader>();
        _cmFreeLook = cinemachineGO.GetComponent<CinemachineFreeLook>();

        currentModel = Instantiate(_loader.modelsList[0]);
        _orbits = _cmFreeLook.m_Orbits;
        
    }

    private void Update()
    {
        RotateCamera();
        DragCamera();
        Zoom();
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

            if (_cmFreeLook.m_YAxis.m_MaxSpeed < 0.5f) _cmFreeLook.m_YAxis.m_MaxSpeed = 0;
            if (_cmFreeLook.m_XAxis.m_MaxSpeed < 30) _cmFreeLook.m_XAxis.m_MaxSpeed = 0;
        }
    }

    public void DragCamera()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            _desiredMoveDir.x = Input.GetAxis("Mouse X");
            _desiredMoveDir.y = -Input.GetAxis("Mouse Y");

            camCenter.transform.LookAt(cam.transform.position);
            camCenter.transform.Translate(_desiredMoveDir * dragSpeed * Time.deltaTime);
        } 
    }

    public void Zoom()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            _orbits[0].m_Radius = Mathf.Lerp(_orbits[0].m_Radius, zoomOutMax, zoomSpeed * Time.deltaTime);
            _orbits[1].m_Radius = Mathf.Lerp(_orbits[1].m_Radius, zoomOutMax, zoomSpeed * 2 * Time.deltaTime);
            _orbits[2].m_Radius = Mathf.Lerp(_orbits[2].m_Radius, zoomOutMax, zoomSpeed * Time.deltaTime);
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            _orbits[0].m_Radius = Mathf.Lerp(_orbits[0].m_Radius, zoomInMax, zoomSpeed * Time.deltaTime);
            _orbits[1].m_Radius = Mathf.Lerp(_orbits[1].m_Radius, zoomInMax, zoomSpeed * 2 * Time.deltaTime);
            _orbits[2].m_Radius = Mathf.Lerp(_orbits[2].m_Radius, zoomInMax, zoomSpeed * Time.deltaTime);
        }
    }
}
