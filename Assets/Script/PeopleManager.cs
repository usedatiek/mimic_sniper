using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PeopleManager : MonoBehaviour
{
    [SerializeField] private int maxCount;
    [SerializeField] private UiManager uiManager;
    private int peopleCount;
    

    public void DefeatedCounts()
    {
        peopleCount += 1;
        if (maxCount == peopleCount)
        {
            DOVirtual.DelayedCall(1.5f, () =>
            {
                uiManager.OnGameClearUi();
                peopleCount = 0;
            }, false);
        }
    }
}
