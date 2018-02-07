using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour {

    [SerializeField] private Texture image;
    [SerializeField] private string[] dialogues;
    

    private int index = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            DialogueManager.Instance.DialoguePanel.SetActive(true);
            DialogueManager.Instance.ContinueButton.onClick.AddListener(NextDialogue);
            Time.timeScale = 0f;
        }
    }

    private void NextDialogue()
    {
        DialogueManager.Instance.DialogueCharacterImage.texture = image;

        if (index >= dialogues.Length)
            DialogueManager.Instance.DialogueCharacterText.text = dialogues[dialogues.Length - 1];
        else
            DialogueManager.Instance.DialogueCharacterText.text = dialogues[index];

        if (index > dialogues.Length)
        {
            DialogueManager.Instance.DialoguePanel.SetActive(false);
            Time.timeScale = 1.0f;
            Destroy(gameObject);
        }
        index++;
    }

}
