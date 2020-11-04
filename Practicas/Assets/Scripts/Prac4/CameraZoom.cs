using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public float minFov, maxFov, zoomRate;
    private Camera _cam;
    void Awake()
    {
        _cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        CheckZoom();
    }

    private void CheckZoom()
    {
        if(Input.GetKey(KeyCode.UpArrow))
            ChangeFOV(-zoomRate);
        if(Input.GetKey(KeyCode.DownArrow))
            ChangeFOV(zoomRate);
    }

    private void ChangeFOV(float zoomRate)
    {
        float fov = _cam.fieldOfView + zoomRate;
        fov = Mathf.Clamp(fov,minFov,maxFov);
        _cam.fieldOfView = fov;
    }
}
