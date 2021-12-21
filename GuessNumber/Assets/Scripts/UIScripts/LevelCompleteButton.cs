using UnityEngine;
using TMPro;

public class LevelCompleteButton : MonoBehaviour
{
    [SerializeField]
    private GameObject complete;
    [SerializeField]
    private LevelSO level;
    private void Start()
    {
        string num = GetComponentInChildren<TMP_Text>().text;
        if (level.Completed)
        {
            complete.SetActive(true);
        }
    }
}
