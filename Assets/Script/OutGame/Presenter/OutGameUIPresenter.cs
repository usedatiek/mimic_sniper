using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutGameUIPresenter : MonoBehaviour
{
    [SerializeField] private OutGameUIModel outGameUIModel;
    [SerializeField] private OutGameUIView outGameUIView;

    public void NumberOfSniperShots()
    {
        bool isGameClear = outGameUIModel.NumberOfSniperShots();

        if (isGameClear)
        {
            outGameUIView.OnGameClearUi();
        }
    }

    public void OffGameClearUi()
    {
        outGameUIView.OffGameClearUi();
    }
}
