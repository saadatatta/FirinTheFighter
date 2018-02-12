using UnityEngine;
using System.Collections;

public class SaveLoadManager : Singleton<SaveLoadManager>
{
    public FileManager FileManager { get; private set; }

    private void Awake()
    {
        LoadDataFromFile();
    }

    public void SaveDataToFile()
    {
        PlayerStats playerStats = PlayerStats.Instance;

        SerializablePlayerStats stats = new SerializablePlayerStats(playerStats.AttackStat, playerStats.HealthStat, playerStats.ExperienceStat);
        LevelState state = new LevelState(playerStats.CurrentExperienceLevel,playerStats.CurrentAttackLevel,playerStats.CurrentHealthLevel);
        FileManager = new FileManager(stats,state);
        SaveData.Save(FileManager);
    }

    public void LoadDataFromFile()
    {
        FileManager fm = LoadData.Load();
        FileManager = fm;
    }

    private void OnApplicationQuit()
    {
        SaveDataToFile();
    }

}
