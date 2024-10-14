using DG.Tweening;
using UnityEngine;


public class GunPresenter : MonoBehaviour
{
    [SerializeField] private InGameUIView inGameUIView;
    private CameraController cameraController;
    private CameraChange cameraChange;
    private Gun gun;
    private bool isReload;

    public void Initialization()
    {
        GameObject gunAngle = GameObject.FindWithTag("GunAngle");
        cameraChange = gunAngle.GetComponent<CameraChange>();
        cameraController = gunAngle.GetComponent<CameraController>();
        gun = GameObject.FindWithTag("Gun").GetComponent<Gun>();

        cameraChange = gunAngle.GetComponent<CameraChange>();

        isReload = false;
    }

    public void GunZoomIn()
    {
        if (isReload) return;

        cameraChange.ZoomIn();
        inGameUIView.GunZoomIn();
    }

    public void Shoot()
    {
        if (isReload) return;

        cameraController.ShootReaction();
        gun.Shoot();

        GunZoomOut();
    }

    private void GunZoomOut()
    {
        isReload = true;
        // 数秒してからUIとカメラの変更
        DOVirtual.DelayedCall(1.5f, () =>
        {
            cameraController.InitializeCameraAngle();
            cameraChange.ZoomOut();
            inGameUIView.GunZoomOut();
            gun.Animation();
            isReload = false;
        }, false);
    }
}
