using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

    private Player _player;

    [SerializeField] private Transform[] _hearts; 

    void Start()
    {
        _player = GameManager.Instance.Player.GetComponent<Player>();
        StartCoroutine(CheckHealth());
    }

    /// <summary>
    /// Check the health so relevant sprites can be displayed.
    /// </summary>
    /// <returns></returns>
    IEnumerator CheckHealth()
    {
        int heartsRemaining = Mathf.CeilToInt(_player.PlayerHealth / 25f);
        
        for (int i = heartsRemaining; i < _hearts.Length; i++)
        {
            _hearts[i].gameObject.SetActive(false);
        }
        yield return new WaitForSeconds(.5f);
        StartCoroutine(CheckHealth());

    }

}
