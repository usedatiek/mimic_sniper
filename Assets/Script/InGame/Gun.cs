using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using DG.Tweening;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform angleTransform;
    [SerializeField] private Animator animator;
    [SerializeField] private BulletPooling bulletPooling;

    public void Shoot()
    {
        GameObject bullet = bulletPooling.GetBullets();

        Transform bulletTransform = bullet.transform;

        bulletTransform.position = angleTransform.position;
        bulletTransform.rotation = angleTransform.rotation;

        Rigidbody rigidbody = bullet.GetComponent<Rigidbody>();
        rigidbody.AddForce((angleTransform.forward * 30000), ForceMode.Acceleration);

        DOVirtual.DelayedCall(1f, () =>
        {
            bullet.GetComponent<Bullet>().BulletInitialization();
        }, false);
    }

    public void Animation()
    {
        animator.Play("ShootAndBolt", 0, 0);
    }
}
