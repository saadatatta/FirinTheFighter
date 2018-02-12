using UnityEngine;
using System.Collections;
using System;

public class PlayerStats : Singleton<PlayerStats>
{
    public System.Action<ExperienceStat> OnEnemyDeath;

    private AttackStat attackStat = new AttackStat();
    private HealthStat healthStat = new HealthStat();
    private ExperienceStat experienceStat = new ExperienceStat();

    private int currentExperienceLevel;
    private int currentAttackLevel;
    private int currentHealthLevel;

    public AttackStat AttackStat { get { return attackStat; } }
    public HealthStat HealthStat { get { return healthStat; } }
    public ExperienceStat ExperienceStat { get { return experienceStat; } }

    public int CurrentExperienceLevel { get { return currentExperienceLevel; } }
    public int CurrentAttackLevel { get { return currentAttackLevel; } }
    public int CurrentHealthLevel { get { return currentHealthLevel; } }

    private void Start()
    {
        SetLevelState();
        SetPlayerStat();
    }

    /// <summary>
    /// Sets the levels of player stats when the game starts.
    /// </summary>
    void SetLevelState()
    {
        LevelState playerLevel = SaveLoadManager.Instance.FileManager.LevelState;

        if (playerLevel.ExperienceLevel == 0)
            currentExperienceLevel = 1;
        else
            currentExperienceLevel = playerLevel.ExperienceLevel;

        if (playerLevel.HealthLevel == 0)
            currentHealthLevel = 1;
        else
            currentHealthLevel = playerLevel.HealthLevel;

        if (playerLevel.AttackLevel == 0)
            currentAttackLevel = 1;
        else
            currentAttackLevel = playerLevel.AttackLevel;

        ShowLevelStats();
    }

    void ShowLevelStats()
    {
        PlayerStatTexts.Instance.AttackLevelText.text = AttackStatNames.GetAttackLevelName(currentAttackLevel);
        PlayerStatTexts.Instance.HealthLevelText.text = HealthStatNames.GetHealthLevelName(currentHealthLevel);
        PlayerStatTexts.Instance.ExperienceLevelText.text = ExperienceStatNames.GetExperienceLevelName(currentExperienceLevel);
    }

    /// <summary>
    /// Set the lists of player stats when the game starts.
    /// </summary>
    void SetPlayerStat()
    {
        SerializablePlayerStats playerState = SaveLoadManager.Instance.FileManager.SerializablePlayerStats;
        
        attackStat = playerState.AttackStat;
        healthStat = playerState.HealthStat;

        if (playerState.ExperienceStat.ListItemsCount == 0)
            experienceStat.AddStat(new BaseStat(ExperienceStatNames.Level1, StatType.ExperienceStat, ExperienceStatValues.Level1));
        else
            experienceStat = playerState.ExperienceStat;

        ShowPlayerStats();
    }

    void ShowPlayerStats()
    {
        PlayerStatTexts.Instance.AttackLevelValueText.text = attackStat.DisplayDamage();
        PlayerStatTexts.Instance.HealthLevelValueText.text = healthStat.DisplayHealth();
        PlayerStatTexts.Instance.ExperienceLevelValueText.text = experienceStat.DisplayExperienceStat();
    }

    private void Update()
    {
        if (OnEnemyDeath != null)
        {
            OnEnemyDeath(experienceStat);
        }
    }

    public void IncrementCurrentExperienceLevel()
    {
        currentExperienceLevel++;
    }

    public void IncrementAttackLevel()
    {
        currentAttackLevel++;
    }

    public void IncrementHealthLevel()
    {
        currentHealthLevel++;
    }

}
