using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager s_inst;
    public int Money { set; get; } = 0;
    private string path;
    private bool firstLaunch = true;

    public Color32 BackGroundColor = new Color32(255, 250, 172, 255);

    public delegate void FirstLaunchTimeDelegate();
    public event FirstLaunchTimeDelegate FirstLaunchTimeEvent;

    private void Awake()
    {
        if (s_inst == null) s_inst = this;
        else if (s_inst != this) Destroy(gameObject);
        if (firstLaunch)
        {
            DontDestroyOnLoad(this);
            path = Application.persistentDataPath + "/save.save";
            Load();
            firstLaunch = false;
            FirstLaunchTimeEvent?.Invoke();
        }
    }
    public class Data
    {
        public int money;
        public Color32 backGroundColor;
    }
    private void Save()
    {
        Data data = new Data();
        data.money = Money;
        data.backGroundColor = BackGroundColor;
        File.WriteAllText(path, JsonUtility.ToJson(data));
    }
    private void Load()
    {
        if (File.Exists(path))
        {
            Data data = JsonUtility.FromJson<Data>(File.ReadAllText(path));
            Money = data.money;
            BackGroundColor = data.backGroundColor;
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
