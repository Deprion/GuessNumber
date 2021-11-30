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
        NumberManager.s_inst.ChangeMaxRandom(50);
        NumberManager.s_inst.ChangeAttempts(10);
        NumberManager.s_inst.ChangeReward(2);
        NumberManager.s_inst.ChangeLoss(1);
        SceneButtons.PlayBotBtn();
    }
    public void HardMode()
    {
        NumberManager.s_inst.ChangeMaxRandom(200);
        NumberManager.s_inst.ChangeAttempts(15);
        NumberManager.s_inst.ChangeReward(6);
        NumberManager.s_inst.ChangeLoss(3);
        SceneButtons.PlayBotBtn();
    }
}
