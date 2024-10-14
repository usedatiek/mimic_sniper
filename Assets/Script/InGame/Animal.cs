using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;
    private bool isAnimationEnd;
    private RectTransform angryIconTransform;

    private void Start()
    {
        angryIconTransform = GameObject.FindWithTag("AngryIcon").GetComponent<RectTransform>();
        isAnimationEnd = true;
    }

    public void BulletHit()
    {
        _particleSystem.Play();

        if (isAnimationEnd)
        {
            isAnimationEnd = false;

            angryIconTransform.DOScale(1f, 0.8f).SetLoops(2, LoopType.Yoyo).OnComplete(() =>
            {
                isAnimationEnd = true;
            });
        }

        angryIconTransform.DOLocalRotate(new Vector3(0, 0, -15), 0.2f).SetLoops(4, LoopType.Yoyo).SetEase(Ease.Linear);
    }
}
