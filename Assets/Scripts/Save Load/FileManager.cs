using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class FileManager
{
    private SerializablePlayerStats serializablePlayerStats;
    private LevelState levelState;

    public FileManager(SerializablePlayerStats stats,LevelState state)
    {
        serializablePlayerStats = stats;
        levelState = state;
    }

    public SerializablePlayerStats SerializablePlayerStats
    {
        get { return serializablePlayerStats; }
    }

    public LevelState LevelState
    {
        get { return levelState; }
    }
    
}
