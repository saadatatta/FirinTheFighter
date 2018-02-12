using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStatTexts : Singleton<PlayerStatTexts> {

    [Header("Player Stats Level")]
    public TextMeshProUGUI ExperienceLevelText;
    public TextMeshProUGUI AttackLevelText;
    public TextMeshProUGUI HealthLevelText;

    [Header("Player Stats Level Value")]
    public TextMeshProUGUI ExperienceLevelValueText;
    public TextMeshProUGUI AttackLevelValueText;
    public TextMeshProUGUI HealthLevelValueText;
}
