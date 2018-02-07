using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombatLevel : MonoBehaviour {

    [SerializeField] private int combatLevel;

    public int CombatLevel
    {
        get { return combatLevel; }
    }

}
