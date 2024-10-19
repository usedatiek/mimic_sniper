using DG.Tweening;
using UnityEngine;
using Cysharp.Threading.Tasks;


public class Animal : MonoBehaviour
{
    [SerializeField] private ParticleSystem effect;
    private bool isAnimationEnd;
    private RectTransform angryIconTransform;

    private const float scaleSize = 1;
    private const float scaleSpeed = 0.8f;
    private const float rotationSpeed = 0.2f;
    private const int scaleLoopCount = 2;
    private const int rotationLoopCount = 4;
    private Vector3 angleOfRotation { get { return new Vector3(0, 0, -15); } }

    private void Start()
    {
        angryIconTransform = GameObject.FindWithTag("AngryIcon").GetComponent<RectTransform>();
        isAnimationEnd = true;
    }

    public async void BulletHit()
    {
        if (isAnimationEnd)
        {
            isAnimationEnd = false;

            effect.Play();

            var anim1 = angryIconTransform.DOLocalRotate(angleOfRotation, rotationSpeed).SetLoops(rotationLoopCount, LoopType.Yoyo).SetEase(Ease.Linear).WithCancellation(this.GetCancellationTokenOnDestroy());
            var anim2 = angryIconTransform.DOScale(scaleSize, scaleSpeed).SetLoops(scaleLoopCount, LoopType.Yoyo).WithCancellation(this.GetCancellationTokenOnDestroy());

            // キャンセル処理があってもその後の処理は変わらず実行してほしいのでbool型の変数で条件分岐はしない。
            await UniTask.WhenAll(anim1, anim2).SuppressCancellationThrow();
            isAnimationEnd = true;
        }
    }
}
