using UnityEngine;
using System.Collections;

public class ShurikenBehaviour : MonoBehaviour {


    public float speed = 2.0f;
    public float lifeTime = 20.0f;

    public GameObject explosionPrefab;
    public ParticleSystem smokeTrail;

    public GameObject spinningBlade;
    public float spinSpeed = 960.0f;

    private Rigidbody shurikenRigidBody;
    private float smokeLingerTime = 12.0f;//Max time smoke trail emitter should be allowed to stick around until being deleted

	// Use this for initialization
	void Start () {
        shurikenRigidBody = GetComponent<Rigidbody>();
        shurikenRigidBody.velocity = transform.forward * speed;

        Object.Destroy(this.gameObject, lifeTime);
	}
	
	// Update is called once per frame
	void Update () {
        this.spinningBlade.transform.Rotate(0, spinSpeed * Time.deltaTime, 0);//Make blade spin
        //this.transform.Translate(0, 0, (speed * Time.deltaTime), Space.Self);
    }

    void OnCollisionEnter()
    {
        this.BlowUp();
    }

    void BlowUp()
    {
        Instantiate(explosionPrefab, this.transform.position, this.transform.rotation);
        if (this.smokeTrail)
        {
            Object.Destroy(this.smokeTrail.gameObject, this.smokeLingerTime);//Eventually garbage collect the smoke trail particle system emitter after all the smoke is long gone
            this.smokeTrail.Stop();//The missile is gone, so stop emitting smoke
            this.smokeTrail.transform.parent = null;//Detach the smoke trail from its parent (should only have 1 parent) so that it won't immediately disappear
        }
        Object.Destroy(this.gameObject);

    }

}
