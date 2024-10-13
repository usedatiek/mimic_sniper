using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using DG.Tweening;
using UnityEngine;

public class Gun : MonoBehaviour
{

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform angleTransform;
    [SerializeField] private Animator animator;

    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.transform.position = angleTransform.position;
        GameObject bulletGroup = GameObject.FindWithTag("BulletGroup");
        bullet.transform.parent = bulletGroup.transform;
        bullet.transform.rotation = angleTransform.rotation;

        Rigidbody rigidbody = bullet.GetComponent<Rigidbody>();
        rigidbody.AddForce((angleTransform.forward * 30000), ForceMode.Acceleration);
    }

    public void Animation()
    {
        animator.Play("ShootAndBolt", 0, 0);
    }
}
