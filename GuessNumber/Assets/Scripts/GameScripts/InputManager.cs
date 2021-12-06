using UnityEngine;
using TMPro;

public class InputManager : MonoBehaviour
{
    private TMP_InputField currentNum;
    private GameManager gameManager;
    private void Awake()
    {
        currentNum = GetComponent<TMP_InputField>();
        gameManager = FindObjectOfType<GameManager>();
    }
    public void AddNumber(int num)
    {
        currentNum.text += num;
    }
    public void DeleteNumber()
    {
        if (currentNum.text.Length > 0)
            currentNum.text = currentNum.text.Remove(currentNum.text.Length - 1);
    }
    public void AcceptNumber()
    {
        if (currentNum.text.Length > 0)
            gameManager.GuessNumber(int.Parse(currentNum.text));
    }
}
