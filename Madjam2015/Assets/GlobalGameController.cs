using UnityEngine;
using System.Collections;

public class GlobalGameController : MonoBehaviour {

    public int startingHealth = 5;
    public float timeBetweenWaves = 30;
    public float healthDisplayTime = 2.1f;
    public float waveDisplayTime = 2.1f;


    public TextMesh welcomeMessage;
    public TextMesh healthRemainingMessage;
    public TextMesh gameOverMessage;
    public TextMesh scoreMessage;
    public TextMesh waveMessage;

    public projectileSpawner shurikenSpawner;

    private int currentHealth = 0;

    private bool gameOver = false;
    private bool gamePlaying = false;

    private float timeHealthMessageShouldBeHidden = 0.0f;
    private float timeWaveMessageShouldBeHidden = 0.0f;

    private float timeGameStarted = 0.0f;

    private int currentWave = 0;
    private float timeOfNextWave = 0.0f;

	// Use this for initialization
	void Start () {
        this.SetGameStateToPreStart();
	}
	
	// Update is called once per frame
	void Update () {

        if (!this.gamePlaying)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                this.SetGameStateToStart();
            }
        }

        if(healthRemainingMessage.GetComponent<Renderer>().enabled && Time.time > this.timeHealthMessageShouldBeHidden)
        {
            healthRemainingMessage.GetComponent<Renderer>().enabled = false;
        }

        if (waveMessage.GetComponent<Renderer>().enabled && Time.time > this.timeWaveMessageShouldBeHidden)
        {
            waveMessage.GetComponent<Renderer>().enabled = false;
        }

        if (this.gamePlaying && Time.time > this.timeOfNextWave)
        {
            this.GoToNextWave();
        }

    }

    void OnCollisionEnter()
    {
        this.currentHealth--;
        if(this.currentHealth <= 0)
        {
            if(this.gamePlaying && !this.gameOver)
            {
                this.SetGameStateToGameOver();
            }//else, if the player is hit after the game is already over, do nothing
        }
        else
        {
            healthRemainingMessage.text = "Health Left: " + this.currentHealth;
            healthRemainingMessage.GetComponent<Renderer>().enabled = true;
            this.timeHealthMessageShouldBeHidden = Time.time + this.healthDisplayTime;
        }
    }

    void SetGameStateToPreStart()
    {
        shurikenSpawner.shouldBeSpawingStuffNow = false;
        this.gameOver = false;
        this.gamePlaying = false;
        this.currentHealth = this.startingHealth;
        welcomeMessage.GetComponent<Renderer>().enabled = true;
        healthRemainingMessage.GetComponent<Renderer>().enabled = false;
        gameOverMessage.GetComponent<Renderer>().enabled = false;
        scoreMessage.GetComponent<Renderer>().enabled = false;
        waveMessage.GetComponent<Renderer>().enabled = false;
    }

    void SetGameStateToStart()
    {
        this.currentWave = 0;
        this.GoToNextWave();
        this.timeGameStarted = Time.time;
        shurikenSpawner.shouldBeSpawingStuffNow = true;
        this.gameOver = false;
        this.gamePlaying = true;
        this.currentHealth = this.startingHealth;
        welcomeMessage.GetComponent<Renderer>().enabled = false;
        healthRemainingMessage.GetComponent<Renderer>().enabled = false;
        gameOverMessage.GetComponent<Renderer>().enabled = false;
        scoreMessage.GetComponent<Renderer>().enabled = false;

    }

    void SetGameStateToGameOver()
    {
        shurikenSpawner.shouldBeSpawingStuffNow = false;
        this.gameOver = true;
        this.gamePlaying = false;
        this.currentHealth = 0;
        welcomeMessage.GetComponent<Renderer>().enabled = false;
        healthRemainingMessage.GetComponent<Renderer>().enabled = true;
        gameOverMessage.GetComponent<Renderer>().enabled = true;
        scoreMessage.GetComponent<Renderer>().enabled = true;
        waveMessage.GetComponent<Renderer>().enabled = false;

        scoreMessage.text = "Awesome! You lasted for " + (int)(Time.time - this.timeGameStarted) + " seconds!";
    }

    void GoToNextWave()
    {
        this.currentWave++;
        this.timeOfNextWave = Time.time + this.timeBetweenWaves;

        waveMessage.text = "Wave: " + this.currentWave;
        waveMessage.GetComponent<Renderer>().enabled = true;
        this.timeWaveMessageShouldBeHidden = Time.time + this.waveDisplayTime;

        switch (this.currentWave)
        {
            case 1:
                shurikenSpawner.spawnVelocity = 2.0f;
                shurikenSpawner.maxTimeBetweenLaunches = 9.0f;

                break;
            case 2:
                shurikenSpawner.spawnVelocity = 3.0f;
                shurikenSpawner.maxTimeBetweenLaunches = 5.0f;

                break;
            case 3:
                shurikenSpawner.spawnVelocity = 4.0f;
                shurikenSpawner.maxTimeBetweenLaunches = 3.5f;

                break;
            case 4:
                shurikenSpawner.spawnVelocity = 5.0f;
                shurikenSpawner.maxTimeBetweenLaunches = 2.0f;
                break;
            default:
                shurikenSpawner.maxTimeBetweenLaunches = 1.0f;
                shurikenSpawner.spawnVelocity = 6.0f;
                break;
        }
    }
}
