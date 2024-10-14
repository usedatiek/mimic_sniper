using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GunPresenter : MonoBehaviour
{
    [SerializeField] private InGameUIView inGameUIView;
    private CameraController cameraController;
    private CameraChange cameraChange;
    private Gun gun;

    public void GunZoomIn()
    {
        GameObject gunAngle = GameObject.FindWithTag("GunAngle");
        cameraChange = gunAngle.GetComponent<CameraChange>();
        cameraController = gunAngle.GetComponent<CameraController>();
        gun = GameObject.FindWithTag("Gun").GetComponent<Gun>();

        cameraChange = gunAngle.GetComponent<CameraChange>();

        cameraChange.ZoomIn();
        inGameUIView.GunZoomIn();
    }

    public void Shoot()
    {
        cameraController.ShootReaction();
        gun.Shoot();

        GunZoomOut();
    }

    private void GunZoomOut()
    {
        // 数秒してからUIとカメラの変更
        DOVirtual.DelayedCall(1.5f, () =>
        {
            cameraController.InitializeCameraAngle();

            cameraChange.ZoomOut();

            inGameUIView.GunZoomOut();

            gun.Animation();
        }, false);
    }
}
