using DG.Tweening;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System;

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

    private async void GunZoomOut()
    {
        isReload = true;

        // キャンセル処理があってもその後の処理は変わらず実行してほしいのでbool型の変数で条件分岐はしない。
        await UniTask.Delay(TimeSpan.FromSeconds(1.5f), cancellationToken: this.GetCancellationTokenOnDestroy()).SuppressCancellationThrow();

        cameraController.InitializeCameraAngle();
        cameraChange.ZoomOut();
        inGameUIView.GunZoomOut();
        gun.Animation();
        isReload = false;
    }
}
