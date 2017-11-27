using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleStage : MonoBehaviour {
    public GameObject[] StageTwoObstacles;
    public int stageCounter = 0;
	// Use this for initialization
	void Start () {
		StageTwoObstacles = GameObject.FindGameObjectsWithTag("StageTwoObjects");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "AircraftJet")
        {
            stageCounter++;
            if (stageCounter == 1)
            {
                foreach (GameObject go in StageTwoObstacles)
                {
                    go.SetActive(true);
                }
            }
        }
    }
}
