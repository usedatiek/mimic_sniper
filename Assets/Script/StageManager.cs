using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    [SerializeField] private Text levelText;
    [SerializeField] private List<GameObject> stageList;

    private int levelNum, stageNum;
    private int resetStageNum = 0;
    private GameObject currentStage;

    private void Start()
    {
        Application.targetFrameRate = 60;

        FS();
    }

    private void FS()
    {
        levelNum = ES3.Load<int>("levelNum", 1);
        stageNum = ES3.Load<int>("stageNum", 0);

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

            GameObject stage = stageList[resetStageNum];
            currentStage = Instantiate(stage);
        }
    }

    public void NextStage()
    {
        levelNum += 1;
        int nextStageNum = stageNum + 1;

        levelText.text = "LEVEL " + levelNum;

        // stageNumがstageListのインデックス範囲内にあるかを確認
        if (nextStageNum >= 0 && nextStageNum < stageList.Count)
        {
            GameObject nextStage = stageList[nextStageNum];

            currentStage.SetActive(false);
            currentStage = Instantiate(nextStage);

            stageNum = nextStageNum;
        }
        else
        {
            GameObject resetStage = stageList[resetStageNum];

            currentStage.SetActive(false);
            currentStage = Instantiate(resetStage);

            stageNum = resetStageNum;
        }

        ES3.Save<int>("levelNum", levelNum);
        ES3.Save<int>("stageNum", stageNum);
    }

    public void Restart()
    {
        GameObject nextStage = stageList[stageNum];

        currentStage.SetActive(false);
        currentStage = Instantiate(nextStage);
    }
}
