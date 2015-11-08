using System;
using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
    public event Action OnGameStart;
    public event Action OnGameEnd;

    public GUIManager guiManager;
    public GameObject[] objectsToEnableDisable;
    public MonoBehaviour[] scriptsToEnableDisable;

    public float surivedTime { get; private set; }
    public bool GameOver { get; private set; }

    bool firstTimePlaying = true;

    public void Start()
    {
        StartGame();
    }

    public void EndGame()
    {
        guiManager.SetTextGUI(GUIManager.GUIText.gameOver, true);
        GameOver = true;
        EnableDisableGameObjects(false);

        GameObject[] itemsToCleanUp = GameObject.FindGameObjectsWithTag("Cleanupable");
        foreach (GameObject item in itemsToCleanUp)
        {
            Destroy(item);
        }

        if (OnGameEnd != null)
        {
            OnGameEnd();
        }   
    }

    public void StartGame()
    {
        surivedTime = 0.0F;

        if (firstTimePlaying)
        {
            guiManager.DisplayAndFade(GUIManager.GUIText.Tutorial);
            firstTimePlaying = false;
        }

        guiManager.SetTextGUI(GUIManager.GUIText.gameOver, false);

        GameOver = true;
        EnableDisableGameObjects(true);
        OnGameStart();
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

        if (!GameOver)
        {
            surivedTime += Time.deltaTime;
        }
    }

}
