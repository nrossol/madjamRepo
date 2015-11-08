using System;
using System.Collections.Generic;

using UnityEngine;

public class GUIUpdater : MonoBehaviour
{
    public GameManager gameManager;
    public PlayerHealth playerHealth;

    public TextMesh healthText;
    public TextMesh scoreText;

    public void Awake()
    {
        playerHealth.OnDamage += OnDamage;
    }

    public void Start()
    {
        OnDamage(); // Update health GUI.
    }

    public void Update()
    {
        scoreText.text = "Score: " + ((int)gameManager.surivedTime).ToString();
    }

    public void OnDamage()
    {
        healthText.text = "Health: " + playerHealth.Health;
    }


}
