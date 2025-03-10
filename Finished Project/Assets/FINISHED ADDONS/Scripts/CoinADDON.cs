﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinADDON : MonoBehaviour
{
    // ADD TO COIN PREFAB
    // Handles adding score

    public int pointValue = 1;
    private Text scoreText;
    private ScoreADDON scoreADDON;

    private void Start()
    {

        MonoBehaviour[] monoBehaviours = GetComponents<MonoBehaviour>();
        bool found = false;
        foreach (MonoBehaviour monoBehaviour in monoBehaviours)
        {
            if (monoBehaviour.GetType().Name == "Coin")
                found = true;
        }

        if (!found)
        {
            Debug.Log("ERROR: CoinADDON Component placed on GameObject without Coin Script, OR Coin Script named incorrectly, must be named EXACTLY 'Coin'.");
        }

        //Text[] texts = FindObjectsOfType<Text>();
        scoreADDON = FindObjectOfType<ScoreADDON>();
        scoreText = scoreADDON.GetComponent<Text>();
        if (scoreText == null)
        {
            Debug.Log("ERROR: GameCanvas is not present in the scene.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            scoreADDON.AddPoints(pointValue);
            scoreText.text = "Score: " + scoreADDON.score.ToString();
        }
    }
}
