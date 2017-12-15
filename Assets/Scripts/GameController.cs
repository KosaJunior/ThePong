using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject[] uiElements = new GameObject[4];
    /*
        uiElements[0] - Hints,
        uiElements[1] - Countdown
        uiElements[2] - Score, 
        uiElements[3] - Restart board
    */

    public GameObject[] rgdObjects = new GameObject[4];
    public GameObject[] restartObj = new GameObject[3];
    public GameObject camera2D,
                      camera3D;
    public GameObject failSprite;

    bool anim_played = false,
         started = false;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space") && !started)
        {
            uiElements[0].SetActive(false);
            uiElements[1].SetActive(true);
            uiElements[2].SetActive(true);
            started = true;
        }

        // If player lose a life
        if (restartObj[1].GetComponent<Ball>().fail && uiElements[2].GetComponent<Score>().lifes != 0)
        {
            uiElements[1].SetActive(true);
            restartObj[1].SetActive(false);
            Restart();
        }

        // If playe lose a whole game
        if (uiElements[2].GetComponent<Score>().lifes == 0)
        {
            LoseGame();
            RestartBoard();
        }

        // Key to testing restart
        if (Input.GetKeyDown("r"))
        {
            Restart();
        }

        // Change 2D/3D view
        if (!failSprite.activeSelf)
        {
            if (Input.GetKeyDown("v"))
            {
                if (camera2D.activeSelf)
                {
                    camera2D.SetActive(false);
                    camera3D.SetActive(true);
                    uiElements[2].GetComponent<Score>().heartColor = "white";
                }
                else
                {
                    camera2D.SetActive(true);
                    camera3D.SetActive(false);
                    uiElements[2].GetComponent<Score>().heartColor = "black";
                }
            }
        }
    }

    public void LoseGame()
    {
        failSprite.SetActive(true);

            foreach (GameObject go in rgdObjects)
            {
                go.GetComponent<Rigidbody>().isKinematic = false;
            }
            rgdObjects[2].GetComponent<Rigidbody>().useGravity = true;
            rgdObjects[0].GetComponent<Rigidbody>().useGravity = true;

        if (!anim_played)
        {
            // Play animation
            if (camera2D.activeSelf)
                uiElements[2].GetComponent<Animator>().Play("score_end");

            else if (camera3D.activeSelf)
            {
                failSprite.GetComponent<Animation>().enabled = true;
                uiElements[2].GetComponent<Animator>().Play("score_end3D");
            }

            RestartBoard();
            anim_played = true;
        }
    }

    private void RestartBoard()
    {
            uiElements[3].SetActive(true);

            if (Input.GetKeyDown("escape"))
                SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        // Paddle
        restartObj[0].GetComponent<Paddle>().Restart();

        // Ball
        restartObj[1].GetComponent<Ball>().Restart();

        // Score
        restartObj[2].GetComponent<Score>().Restart();

        // Exit board off
        uiElements[3].SetActive(false);
    }
}
