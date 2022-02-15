using TMPro;
using UnityEngine;

public class TranslationText : MonoBehaviour
{
    [SerializeField]
    private string stringKey;
    private TMP_Text txt;
    private void Awake()
    {
        txt = GetComponent<TMP_Text>();
        LanguageManager.inst.OnLanguageChangeEvent += ChangeText;
    }
    private void OnEnable()
    {
        ChangeText();
    }
    private void OnDestroy()
    {
        LanguageManager.inst.OnLanguageChangeEvent -= ChangeText;
    }
    private void ChangeText()
    {
        txt.text = LanguageManager.inst.GetString(stringKey);
    }
}
