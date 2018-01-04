using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingBird : MonoBehaviour {

    public float horizontalSpeed;
    public float verticalSpeed;
    public float amplitude;
    public float speed;
    public GameObject cursor;

    public Vector3 tempPosition;

    // Use this for initialization
    void Start () {
        tempPosition = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //tempPosition.x += horizontalSpeed;
        //tempPosition.y = Mathf.Sin(Time.realtimeSinceStartup * verticalSpeed) * amplitude;
        //Debug.Log(cursor.transform.position.x);
        tempPosition.x = cursor.transform.position.x * 500;
        tempPosition.y = cursor.transform.position.y * 100;
        tempPosition.z += speed;
        transform.position = tempPosition;
    }
}
