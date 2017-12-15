using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMenuObjects : MonoBehaviour {

    public GameObject[] gameObjects = new GameObject[2];

    // Use this for initialization
    void Start () {
        foreach(GameObject go in gameObjects)
        {
            Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), go.transform.position.y, transform.position.z));
            Instantiate(go, screenPosition, go.transform.rotation);
        }
    }
}
