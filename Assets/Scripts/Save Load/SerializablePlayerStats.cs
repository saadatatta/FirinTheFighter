using UnityEngine;
using System.Collections;

[System.Serializable]
public class SerializablePlayerStats
{
    private AttackStat attackStat;
    private HealthStat healthStat;
    private ExperienceStat experienceStat;

    public SerializablePlayerStats(AttackStat attackStat,HealthStat healthStat,ExperienceStat experienceStat)
    {
        this.attackStat = attackStat;
        this.healthStat = healthStat;
        this.experienceStat = experienceStat;
    }

    public AttackStat AttackStat
    {
        get { return attackStat; }
    }

    public HealthStat HealthStat
    {
        get { return healthStat; }
    }

    public ExperienceStat ExperienceStat
    {
        get { return experienceStat; }
    }
}
