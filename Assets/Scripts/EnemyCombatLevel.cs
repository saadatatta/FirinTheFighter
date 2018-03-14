using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Assertions;

public class EnemyCombatLevel : MonoBehaviour {

    [SerializeField] private int combatLevel;
    [SerializeField] private TextMeshPro combatUI;
    [SerializeField] private Enemy enemy;

    private RectTransform combatUIRect;

    public int CombatLevel
    {
        get { return combatLevel; }
    }

    private void Awake()
    {
        Assert.IsNotNull(combatUI);
        Assert.IsNotNull(enemy);
    }

    private void Start()
    {
        combatUI.text = string.Format("Level {0}", combatLevel);
        combatUIRect = combatUI.rectTransform;
    }

    private void Update()
    {
        if (!enemy.IsMovingRight)
        {
            combatUIRect.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            combatUIRect.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

}
