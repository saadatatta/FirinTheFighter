using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ExperienceStat : MonoBehaviour
{
    List<BaseStat> experienceStatsList = new List<BaseStat>();

    public void AddStat(BaseStat stat)
    {
        experienceStatsList.Add(stat);
        CalculateStats();
    }

    private int CalculateStats()
    {
        if (experienceStatsList.Count == 0)
        {
            return 0;
        }

        return experienceStatsList.Sum(x => x.StatValue);

    }
}
