using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using UnityEngine.Networking;
using System.Collections;

public class LanguageManager : MonoBehaviour
{
    public string lang { private set; get; }
    public delegate void OnLanguageChange();
    public OnLanguageChange OnLanguageChangeEvent;
    public static LanguageManager inst;
    private LocalizationData localData;
    private string path;
#if PLATFORM_ANDROID
    private UnityWebRequest www;
#endif
    private void Awake()
    {
        DontDestroyOnLoad(this);
        inst = this;
        path = Application.streamingAssetsPath + "/languages.json";
#if PLATFORM_ANDROID
        StartCoroutine(LoadTranslationAndroid());
#endif
#if !PLATFORM_ANDROID
        LoadTranslation();
#endif
        if (PlayerPrefs.HasKey("lang"))
        {
            lang = PlayerPrefs.GetString("lang");
        }
        else
        {
            if (Application.systemLanguage == SystemLanguage.Russian ||
                Application.systemLanguage == SystemLanguage.Ukrainian ||
                Application.systemLanguage == SystemLanguage.Belarusian)
            {
                lang = SystemLanguage.Russian.ToString();
            }
            else
            {
                lang = SystemLanguage.English.ToString();
            }
            PlayerPrefs.SetString("lang", lang);
        }
    }
#if PLATFORM_ANDROID
    private IEnumerator LoadTranslationAndroid()
    {
        www = UnityWebRequest.Get(path);
        yield return www.SendWebRequest();
        yield return www.isDone;
        localData = JsonConvert.DeserializeObject<LocalizationData>
            (www.downloadHandler.text);
    }
#endif
#if !PLATFORM_ANDROID
    private void LoadTranslation()
    {
        localData = JsonConvert.DeserializeObject<LocalizationData>(File.ReadAllText(path));
    }
#endif
    public void ChangeLang()
    {
        lang = lang == SystemLanguage.Russian.ToString() ? SystemLanguage.English.ToString()
            : SystemLanguage.Russian.ToString();
        PlayerPrefs.SetString("lang", lang);
        OnLanguageChangeEvent?.Invoke();
    }
    public string GetString(string id)
    {
        return localData.translation[lang][id];
    }
    public class LocalizationData
    { 
        public Dictionary<string, Dictionary<string, string>> translation = new
        Dictionary<string, Dictionary<string, string>>();
    } 
}
