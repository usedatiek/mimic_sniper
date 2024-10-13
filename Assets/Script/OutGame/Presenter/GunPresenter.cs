using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GunPresenter : MonoBehaviour
{
    [SerializeField] private InGameUIView inGameUIView;
    private CameraController cameraController;
    private CameraChange cameraChange;
    private GameObject angle;
    private Gun gun;

    public void GunZoomIn()
    {
        GameObject angle = GameObject.FindWithTag("Angle");
        cameraChange = angle.GetComponent<CameraChange>();
        cameraController = angle.GetComponent<CameraController>();
        gun = GameObject.FindWithTag("Gun").GetComponent<Gun>();

        cameraChange = angle.GetComponent<CameraChange>();

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
