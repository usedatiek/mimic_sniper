using DG.Tweening;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform angleTransform;
    [SerializeField] private Animator animator;
    [SerializeField] private BulletPooling bulletPooling;

    private const int force = 30000;

    public void Shoot()
    {
        GameObject bullet = bulletPooling.GetBullets();

        Transform bulletTransform = bullet.transform;

        bulletTransform.position = angleTransform.position;
        bulletTransform.rotation = angleTransform.rotation;

        Rigidbody rigidbody = bullet.GetComponent<Rigidbody>();
        rigidbody.AddForce((angleTransform.forward * force), ForceMode.Acceleration);

        DOVirtual.DelayedCall(1f, () =>
        {
            bullet.GetComponent<Bullet>().BulletInitialization();
        }, false);
    }

    public void Animation()
    {
        animator.Play(stateName: "ShootAndBolt", layer: 0, normalizedTime: 0);
    }
}
