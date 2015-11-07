using UnityEngine;
using System.Collections;

public class LimitedLifetime : MonoBehaviour {

    public float lifeTime = 10.0f;

	// Use this for initialization
	void Start () {
        Object.Destroy(this.gameObject, this.lifeTime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
