using UnityEngine;
using UniRx;
using DG.Tweening;

public class StageModel : MonoBehaviour
{
    public IReadOnlyReactiveProperty<int> LevelNum => _levelNum;
    public IReadOnlyReactiveProperty<int> StageNum => _stageNum;
    private readonly IntReactiveProperty _levelNum = new IntReactiveProperty(1);
    private readonly IntReactiveProperty _stageNum = new IntReactiveProperty(0);

    public void SaveStageNumber(int num)
    {
        ES3.Save<int>("stageNum", num);
    }

    public void NextStage()
    {
        _levelNum.Value += 1;
        _stageNum.Value += 1;

        ES3.Save<int>("levelNum", _levelNum.Value);
        ES3.Save<int>("stageNum", _stageNum.Value);
    }

    private void OnDestroy()
    {
        _levelNum.Dispose();
        _stageNum.Dispose();
    }
}
