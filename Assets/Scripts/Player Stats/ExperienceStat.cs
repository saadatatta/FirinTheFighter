using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[System.Serializable]
public class ExperienceStat
{
    int experienceStats;
    private int currentExperienceLevel;

    public ExperienceStat()
    {
        experienceStats = 0;
        currentExperienceLevel = 1;
    }

    public void AddStat(int value)
    {

        experienceStats += value;
        PlayerStatTexts.Instance.ExperienceLevelValueText.text = DisplayExperienceStat();
    }

   
    public string DisplayExperienceStat()
    {
        int statSum = experienceStats;
        int levelMaxValue = ExperienceStatValues.FindLevelMaxValue(currentExperienceLevel);

        if (IsLevelUpgraded(statSum, levelMaxValue))
        {
            currentExperienceLevel++;
            PlayerStats.Instance.IncrementCurrentExperienceLevel();
            //Max value of next level.
            levelMaxValue = ExperienceStatValues.FindLevelMaxValue(currentExperienceLevel);
            ShowUpgradeButtons();
        }
        PlayerStats.Instance.gameObject.transform.GetComponent<PlayerStatsButton>().ExperienceSliderFillImage.fillAmount = statSum / (float)levelMaxValue * 100;
        return string.Format("{0} / {1}", statSum,levelMaxValue);

    }

    /// <summary>
    /// Show upgrade buttons for health and attack.
    /// </summary>
    void ShowUpgradeButtons()
    {
        PlayerStatsButton buttons = PlayerStatTexts.Instance.gameObject.transform.GetComponent<PlayerStatsButton>();

        buttons.UpgradeAttackLvlBtn.gameObject.SetActive(true);
        buttons.UpgradeHealthLvlBtn.gameObject.SetActive(true);
    }

    /// <summary>
    /// Checks if the player experience level is upgraded.
    /// </summary>
    /// <param name="experienceSum">Current sum of all experience levels.</param>
    /// <param name="currentExperienceLevelMaxValue">Maximum value of current experience level.</param>
    /// <returns>True if sum is greater than max value.</returns>
    public bool IsLevelUpgraded(int experienceSum, int currentExperienceLevelMaxValue)
    {
        if (experienceSum > currentExperienceLevelMaxValue)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
