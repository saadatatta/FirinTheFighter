using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectiveComplete : MonoBehaviour {

    [SerializeField] private GameObject objectiveCompleteText;
    [SerializeField] private ushort nextSceneBuildIndex;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            objectiveCompleteText.SetActive(true);
            GameManager.Instance.IncrementLevel();
            GameManager.Instance.Timer.Add(LoadNextScene,5f);
        }
    }

    void LoadNextScene()
    {
        objectiveCompleteText.SetActive(false);
      SceneManager.LoadScene(nextSceneBuildIndex);
    }
}
