using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private Transform _player;

    private Timer _timer;

    public Timer Timer
    {
        get
        {
            if (_timer == null)
                _timer = GetComponent<Timer>();
            return _timer;
        }
    }

    public Transform Player
    {
        get { return _player; }
    }

    void Awake()
    {
        Assert.IsNotNull(_player);
    }

}
