using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public float speed = 5f;
    Vector3 startPos;
    
    // Use this for initialization
	void Start () {
        startPos = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        transform.Translate(0f, Input.GetAxis("Vertical") * speed * Time.deltaTime, 0f);
	}

    public void Restart()
    {
        gameObject.transform.position = startPos;
    }
}
