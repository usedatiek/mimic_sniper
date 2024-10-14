using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

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

    public void BulletHit()
    {
        if (isAnimationEnd)
        {
            isAnimationEnd = false;

            effect.Play();

            angryIconTransform.DOLocalRotate(angleOfRotation, rotationSpeed).SetLoops(rotationLoopCount, LoopType.Yoyo).SetEase(Ease.Linear);
            angryIconTransform.DOScale(scaleSize, scaleSpeed).SetLoops(scaleLoopCount, LoopType.Yoyo).OnComplete(() =>
            {
                isAnimationEnd = true;
            });
        }
    }
}
