using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveComplete : MonoBehaviour {

    [SerializeField] private GameObject objectiveCompleteText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            objectiveCompleteText.SetActive(true);
            GameManager.Instance.IncrementLevel();
        }
    }
}
