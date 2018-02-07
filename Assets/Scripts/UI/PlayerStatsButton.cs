
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsButton : MonoBehaviour {

    [SerializeField] private Canvas canvas;
    [SerializeField] private Button playerStatBtn;
    [SerializeField] private Button canvasCloseBtn;

    private void Start()
    {
        playerStatBtn.onClick.AddListener(ShowStatsCanvas);
        canvasCloseBtn.onClick.AddListener(HideStatsCanvas);
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
}
