using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;
    static private bool isEnd;

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Bullet") && !isEnd)
        {
            isEnd = true;
            RectTransform iconTransform = GameObject.FindWithTag("UiManager").GetComponent<UiManager>().iconTransform;

            _particleSystem.Play();

            iconTransform.DOScale(1f, 0.8f).SetLoops(2, LoopType.Yoyo).OnComplete(() =>
            {
                isEnd = false;
            });

            iconTransform.DOLocalRotate(new Vector3(0, 0, -15), 0.2f).SetLoops(4, LoopType.Yoyo).SetEase(Ease.Linear);
        }
    }
}
