
[System.Serializable]
public static class AttackStatNames
{
    public static string Level1 = "Rookie";
    public static string Level2 = "Sword Man";
    public static string Level3 = "Banner Man";

    public static string GetAttackLevelName(int level)
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
