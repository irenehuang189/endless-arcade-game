﻿using UnityEngine;
using System.Collections;

public class GameControlScript : MonoBehaviour {
    public bool isGameOver = false;
    public GUISkin skin;
    public string levelToLoad;
    private float timeRemaining = 10;
    private float timeExtension = 3;
    private float timeReduction = 2;
    private float totalTimeElapsed = 0;
    private float score = 0;

	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
        if (!isGameOver)
        {
            totalTimeElapsed += Time.deltaTime;
            score = totalTimeElapsed * 100;
            timeRemaining -= Time.deltaTime;
            if (timeRemaining <= 0)
            {
                isGameOver = true;
            }
        }
	}

    void OnGUI() {
        GUI.skin = skin;
        if (!isGameOver)
        {
            GUI.Label(new Rect(10, 10, Screen.width / 5, Screen.height / 6), "TIME LEFT: " + ((int)timeRemaining).ToString());
            GUI.Label(new Rect(5 * Screen.width / 6, 10, Screen.width / 6, Screen.height / 6), "SCORE: " + ((int)score).ToString());
        }
        else
        {
            GUI.Box(new Rect(Screen.width / 4, Screen.height / 4, Screen.width / 2, Screen.height / 2), "GAME OVER\nYOUR SCORE: " + (int)score);

            if (GUI.Button(new Rect(Screen.width / 4 + 20, Screen.height / 4 + Screen.height / 10 + 10, Screen.width / 2 - 40, Screen.height / 10), "RESTART"))
            {
                Application.LoadLevel(Application.loadedLevel);
            }

            if (GUI.Button(new Rect(Screen.width / 4 + 20, Screen.height / 4 + 2 * Screen.height / 10 + 10, Screen.width / 2 - 40, Screen.height / 10), "MAIN MENU"))
            {
                Application.LoadLevel(levelToLoad);
            }

            if (GUI.Button(new Rect(Screen.width / 4 + 20, Screen.height / 4 + 3 * Screen.height / 10 + 10, Screen.width / 2 - 40, Screen.height / 10), "EXIT GAME"))
            {
                Application.Quit();
            }
        }
    }

    public void PowerUpCollected() {
        timeRemaining += timeExtension;
    }

    public void ObstacleCollected() {
        timeRemaining -= timeReduction;
    }
}
