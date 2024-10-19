using DG.Tweening;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform angleTransform;
    [SerializeField] private Animator animator;
    [SerializeField] private BulletPooling bulletPooling;

    private const int force = 30000;

    public async void Shoot()
    {
        GameObject bullet = bulletPooling.GetBullets();

        Transform bulletTransform = bullet.transform;

        bulletTransform.position = angleTransform.position;
        bulletTransform.rotation = angleTransform.rotation;

        Rigidbody rigidbody = bullet.GetComponent<Rigidbody>();
        rigidbody.AddForce((angleTransform.forward * force), ForceMode.Acceleration);


        // キャンセル処理があってもその後の処理は変わらず実行してほしいのでbool型の変数で条件分岐はしない。
        await UniTask.Delay(TimeSpan.FromSeconds(1f), cancellationToken: this.GetCancellationTokenOnDestroy()).SuppressCancellationThrow();
        bullet.GetComponent<Bullet>().BulletInitialization();
    }

    public void Animation()
    {
        animator.Play(stateName: "ShootAndBolt", layer: 0, normalizedTime: 0);
    }
}
