
[System.Serializable]
public class AttackStat
{
    private ushort attackDamage;
    private ushort currentLevel;

    public AttackStat()
    {
        attackDamage = AttackStatValues.Level1;
        currentLevel = 1;
    }

    public ushort AttackDamage
    {
        get { return attackDamage; }
    }

    public void UnlockNextLevel()
    {
        currentLevel++;
        PlayerStats.Instance.IncrementAttackLevel();
        attackDamage = AttackStatValues.GetAttackStatValues(currentLevel);
        PlayerStatTexts.Instance.AttackLevelText.text = AttackStatNames.GetAttackLevelName(currentLevel);
        PlayerStatTexts.Instance.AttackLevelValueText.text = DisplayDamage();
    }

    /// <summary>
    /// Display the damage in player stats UI panel.
    /// </summary>
    /// <returns>Return the current damage value in predefined format.</returns>
    public string DisplayDamage()
    {
        return string.Format("Base Damage \n +{0}", attackDamage);
    }
}
