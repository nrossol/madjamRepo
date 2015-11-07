using UnityEngine;
using System.Collections;

public class SimpleMovementController : MonoBehaviour {

    public float forwardMoveSpeed = 0.5f;//Value is in m/s
    public float turnSpeed = 80.0f;//value is in degrees per second

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        float forwardMoveAmount = Input.GetAxis("Vertical") * this.forwardMoveSpeed;
        float angularTurnAmount = Input.GetAxis("Horizontal") * this.turnSpeed * Time.deltaTime;

        this.transform.Translate(0, 0, forwardMoveAmount);
        this.transform.Rotate(0, angularTurnAmount, 0);
    }
}
