using UnityEngine;
using UnityEngine.UI;

public class EmotionsManager : MonoBehaviour
{
    [SerializeField]
    private Sprite[] character;
    private Image image;
    private GameManager gameManager;
    private void Awake()
    {
        image = GetComponent<Image>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        gameManager.ChangeEmotionEvent += ChangeEmotion;
    }
    private void ChangeEmotion(Static.CharacterEmotions index)
    {
        image.sprite = character[(int)index];
    }
}
