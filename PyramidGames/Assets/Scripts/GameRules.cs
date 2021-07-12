using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRules : MonoBehaviour
{
    [SerializeField] private GameObject scoreUi;
    private Score score;
    [HideInInspector]
    public bool hasKey = false;
    public bool keySpawned = false;
    private void Start()
    {
        score = scoreUi.GetComponent<Score>();
    }
    public void GetOut()
   {
        if (hasKey)
        {
            score.DisplayEndGamePanel();
        }
   }
}
