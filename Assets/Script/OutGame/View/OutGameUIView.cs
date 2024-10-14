using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class OutGameUIView : MonoBehaviour
{
    [SerializeField] private Transform clearCanvas;
    [SerializeField] private RectTransform liteImage, nextButton;

    private const float firstScaleSize = 1.2f;
    private const float secondScaleSize = 0.8f;
    private const float thirdScaleSize = 1f;
    private const float scaleSpeed = 0.3f;
    private const int forwardVector = 360;
    private const float rotationSpeed = 6f;
    private const float buttonScaleSize = 1f;
    private const float buttonScaleSpeed = 1f;

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
        DOVirtual.DelayedCall(1.5f, () =>
        {
            DOTween.Sequence()
            .Append(clearCanvas.DOScale(firstScaleSize, scaleSpeed))
            .Append(clearCanvas.DOScale(secondScaleSize, scaleSpeed))
            .Append(clearCanvas.DOScale(thirdScaleSize, scaleSpeed));

            liteImage.DOLocalRotate(Vector3.forward * forwardVector, rotationSpeed, RotateMode.FastBeyond360)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Restart);

            nextButton.DOScale(buttonScaleSize, buttonScaleSpeed).SetDelay(1.5f);
        }, false);
    }

    public void OffGameClearUi()
    {
        clearCanvas.DOKill();

        clearCanvas.localScale = Vector3.zero;
        nextButton.localScale = Vector3.zero;
    }
}
