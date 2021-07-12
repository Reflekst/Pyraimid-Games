using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogPrinter : MonoBehaviour
{
    public GameObject dialogModule, questionPanel, sentencePanel, Player;
    public Text middleText;
    public Button yesButton, noButton, okButton;
    private GameRules rules;
    private SpawnKey spawnKey;

    private void Start()
    {
        rules = Player.GetComponent<GameRules>();
        EndOfDialog();
        
        noButton.onClick.AddListener(EndOfDialog);
        okButton.onClick.AddListener(EndOfDialog);
    }

    public void PrintMiddleText(string who,string text, bool isQuestion)
    {
        dialogModule.SetActive(true);
        middleText.text = text;

        if (isQuestion)
        {
            switch (who)
            {
                case "key":
                    yesButton.onClick.RemoveAllListeners();
                    yesButton.onClick.AddListener(KeyYes);
                    break;
                case "door":
                    yesButton.onClick.RemoveAllListeners();
                    yesButton.onClick.AddListener(DoorYes);
                    break;
                case "chest":
                    yesButton.onClick.RemoveAllListeners();
                    yesButton.onClick.AddListener(ChestYes);
                    break;
            }
            sentencePanel.SetActive(false);
            questionPanel.SetActive(true);
        }
        else
        {
            questionPanel.SetActive(false);
            sentencePanel.SetActive(true);
        }
    }

    void KeyYes()
    {
        EndOfDialog();
        rules.hasKey = true;
        spawnKey.Collect();
    }

    void ChestYes()
    {
        EndOfDialog();
        spawnKey = GameObject.FindGameObjectWithTag("Chest").GetComponent<SpawnKey>();
        spawnKey.Spawn();
        rules.keySpawned = true;
    }

    void DoorYes()
    {
        EndOfDialog();
        rules.GetOut();
    }
    void EndOfDialog()
    {
        dialogModule.SetActive(false);
        questionPanel.SetActive(false);
        sentencePanel.SetActive(false);
    }
}
