using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutGameUIModel : MonoBehaviour
{
    [SerializeField] private int maxCount;
    private int peopleCount;

    public void OnPrivacyPolicy()
    {
        Application.OpenURL("https://peppermint-sunset-fc2.notion.site/Privacy-Policy-388309cfd137491eb9b0035409ccb7d4?pvs=4");
    }

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
