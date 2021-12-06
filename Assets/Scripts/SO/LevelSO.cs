using UnityEngine;

[CreateAssetMenu(fileName = "LevelSO", menuName = "LevelSO")]
public class LevelSO : ScriptableObject
{
    public int LevelNum;
    public int Reward;
    public int Lose;
    public int Attempts;
    public int MinNum;
    public int MaxNum;
    public bool Completed;
}
