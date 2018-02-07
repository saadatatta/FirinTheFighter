using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HealthStat : MonoBehaviour
{
    List<BaseStat> healthStatsList = new List<BaseStat>();

    public void AddStat(BaseStat stat)
    {
        healthStatsList.Add(stat);
    }
}
