using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager s_inst;
    public int Money { set; get; } = 0;
    private string path;
    [SerializeField] private Sprite[] arrayOfSprite;

    public Color32 ButtonColor = new Color32(255, 255, 255, 255);
    private Sprite buttonImage;
    public Sprite ButtonImage
    { 
        get
        {
            if (buttonImage == null)
            {
                foreach (Sprite spr in arrayOfSprite)
                {
                    if (PlayerPrefs.GetInt(spr.name) == 2)
                        buttonImage = spr;
                }
            }
            return buttonImage;
        }
        set 
        {
            if (buttonImage != null)
            {
                PlayerPrefs.SetInt(buttonImage.name, 1);
            }
            buttonImage = value;
            PlayerPrefs.SetInt(buttonImage.name, 2);
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
        s_inst = this;
        foreach (Sprite spr in arrayOfSprite)
        {
            if (PlayerPrefs.GetInt(spr.name) == 2)
                ButtonImage = spr;
        }
        if (ButtonImage == null)
            ButtonImage = arrayOfSprite[0];

        path = Application.persistentDataPath + "/save.save";
        Load();
    }
    public class Data
    {
        public int money;
        public Color32 buttonColor;
        public Sprite buttonImage;
    }
    private void Save()
    {
        Data data = new Data();
        data.money = Money;
        data.buttonColor = ButtonColor;
        File.WriteAllText(path, JsonUtility.ToJson(data));
    }
    private void Load()
    {
        if (File.Exists(path))
        {
            Data data = JsonUtility.FromJson<Data>(File.ReadAllText(path));
            Money = data.money;
            ButtonColor = data.buttonColor;
        }
    }

    private void OnApplicationFocus(bool focus)
    {
        Save();
    }
    private void OnApplicationPause(bool pause)
    {
        Save();
    }
}
