using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera scopeCamera;

    public void ZoomIn()
    {
        scopeCamera.enabled = true;
    }
    public void ZoomOut()
    {
        scopeCamera.enabled = false;
    }
}
