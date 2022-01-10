using UnityEngine;
using TMPro;

public class InputManager : MonoBehaviour
{
    private TMP_InputField currentNum;
    private GameManager gameManager;
    private bool selected;
    private void Awake()
    {
        currentNum = GetComponent<TMP_InputField>();
        gameManager = FindObjectOfType<GameManager>();
    }
    public void AddNumber(int num)
    {
        if (!selected)
        {
            currentNum.text += num;
        }
        else
        {
            currentNum.text = num.ToString();
            selected = false;
        }
    }
    public void DeleteNumber()
    {
        if (currentNum.text.Length > 0)
        {
            selected = false;
            currentNum.text = currentNum.text.Remove(currentNum.text.Length - 1);
        }
    }
    public void DeleteNumberWhole()
    {
        if (currentNum.text.Length > 0)
        {
            selected = false;
            currentNum.text = currentNum.text.Remove(0);
        }
    }
    public void AcceptNumber()
    {
        if (currentNum.text.Length > 0)
        {
            if (!gameManager.CurrentLevel.Endless)
            {
                gameManager.GuessNumber(int.Parse(currentNum.text));
                selected = true;
            }
            else
            {
                gameManager.EndlessMode(int.Parse(currentNum.text));
                selected = true;
            }
        }
    }
}
