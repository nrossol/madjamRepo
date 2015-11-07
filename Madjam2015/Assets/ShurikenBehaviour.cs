using UnityEngine;
using System.Collections;

public class ShurikenBehaviour : MonoBehaviour {


    public float speed = 2.0f;
    public float lifeTime = 8.0f;

    private Rigidbody shurikenRigidBody;

	// Use this for initialization
	void Start () {
        shurikenRigidBody = GetComponent<Rigidbody>();
        shurikenRigidBody.velocity = transform.forward * speed;

        Object.Destroy(this.gameObject, lifeTime);
	}
	
	// Update is called once per frame
	void Update () {
        //this.transform.Translate(0, 0, (speed * Time.deltaTime), Space.Self);
    }
}
