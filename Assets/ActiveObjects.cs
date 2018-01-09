using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveObjects : MonoBehaviour {
    public GameObject[] Obstacles;
    // Use this for initialization
    void Start () {
        Obstacles = GameObject.FindGameObjectsWithTag("StageTwoObjects");
        foreach (GameObject go in Obstacles)
        {
            go.SetActive(true);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
