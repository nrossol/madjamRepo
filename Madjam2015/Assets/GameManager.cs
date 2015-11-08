﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
    public GUIManager guiManager;
    public GameObject[] objectsToEnableDisable;
    public MonoBehaviour[] scriptsToEnableDisable;

    public float surivedTime { get; private set; }
    public bool GameOver { get; private set; }

    bool firstTimePlaying = true;

    public void EndGame()
    {
        GameOver = true;
        EnableDisableGameObjects(false);
    }

    public void StartGame()
    {
        if (firstTimePlaying)
        {
            guiManager.DisplayAndFade(GUIManager.GUIText.Tutorial);
        }

        GameOver = true;
        EnableDisableGameObjects(false);
    }

    private void EnableDisableGameObjects(bool enable)
    {
        foreach (GameObject gameObject in objectsToEnableDisable)
        {
            gameObject.SetActive(enable);
        }

        foreach (MonoBehaviour script in scriptsToEnableDisable)
        {
            script.enabled = enable;
        }
    }

    public void Update()
    {
        if (Input.GetButtonUp("Restart") && GameOver)
        {
            StartGame();
        }

        surivedTime += Time.deltaTime;
    }

}