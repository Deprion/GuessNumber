using UnityEngine;

public class TechManager : MonoBehaviour
{
    public void EasyMode()
    {
        NumberManager.s_inst.ChangeMaxRandom(15);
        NumberManager.s_inst.ChangeAttempts(6);
        NumberManager.s_inst.ChangeReward(1);
        NumberManager.s_inst.ChangeLoss(0);
        SceneButtons.PlayBotBtn();
    }
    public void MediumMode()
    {
        NumberManager.s_inst.ChangeMaxRandom(100);
        NumberManager.s_inst.ChangeAttempts(8);
        NumberManager.s_inst.ChangeReward(4);
        NumberManager.s_inst.ChangeLoss(2);
        SceneButtons.PlayBotBtn();
    }
    public void HardMode()
    {
        NumberManager.s_inst.ChangeMaxRandom(500);
        NumberManager.s_inst.ChangeAttempts(10);
        NumberManager.s_inst.ChangeReward(9);
        NumberManager.s_inst.ChangeLoss(6);
        SceneButtons.PlayBotBtn();
    }
}
