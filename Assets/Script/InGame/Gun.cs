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
    private Transform bulletGroupTransform;

    private void Start()
    {
        bulletGroupTransform = GameObject.FindWithTag("BulletGroup").transform;
    }

    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab);
        Transform bulletTransform = bullet.transform;

        bulletTransform.position = angleTransform.position;
        bulletTransform.rotation = angleTransform.rotation;

        bulletTransform.parent = bulletGroupTransform;

        Rigidbody rigidbody = bullet.GetComponent<Rigidbody>();
        rigidbody.AddForce((angleTransform.forward * 30000), ForceMode.Acceleration);
    }

    public void Animation()
    {
        animator.Play("ShootAndBolt", 0, 0);
    }
}
