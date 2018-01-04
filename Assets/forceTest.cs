using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forceTest : MonoBehaviour {
    float force = .05f;
    public Rigidbody rigidbody;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidbody.AddForce(Vector3.up * force, ForceMode.Impulse);
            rigidbody.useGravity = false;
        }
        else
            rigidbody.useGravity = true;

        rigidbody.AddForce(Vector3.forward * Input.GetAxis("Vertical") * force, ForceMode.Impulse);
    }

}
