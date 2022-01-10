using UnityEngine;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [SerializeField] private InputManager input;
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
        if (CurrentLevel.Endless)
        {
            MainText.text = "������ �� ����, ����� ������� �������";
            RandomLimit();
        }
        else
        {
            MainText.text = "������ �� ����, ����� �����";
            NumberManager.s_inst.GenerateRandomNumber();
        }
        NumText.text = $"�� {NumberManager.s_inst.minRandom} �� {NumberManager.s_inst.maxRandom}";
        AttemptsText.text = $"�������: {currentAttempt}";
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
                if (PlayerPrefs.GetInt($"level_{CurrentLevel.LevelNum}", 0) == 0 &&
                    !CurrentLevel.NonStory)
                {
                    DataManager.s_inst.Money += NumberManager.s_inst.reward;
                    PlayerPrefs.SetInt($"level_{CurrentLevel.LevelNum}", 1);
                }
                if (CurrentLevel.NonStory)
                {
                    DataManager.s_inst.Money += NumberManager.s_inst.reward;
                }
                ChangeEmotionEvent?.Invoke(Static.CharacterEmotions.happy);
                StartCoroutine(WaitForScene(4));
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
                StartCoroutine(WaitForScene(4));
            }
        }
        catch (System.Exception)
        {
            MainText.text = "�� ���������� �����";
        }
    }
    public void EndlessMode(int PlayerNum)
    {
        try
        {
            if (PlayerNum == NumberManager.s_inst.randomNumber)
            {
                MainText.text = "�� �������!";
                ChangeEmotionEvent?.Invoke(Static.CharacterEmotions.happy);
                StartCoroutine(WaitForNextNumber(1));
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
                DataManager.s_inst.Money -= NumberManager.s_inst.reward;
                ChangeEmotionEvent?.Invoke(Static.CharacterEmotions.angry);
                StartCoroutine(WaitForScene(4));
            }
        }
        catch (System.Exception)
        {
            MainText.text = "�� ���������� �����";
        }
    }
    private IEnumerator WaitForScene(int time)
    {
        yield return new WaitForSeconds(time);
        SceneButtons.MainMenuBtn();
    }
    private IEnumerator WaitForNextNumber(int time)
    {
        input.DeleteNumberWhole();
        yield return new WaitForSeconds(time);
        NumberManager.s_inst.ChangeReward(NumberManager.s_inst.reward + currentAttempt / 4);
        RandomLimit();
        if (NumberManager.s_inst.totalRandom < 1000)
        {
            currentAttempt += 5 + (int)(NumberManager.s_inst.totalRandom * 0.01);
        }
        else
        {
            currentAttempt += (int)(NumberManager.s_inst.totalRandom * 0.0125);
        }
        NumText.text = $"�� {NumberManager.s_inst.minRandom} �� {NumberManager.s_inst.maxRandom}";
        AttemptsText.text = $"�������: {currentAttempt}";
        MainText.text = "������ �����";
        ChangeEmotionEvent?.Invoke(Static.CharacterEmotions.neutral);
    }
    private void RandomLimit()
    {
        NumberManager.s_inst.ChangeTotalRandom(NumberManager.s_inst.maxRandom + 100 +
            (int)(NumberManager.s_inst.totalRandom * 0.1));
        NumberManager.s_inst.ChangeMinRandom(Random.Range(0, 
            (int)(NumberManager.s_inst.totalRandom * 0.2)));
        NumberManager.s_inst.ChangeMaxRandom(NumberManager.s_inst.totalRandom -
            NumberManager.s_inst.minRandom);
        NumberManager.s_inst.GenerateRandomNumber();
    }
    public bool IsPlayerPlayed()
    {
        return currentAttempt < CurrentLevel.Attempts ? true : false;
    }
}
