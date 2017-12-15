using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public float speed = 5f, startSpeed;
    float sx, sy;
    public bool fail;
    int countBalls;
    GameObject score;

    // Sound effect by DeathsbreedGames organization
    public AudioClip hitSound;

    Vector3 originalPos;

	// Use this for initialization
	void Start () {
        countBalls = 3;

        fail = false;

        score = GameObject.FindGameObjectWithTag("Score");

        startSpeed = speed;

        originalPos = transform.position;

        RandomPosition(true);
    }
	
	// Update is called once per frame
	void Update ()
    {
	}

    void OnCollisionEnter(Collision col)
    {
        if (!fail)
        {
            GetComponent<AudioSource>().PlayOneShot(hitSound);
            if (col.gameObject.name == "Paddle")
                // Add point
                score.GetComponent<Score>().score++;

            // Get acceleration after reflection
            speed += startSpeed * 0.01f;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        score.GetComponent<Score>().lifes--;
        fail = true;
        countBalls--;
    }

    public void Restart()
    { 
        transform.position = originalPos;
        speed = 5;
        fail = false;

        if (countBalls != 0)
            RandomPosition(true);
        else
            RandomPosition(false);
    }

    void RandomPosition(bool cont)
    {
        if (cont)
        {
            sx = Random.Range(0, 2) == 0 ? -1 : 1;
            sy = Random.Range(0, 2) == 0 ? -1 : 1;

            GetComponent<Rigidbody>().velocity = new Vector3(speed * sx, speed * sy, 0f);
        }
        else
            GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
    }
}
