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
            MainText.text = LanguageManager.inst.GetString("click_on_end");
            RandomLimit();
        }
        else
        {
            MainText.text = LanguageManager.inst.GetString("click_on");
            NumberManager.s_inst.GenerateRandomNumber();
        }
        FromToText();
        AttemptText();
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
                MainText.text = LanguageManager.inst.GetString("guessed");
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
                    MainText.text = LanguageManager.inst.GetString("higher");
                else MainText.text = LanguageManager.inst.GetString("lower");
                --currentAttempt;
                AttemptText();
            }
            if (currentAttempt <= 0)
            {
                MainText.text = LanguageManager.inst.GetString("lose");
                InputField.interactable = false;
                DataManager.s_inst.Money -= NumberManager.s_inst.loss;
                ChangeEmotionEvent?.Invoke(Static.CharacterEmotions.angry);
                StartCoroutine(WaitForScene(4));
            }
        }
        catch (System.Exception)
        {
            MainText.text = LanguageManager.inst.GetString("wrong");
        }
    }
    public void EndlessMode(int PlayerNum)
    {
        try
        {
            if (PlayerNum == NumberManager.s_inst.randomNumber)
            {
                MainText.text = LanguageManager.inst.GetString("guessed");
                ChangeEmotionEvent?.Invoke(Static.CharacterEmotions.happy);
                StartCoroutine(WaitForNextNumber(1));
            }
            else
            {
                if (PlayerNum < NumberManager.s_inst.randomNumber)
                    MainText.text = LanguageManager.inst.GetString("higher");
                else MainText.text = LanguageManager.inst.GetString("lower");
                --currentAttempt;
                AttemptText();
            }
            if (currentAttempt <= 0)
            {
                MainText.text = LanguageManager.inst.GetString("lose");
                InputField.interactable = false;
                DataManager.s_inst.Money -= NumberManager.s_inst.reward;
                ChangeEmotionEvent?.Invoke(Static.CharacterEmotions.angry);
                StartCoroutine(WaitForScene(4));
            }
        }
        catch (System.Exception)
        {
            MainText.text = LanguageManager.inst.GetString("wrong");
        }
    }
    private IEnumerator WaitForScene(int time)
    {
        if (Static.s_WithoutAd >= 2)
        {
            AdsManager.s_inst.LoadVideoAd();
            Static.s_WithoutAd = 0;
        }
        else
            Static.s_WithoutAd++;
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
        FromToText();
        AttemptText();
        MainText.text = LanguageManager.inst.GetString("guess");
        ChangeEmotionEvent?.Invoke(Static.CharacterEmotions.neutral);
    }
    private void RandomLimit()
    {
        NumberManager.s_inst.ChangeTotalRandom(NumberManager.s_inst.maxRandom + 50 +
            NumberManager.s_inst.minRandom +
            (int)(NumberManager.s_inst.totalRandom * 0.1));
        NumberManager.s_inst.ChangeMinRandom(Random.Range(0, 
            (int)(NumberManager.s_inst.totalRandom * 0.2)));
        NumberManager.s_inst.ChangeMaxRandom(NumberManager.s_inst.totalRandom -
            NumberManager.s_inst.minRandom);
        NumberManager.s_inst.GenerateRandomNumber();
    }
    private void AttemptText()
    {
        AttemptsText.text = $"{LanguageManager.inst.GetString("attempt")}: {currentAttempt}";
    }
    private void FromToText()
    {
        NumText.text = $"{LanguageManager.inst.GetString("from")}" +
            $" {NumberManager.s_inst.minRandom}" +
            $" {LanguageManager.inst.GetString("to")}" +
            $" {NumberManager.s_inst.maxRandom}";
    }
    public bool IsPlayerPlayed()
    {
        return currentAttempt < CurrentLevel.Attempts ? true : false;
    }
}
