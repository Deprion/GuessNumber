using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager s_inst;
    public int Money { set; get; } = 0;
    private string path;
    [SerializeField] private Sprite[] arrayOfSprite;
    [SerializeField] private Color32[] arrayOfColor;

    private Color32 buttonColor;
    public Color32 ButtonColor
    { 
        get
        {
            if (buttonColor == Color.clear)
            {
                foreach (Color clr in arrayOfColor)
                {
                    if (PlayerPrefs.GetInt(clr.ToString()) == 2)
                        buttonColor = clr;
                }
            }
            return buttonColor;
        }
        set
        {
            if (buttonColor != Color.clear)
            {
                PlayerPrefs.SetInt(buttonColor.ToString(), 1);
            }
            buttonColor = value;
            PlayerPrefs.SetInt(buttonColor.ToString(), 2);
        }
    }
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

        if (ButtonImage == null)
            ButtonImage = arrayOfSprite[0];

        if (ButtonColor == Color.black)
            ButtonColor = arrayOfColor[0];

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
