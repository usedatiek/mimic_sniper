
using UnityEngine;
using UniRx;


public class StagePresenter : MonoBehaviour
{
    [SerializeField] private StageView stageView;
    [SerializeField] private StageModel stageModel;

    void Start()
    {
        stageView.Initialization(levelNum: stageModel.LevelNum.Value, stageNum: stageModel.StageNum.Value);

        //　View -> Model
        stageView.CurrentStageNum.Subscribe(currentStageNum =>
        {
            stageModel.SaveStageNumber(currentStageNum);
        });


        // Model -> View
        stageModel.StageNum.Subscribe(stageNum =>
        {
            stageView.NextStage(stageNum);
        });

        stageModel.LevelNum.Subscribe(levelNum =>
        {
            stageView.NextLevel(levelNum);
        });
    }

    public void NextStage()
    {
        stageModel.NextStage();
    }

    public void Restart()
    {
        stageView.StageRestart(stageModel.StageNum.Value);
    }
}
