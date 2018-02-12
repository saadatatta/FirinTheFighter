[System.Serializable]

public static class ExperienceStatNames
{
    public static string Level1 = "Sepoy";
    public static string Level2 = "Corporal";
    public static string Level3 = "Seargent";

    public static string GetExperienceLevelName(int level)
    {
        string name = "";
        switch (level)
        {
            case 1:
                name = Level1;
                break;

            case 2:
                name = Level2;
                break;

            case 3:
                name = Level3;
                break;
            default:
                break;
        }
        return name;
    }
}
