using UnityEngine;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public delegate void ChangeEmotionDelegate(Static.CharacterEmotions index);
    public event ChangeEmotionDelegate ChangeEmotionEvent;
    public TMP_Text MainText;
    public TMP_Text AttemptsText;
    public TMP_Text NumText;
    public TMP_InputField InputField;
    public LevelSO CurrentLevel;
    private int currentAttempt = 0;
    private void Awake()
    {
        CurrentLevel = NumberManager.s_inst.Level;
        currentAttempt = CurrentLevel.Attempts;
        NumText.text = $"�� {NumberManager.s_inst.minRandom} �� {NumberManager.s_inst.maxRandom}";
        AttemptsText.text = $"�������: {currentAttempt}";
        NumberManager.s_inst.GenerateRandomNumber();
        MainText.text = "������ �� ����, ����� �����";
    }
    private void Start()
    {
        ChangeEmotionEvent?.Invoke(Static.CharacterEmotions.neutral);
    }
    public void GuessNumber(int PlayerNum)
    {
        try
        {
            if (PlayerNum == NumberManager.s_inst.randomNumber)
            {
                MainText.text = "�� �������!";
                InputField.interactable = false;
                DataManager.s_inst.Money += NumberManager.s_inst.reward;
                PlayerPrefs.SetInt($"level_{CurrentLevel.LevelNum}", 1);
                ChangeEmotionEvent?.Invoke(Static.CharacterEmotions.happy);
                StartCoroutine(WaitFor(4));
            }
            else
            {
                if (PlayerNum < NumberManager.s_inst.randomNumber)
                    MainText.text = "����� ������";
                else MainText.text = "����� ������";
                AttemptsText.text = $"�������: {--currentAttempt}";
            }
            if (currentAttempt <= 0)
            {
                MainText.text = "�� ���������!";
                InputField.interactable = false;
                DataManager.s_inst.Money -= NumberManager.s_inst.loss;
                ChangeEmotionEvent?.Invoke(Static.CharacterEmotions.angry);
                StartCoroutine(WaitFor(4));
            }
        }
        catch (System.Exception)
        {
            MainText.text = "�� ���������� �����";
        }
    }
    private IEnumerator WaitFor(int time)
    {
        yield return new WaitForSeconds(time);
        SceneButtons.MainMenuBtn();
    }
    public bool IsPlayerPlayed()
    {
        return currentAttempt < CurrentLevel.Attempts ? true : false;
    }
}
