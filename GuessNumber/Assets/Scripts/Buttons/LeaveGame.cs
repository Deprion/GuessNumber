using UnityEngine;

public class LeaveGame : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (GameObject.FindGameObjectWithTag("GameManager").
            GetComponent<GameManager>().IsPlayerPlayed())
        {
            DataManager.s_inst.Money -= NumberManager.s_inst.loss;
        }
        SceneButtons.MainMenuBtn();
    }
}
