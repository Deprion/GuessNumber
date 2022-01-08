using UnityEngine;
using TMPro;

public class LevelCompleteButton : MonoBehaviour
{
    [SerializeField]
    private GameObject complete;
    private void Start()
    {
        string num = GetComponentInChildren<TMP_Text>().text;
        if (PlayerPrefs.GetInt($"level_{num}", 0) == 1)
        {
            complete.SetActive(true);
        }
    }
}
