using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movingBird : MonoBehaviour
{

    public float horizontalSpeed;
    public float verticalSpeed;
    public float amplitude;
    public float speed;
    public GameObject cursor;
    public GameObject[] StageTwoObstacles;
    public int stageCounter = 0;

    public Vector3 tempPosition;
    public Vector3 startPosition;

    public Text countText;
    public Text winText;
    public Text stageText;

    private int count = 0;
    public int stage1points;

    // Use this for initialization
    void Start()
    {
        startPosition = transform.position;
        tempPosition = transform.position;
        winText.text = "";
        countText.text = "";
        stageText.text = "Stage 1";

        StageTwoObstacles = GameObject.FindGameObjectsWithTag("StageTwoObjects");
        foreach (GameObject go in StageTwoObstacles)
        {
            go.SetActive(false);
        }

        Time.timeScale = 0;
    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
        if(cursor.transform.position.x *500 <= 145)
        {
            tempPosition.x = 145;
        }
        else if (cursor.transform.position.x *500 >= 355)
        {
            tempPosition.x = 355;
        }
        else
        {
            tempPosition.x = cursor.transform.position.x *500;
        }
        tempPosition.y = cursor.transform.position.y *100;
        tempPosition.z += speed;

        transform.position = tempPosition;

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            count = count + 1;
            SetCountText();
        }
        else if (other.gameObject.CompareTag("Finish Line"))
        {
            Immobilize();
            resetPosition();
            Countdown5(System.DateTime.UtcNow);

            string next = nextStage();

            if (next == "stage2")
            {
                stageText.text = "Stage 2";
                Mobilize();
                Countdown2(System.DateTime.UtcNow);
                
            }
            else if(next == "end")
            {
                stageText.text = "Finish";
                winText.text = "Your Score Was "+count.ToString();
            }
        }
        else if (other.gameObject.CompareTag("StageTwoObjects"))
        {
            Immobilize();
            resetPosition();
            winText.text = "Try Again";
            Countdown5(System.DateTime.UtcNow);
            countText.text = stage1points.ToString() ;
            count = stage1points;
            Mobilize();
            winText.text = "";
        }
    }
    /*void onCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Terrain"))
        {
            Immobilize();
            resetPosition();
            winText.text = "You Lose";
        }
    }*/

    private string nextStage()
    {
        stageCounter++;
        if (stageCounter == 1)
        {
            stage1points = count;
            foreach (GameObject go in StageTwoObstacles)
            {
                go.SetActive(true);
            }
            return "stage2";
        }
        else if(stageCounter == 2)
        {
            return "end";
        }
        else
        {
            return "stage1";
        }
        
    }

    void resetPosition()
    {
        tempPosition.z = 0;
    }

    void Immobilize()
    {
        speed = 0;
    }

    void Mobilize()
    {
        speed = 3;
    }

    void SetCountText()
    {
        countText.text = "Points: " + count.ToString();
    }

    private void Countdown5(System.DateTime start)
    {
        double diff = 0.0;
        while (diff < 5)
        {
            diff = (System.DateTime.UtcNow - start).TotalSeconds;
        }
    }

    private void Countdown2(System.DateTime start)
    {
        double diff = 0.0;
        while (diff < 2)
        {
            diff = (System.DateTime.UtcNow - start).TotalSeconds;
        }
    }
}
