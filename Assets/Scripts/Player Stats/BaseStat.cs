using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseStat
{
    private System.Guid statId;
    private string statName;
    private int statValue;
    private StatType statType;

    public BaseStat(string statName,StatType statType,int statValue)
    {
        this.statId = System.Guid.NewGuid();
        this.statName = statName;
        this.statType = statType;
        this.statValue = statValue;
    }

    public int StatValue
    {
        get { return statValue; }
    }
}
