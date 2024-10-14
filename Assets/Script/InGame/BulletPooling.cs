using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPooling : MonoBehaviour
{
    private List<GameObject> bulletList;
    private Transform bulletGroupTransform;
    private int maximumNumberOfPools, bulletIndex;
    private const int resetBulletIndex = 0;
    private const int indexation = 1;

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
        GameObject bullet = bulletList[bulletIndex];

        if (bulletIndex >= maximumNumberOfPools)
        {
            bulletIndex = resetBulletIndex;
        }
        else
        {
            bulletIndex += 1;
        }

        return bullet;
    }
}
