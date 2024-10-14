using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPooling : MonoBehaviour
{
    private List<GameObject> bulletList;
    private Transform bulletGroupTransform;
    private int maximumNumberOfPools, bulletCount;
    private int initBulletCount = 0;
    private int indexation = 1;

    private void Start()
    {
        bulletGroupTransform = GameObject.FindWithTag("BulletGroup").transform;
        bulletList = new List<GameObject>();
        maximumNumberOfPools = bulletGroupTransform.childCount - indexation;

        foreach (Transform child in bulletGroupTransform)
        {
            bulletList.Add(child.gameObject);
        }
    }

    public GameObject GetBullets()
    {
        GameObject bullet = bulletList[bulletCount];

        if (bulletCount >= maximumNumberOfPools)
        {
            bulletCount = initBulletCount;
        }
        else
        {
            bulletCount += 1;
        }

        return bullet;
    }
}
