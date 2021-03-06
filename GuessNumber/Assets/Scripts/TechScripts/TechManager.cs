using UnityEngine;

public class TechManager : MonoBehaviour
{
    public void RunLevel(LevelSO level)
    {
        NumberManager.s_inst.ChangeTotalRandom(level.TotalNum);
        NumberManager.s_inst.ChangeMaxRandom(level.MinNum);
        NumberManager.s_inst.ChangeMaxRandom(level.MaxNum);
        NumberManager.s_inst.ChangeReward(level.Reward);
        NumberManager.s_inst.ChangeLoss(level.Lose);
        NumberManager.s_inst.ChangeLevel(level);
        SceneButtons.PlayBotBtn();
    }
}
