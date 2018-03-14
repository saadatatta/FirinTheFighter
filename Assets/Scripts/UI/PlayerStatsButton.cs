
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsButton : MonoBehaviour {

    [SerializeField] private Canvas canvas;
    [SerializeField] private Button playerStatBtn;
    [SerializeField] private Button canvasCloseBtn;
    [SerializeField] private Button upgradeAttackLvlBtn;
    [SerializeField] private Button upgradeHealthLvlBtn;

    [Header("Slider")]
    public Image ExperienceSliderFillImage;

    public Button UpgradeAttackLvlBtn
    {
        get { return upgradeAttackLvlBtn; }
    }

    public Button UpgradeHealthLvlBtn
    {
        get { return upgradeHealthLvlBtn; }
    }

    private void Start()
    {
        playerStatBtn.onClick.AddListener(ShowStatsCanvas);
        canvasCloseBtn.onClick.AddListener(HideStatsCanvas);
        upgradeAttackLvlBtn.onClick.AddListener(UpgradeAttackLevel);
        upgradeHealthLvlBtn.onClick.AddListener(UpgradeHealthLevel);
    }

    void ShowStatsCanvas()
    {
        canvas.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    void HideStatsCanvas()
    {
        canvas.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    void UpgradeHealthLevel()
    {
        GetComponent<PlayerStats>().HealthStat.UnlockNextLevel();

        DisableUpgradeBtns();
    }

    void UpgradeAttackLevel()
    {
        GetComponent<PlayerStats>().AttackStat.UnlockNextLevel();
        DisableUpgradeBtns();
    }

    void DisableUpgradeBtns()
    {
        //Disable the buttons after upgrading to next level.
        UpgradeHealthLvlBtn.gameObject.SetActive(false);
        UpgradeAttackLvlBtn.gameObject.SetActive(false);
    }
}
