using System;
using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour 
{
    public Action OnDamage;

    //public GameManager gameManager;
    public float Health { get; private set; }

    private void OnCollisionEnter(Collision collision)
    {
        Health--;

        if (Health <= 0)
        {
            //gameManager.EndGame();
        }

        if (OnDamage != null)
        {
            OnDamage();
        }
    }
}
