using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRound : MonoBehaviour {

    public GameObject ball, paddle;

    //startgame changes to "true" when countdown animation ends
    public bool startgame = false;

	// Use this for initialization
	void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (startgame)
        {
            ball.SetActive(true);
            paddle.GetComponent<Paddle>().enabled = true;
            gameObject.SetActive(false);
        }            
	}
}
