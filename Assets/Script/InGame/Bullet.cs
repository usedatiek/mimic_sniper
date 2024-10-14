using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private BoxCollider myBoxCollider;
    [SerializeField] private Rigidbody myRigidbody;
    private bool isEnd;

    public void BulletInitialization()
    {
        myRigidbody.velocity = Vector3.zero;
        myBoxCollider.enabled = true;
        isEnd = false;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Enemy") && !isEnd)
        {
            isEnd = true;

            myBoxCollider.enabled = false;
            // 毎回GetComponentを呼ぶのはコストが高いので避けたいが弾が早すぎて両方ともに当たり判定が入ってしまうのを避けるためBullet側から呼び出ししている。
            col.gameObject.GetComponent<Enemy>().BulletHit();

            return;
        }

        if (col.CompareTag("Animal") && !isEnd)
        {
            isEnd = true;

            myBoxCollider.enabled = false;
            // 毎回GetComponentを呼ぶのはコストが高いので避けたいが弾が早すぎて両方ともに当たり判定が入ってしまうのを避けるためBullet側から呼び出ししている。
            col.gameObject.GetComponent<Animal>().BulletHit();

            return;
        }
    }
}
