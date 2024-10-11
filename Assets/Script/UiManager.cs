using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] private Transform clearCT;
    [SerializeField] private RectTransform liteIT, nextBT;
    [SerializeField] private Canvas aimCanvas, scopeCanvas;
    public RectTransform iconTransform;
    private CameraController cameraController;
    private GameObject angle;
    private Gun gunScript;

    public void ShowCanvas(Canvas canvas)
    {
        //ゲーム内の時間を止める
        Time.timeScale = 0;

        canvas.enabled = true;
    }

    public void CloseCanvas(Canvas canvas)
    {
        //ゲーム内の時間を再開
        Time.timeScale = 1;

        canvas.enabled = false;
    }

    public void OnGameClearUi()
    {
        DOTween.Sequence()
        .Append(clearCT.DOScale(1.2f, 0.3f))
        .Append(clearCT.DOScale(0.8f, 0.3f))
        .Append(clearCT.DOScale(1f, 0.3f));

        liteIT.DOLocalRotate(new Vector3(0, 0, 360f), 6f, RotateMode.FastBeyond360)
        .SetEase(Ease.Linear)
        .SetLoops(-1, LoopType.Restart);

        nextBT.DOScale(1f, 1f).SetDelay(1.5f);
    }

    public void OffGameClearUi()
    {
        clearCT.DOKill();

        clearCT.localScale = Vector3.zero;
        nextBT.localScale = Vector3.zero;
    }

    public void OnPrivacyPolicy()
    {
        Application.OpenURL("https://peppermint-sunset-fc2.notion.site/Privacy-Policy-388309cfd137491eb9b0035409ccb7d4?pvs=4");
    }

    public void ZoomIn()
    {
        CameraChanger cameraChanger = GameObject.FindWithTag("Angle").GetComponent<CameraChanger>();
        cameraChanger.ZoomIn();

        aimCanvas.enabled = false;
        scopeCanvas.enabled = true;
    }

    public void ZoomOut()
    {
        angle = GameObject.FindWithTag("Angle");
        GameObject gun = GameObject.FindWithTag("Gun");

        // 弾をうつ
        cameraController = angle.GetComponent<CameraController>();
        cameraController.shootReaction();

        gunScript = gun.GetComponent<Gun>();
        gunScript.Shoot();

    }

    public void CameraChanger()
    {
        // 数秒してからUIとカメラの変更
        DOVirtual.DelayedCall(1.5f, () =>
        {
            cameraController.InitializeCameraAngle();

            CameraChanger cameraChanger = angle.GetComponent<CameraChanger>();
            cameraChanger.ZoomOut();

            aimCanvas.enabled = true;
            scopeCanvas.enabled = false;

            gunScript.Animation();
        }, false);
    }
}
