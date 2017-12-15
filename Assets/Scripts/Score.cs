using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public GameObject bS;
    public Texture blackHeart,
                   whiteHeart;
    public string heartColor;

    public int score,
               bestScore = 0,
               lifes;
        
    // Use this for initialization
	void Start ()
    {
        heartColor = "black";
        score = 0;
        lifes = 3;
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Cheats
        if (Input.GetKeyDown("="))
            lifes++;
        if (Input.GetKeyDown("-"))
            lifes--;

        GetComponent<Text>().text = score.ToString();

        if (score > bestScore)
            bestScore = score;

        bS.GetComponent<Text>().text = bestScore.ToString();
    }

    void OnGUI()
    {
        int x = 0;

        // Lifes counter
        for (int i = 0; i < lifes; i++)
        {
            if (heartColor == "black")
            {
                GUI.DrawTexture(new Rect(x, 0, 40, 40), blackHeart, ScaleMode.ScaleToFit);
                x += 40;
            }
            else if (heartColor == "white")
            {
                GUI.DrawTexture(new Rect(x, 0, 40, 40), whiteHeart, ScaleMode.ScaleToFit);
                x += 40;
            }
        }
    }

    public void Restart()
    {
        score = 0; 
    }
}
