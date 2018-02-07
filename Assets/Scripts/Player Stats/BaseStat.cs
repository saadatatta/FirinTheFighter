using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStat{

    private int statId;
    private string statName;
    private int statValue;

    public BaseStat(int statId,string statName,int statValue)
    {
        this.statId = statId;
        this.statName = statName;
        this.statValue = statValue;
    }

    public int StatValue
    {
        get { return statValue; }
    }
}
