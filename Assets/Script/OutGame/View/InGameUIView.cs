using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class InGameUIView : MonoBehaviour
{
    [SerializeField] private Canvas aimCanvas, scopeCanvas;

    public void GunZoomIn()
    {
        aimCanvas.enabled = false;
        scopeCanvas.enabled = true;
    }

    public void GunZoomOut()
    {
        aimCanvas.enabled = true;
        scopeCanvas.enabled = false;
    }
}
