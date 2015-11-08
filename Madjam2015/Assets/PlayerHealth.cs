using System;
using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour 
{
    public Action OnDamage;

    public GameManager gameManager;
    public int startingHealth;
    public int Health { get; private set; }

    public void Awake()
    {
        gameManager.OnGameStart += OnGameStart;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Health--;

        if (Health <= 0)
        {
            gameManager.EndGame();
        }

        if (OnDamage != null)
        {
            OnDamage();
        }
    }

    public void OnGameStart()
    {
        Health = startingHealth;
    }
}
