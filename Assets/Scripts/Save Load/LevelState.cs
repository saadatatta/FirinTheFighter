using UnityEngine;
using System.Collections;

[System.Serializable]
public struct LevelState 
{
    public int ExperienceLevel { get; private set; }
    public int AttackLevel { get; private set; }
    public int HealthLevel { get; private set; }

    public LevelState(int ExperienceLevel,int AttackLevel,int HealthLevel)
    {
        this.ExperienceLevel = ExperienceLevel;
        this.AttackLevel = AttackLevel;
        this.HealthLevel = HealthLevel;
    }
}
