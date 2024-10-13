using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class OutGameUIView : MonoBehaviour
{
    [SerializeField] private Transform clearCanvas;
    [SerializeField] private RectTransform liteImage, nextButton;
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
            .Append(clearCanvas.DOScale(1.2f, 0.3f))
            .Append(clearCanvas.DOScale(0.8f, 0.3f))
            .Append(clearCanvas.DOScale(1f, 0.3f));

            liteImage.DOLocalRotate(new Vector3(0, 0, 360f), 6f, RotateMode.FastBeyond360)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Restart);

            nextButton.DOScale(1f, 1f).SetDelay(1.5f);
        }, false);
    }

    public void OffGameClearUi()
    {
        clearCanvas.DOKill();

        clearCanvas.localScale = Vector3.zero;
        nextButton.localScale = Vector3.zero;
    }
}
