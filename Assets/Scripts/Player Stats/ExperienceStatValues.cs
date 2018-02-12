[System.Serializable]
public static class ExperienceStatValues
{
    public static ushort Level1 = 500;
    public static ushort Level2 = 1200;
    public static ushort Level3 = 2000;

    /// <summary>
    /// Find the maximum value required to upgrade to next value.
    /// </summary>
    /// <param name="currentExperienceLevel">The current experience level of the player.</param>
    /// <returns>The maximum value of the current level.</returns>
    public static int FindLevelMaxValue(int currentExperienceLevel)
    {
        int experience = 0;
        switch (currentExperienceLevel)
        {
            case 1:
                experience = Level1;
                break;
            case 2:
                experience = Level2;
                break;

            case 3:
                experience = Level3;
                break;
            default:
                break;
        }
        return experience;
    }

}
