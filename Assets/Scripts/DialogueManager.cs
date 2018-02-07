using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : Singleton<DialogueManager> {

    [SerializeField] private TextMeshProUGUI objectiveDetailsText;
    [SerializeField] private RawImage dialogueCharacterImage;
    [SerializeField] private TextMeshProUGUI dialogueCharacterText;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private Button continueButton;

    public TextMeshProUGUI ObjectiveDetailsText
    {
        get { return objectiveDetailsText; }
        set
        {
            if (value.text != "")
            {
                objectiveDetailsText.text = value.text;
            }
        }
    }

    public TextMeshProUGUI DialogueCharacterText
    {
        get { return dialogueCharacterText; }
        set
        {
            if (value.text != "")
            {
                dialogueCharacterText.text = value.text;
            }
        }
    }

    public RawImage DialogueCharacterImage
    {
        get { return dialogueCharacterImage; }
        set
        {
            if (value.texture != null)
            {
                dialogueCharacterImage.texture = value.texture;
            }
        }
    }

    public GameObject DialoguePanel
    {
        get { return dialoguePanel; }
    }

    public Button ContinueButton
    {
        get { return continueButton; }
    }

}
