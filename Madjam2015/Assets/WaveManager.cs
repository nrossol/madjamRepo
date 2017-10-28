using System;
using System.Collections.Generic;

using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameManager gameManager;
    public projectileSpawner spawner;

    public int currentWave { get; private set; }

    public const float startingShruikenSpeed = 5.0F;
    public const float startingShurikenSpawnRate = 1.0F;

    public float speedMultiplierPerWave = 1.2F;
    public float maxSpawnRateMultiplierPerWave = 0.8F; // Confusing Name?

    private const float waveDuration = 30.0F;

    private float nextWaveAt = waveDuration;
    private float currentTime;

    public void Awake()
    {
        gameManager.OnGameStart += OnGameStart;
    }

    public void Update()
    {
        if (!gameManager.GameOver)
        {
            if (gameManager.surivedTime >= waveDuration)
            {
                NextWave();
            }
        }
    }

    public void OnGameStart()
    {
        currentWave = 1;

        spawner.spawnVelocity = startingShruikenSpeed;
        spawner.maxTimeBetweenLaunches = startingShurikenSpawnRate;
    }

    public void NextWave()
    {
        currentWave++;

        spawner.spawnVelocity *= speedMultiplierPerWave;
        spawner.maxTimeBetweenLaunches *= maxSpawnRateMultiplierPerWave;
    }
}
