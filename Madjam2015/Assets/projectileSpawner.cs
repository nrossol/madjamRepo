using UnityEngine;
using System.Collections;

public class projectileSpawner : MonoBehaviour {

    public float spawnDistance = 11.0f;

    public float spawnAngleMin = -110.0f;
    public float spawnAngleMax = 110.0f;
    public Vector3 globalForwardSpawnDirection = Vector3.right;

    public float minSpawnHeight = -1.0f;
    public float maxSpawnHeight = 1.0f;
    public float spawnOffset = 1.0f;
    public float spawnVelocity = 5.0f;


    public float minTargetHeight = -0.35f;
    public float maxTargetHeight = 0.45f;
    public float targetOffset = 0.4f;

    public float minTimeBetweenLaunches = 0.1f;
    public float maxTimeBetweenLaunches = 5.0f;

    public GameObject shurikenPrefab;

    private float timeOfNextLaunch = 0.0f;

    public bool shouldBeSpawingStuffNow = false;

	// Use this for initialization
	void Start () {
        this.timeOfNextLaunch = Time.time + Random.Range(this.minTimeBetweenLaunches, this.maxTimeBetweenLaunches);
	}
	
	// Update is called once per frame
	void Update () {
	    if(shouldBeSpawingStuffNow && Time.time > this.timeOfNextLaunch)
        {
            this.LaunchNewProjectile();
            this.timeOfNextLaunch = Time.time + Random.Range(this.minTimeBetweenLaunches, this.maxTimeBetweenLaunches);
        }
    }

    void LaunchNewProjectile()
    {
        Vector3 randomTargetOffset = new Vector3(Random.Range(-this.targetOffset,this.targetOffset),
            Random.Range(this.minTargetHeight, this.maxTargetHeight) , Random.Range(-this.targetOffset, this.targetOffset));
        Vector3 randomSpawnOffset = new Vector3(Random.Range(-this.spawnOffset, this.spawnOffset), 
            Random.Range(this.minSpawnHeight, this.maxSpawnHeight) , Random.Range(-this.spawnOffset, this.spawnOffset));

        Vector3 spawnDirection = globalForwardSpawnDirection;
        Quaternion yawRotation = Quaternion.Euler(0, Random.Range(this.spawnAngleMin, this.spawnAngleMax), 0);
        spawnDirection = yawRotation * spawnDirection;

        Vector3 newProjectilePosition = this.transform.position + spawnDirection * spawnDistance + randomSpawnOffset;

        GameObject newProjectile = (GameObject)Instantiate(shurikenPrefab, newProjectilePosition, Quaternion.identity);
        newProjectile.transform.LookAt(this.transform.position + randomTargetOffset);
        newProjectile.transform.Rotate(0, 0, Random.Range(0, 360));
        ShurikenBehaviour shuriken = newProjectile.GetComponent<ShurikenBehaviour>();
        shuriken.speed = this.spawnVelocity;
        if(newProjectilePosition.y < 0)
        {
            Debug.Log("Object spawned with height of "+newProjectilePosition.y);
        }
    }

}
