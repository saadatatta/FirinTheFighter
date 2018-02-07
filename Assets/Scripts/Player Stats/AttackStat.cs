using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStat : MonoBehaviour {

    List<BaseStat> attackStatsList = new List<BaseStat>();

    public void AddStat(BaseStat stat)
    {
        attackStatsList.Add(stat);
    }
}
