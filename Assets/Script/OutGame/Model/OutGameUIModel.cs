using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutGameUIModel : MonoBehaviour
{
    [SerializeField] private int maxCount;
    private int peopleCount;

    public bool NumberOfSniperShots()
    {
        peopleCount += 1;
        if (maxCount == peopleCount)
        {
            peopleCount = 0;
            return true;
        }

        return false;
    }
}
