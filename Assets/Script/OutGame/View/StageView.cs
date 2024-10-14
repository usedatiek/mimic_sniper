using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;


public class StageView : MonoBehaviour
{
    [SerializeField] private Text levelText;
    [SerializeField] private List<GameObject> stageList;

    public IReadOnlyReactiveProperty<int> CurrentStageNum => _currentStageNum;
    private readonly IntReactiveProperty _currentStageNum = new IntReactiveProperty(0);


    private const int resetStageNum = 0;
    private GameObject currentStage;

    public void Initialization(int levelNum, int stageNum)
    {
        levelText.text = "LEVEL " + levelNum;

        // stageNumがstageListのインデックス範囲内にあるかを確認
        if (stageNum >= 0 && stageNum < stageList.Count)
        {
            GameObject stage = stageList[stageNum];
            currentStage = Instantiate(stage);
        }
        else
        {
            // stageNumが範囲外の場合、エラーメッセージをログに表示
            Debug.LogError("Stage number " + stageNum + " is out of range.");

            _currentStageNum.Value = resetStageNum;

            GameObject stage = stageList[resetStageNum];
            currentStage = Instantiate(stage);
        }
    }

    public void NextStage(int stageNum)
    {
        // stageNumがstageListのインデックス範囲内にあるかを確認
        if (stageNum >= 0 && stageNum < stageList.Count)
        {
            GameObject nextStage = stageList[stageNum];

            currentStage.SetActive(false);
            currentStage = Instantiate(nextStage);
        }
        else
        {
            GameObject resetStage = stageList[resetStageNum];

            _currentStageNum.Value = resetStageNum;

            currentStage.SetActive(false);
            currentStage = Instantiate(resetStage);
        }
    }

    public void NextLevel(int levelNum)
    {
        levelText.text = "LEVEL " + levelNum;
    }

    public void StageRestart(int stageNum)
    {
        GameObject stage = stageList[stageNum];

        currentStage.SetActive(false);
        currentStage = Instantiate(stage);
    }
}
