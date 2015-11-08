using System;
using System.Collections.Generic;

using UnityEngine;

public class HealthScoreUpdater : MonoBehaviour
{
    public GameManager gameManager;
    public PlayerHealth health;

    public TextMesh scoreText;
    public TextMesh healthText;

    public void Start()
    {
        health.OnDamage += DamageHandler;
    }

    public void Update()
    {
        scoreText.text = "Score: " + gameManager.surivedTime;
    }

    public void DamageHandler()
    {
        healthText.text = "Health: " + health.Health;
    }
}

