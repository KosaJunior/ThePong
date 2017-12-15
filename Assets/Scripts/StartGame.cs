using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

    public string sceneToLoad;
    public float timeToFadeOut;

    public void loadScene()
    {
        GetComponent<FadeOut>().enabled = true;
        StartCoroutine(WaitToFadeOut());
    }

    IEnumerator WaitToFadeOut()
    {
        yield return new WaitForSeconds(timeToFadeOut);
        SceneManager.LoadScene(sceneToLoad);
    }
}
