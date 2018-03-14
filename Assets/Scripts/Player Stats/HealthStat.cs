
[System.Serializable]
public class HealthStat
{
    private ushort healthIncrement;
    private ushort currentLevel;

    public HealthStat()
    {
        healthIncrement = HealthStatValues.Level1;
        currentLevel = 1;
    }

    public ushort HealthIncrement
    {
        get { return healthIncrement; }
    }

    public void UnlockNextLevel()
    {
        currentLevel++;
        PlayerStats.Instance.IncrementHealthLevel();
        healthIncrement = HealthStatValues.GetHealthStatValues(currentLevel);
        PlayerStatTexts.Instance.HealthLevelText.text = HealthStatNames.GetHealthLevelName(currentLevel);
        PlayerStatTexts.Instance.HealthLevelValueText.text = DisplayHealth();
    }
    

    /// <summary>
    /// Display the health in player stat UI panel.
    /// </summary>
    /// <returns>Return the current health value in predefined string format.</returns>
    public string DisplayHealth()
    {
        return string.Format("Base Health \n +{0}", healthIncrement);
    }

}
