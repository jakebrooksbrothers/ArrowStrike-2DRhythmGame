using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioSource theMusic;
    public bool startPlaying;
    public BeatScroller theBS;

    public static GameManager instance;
    public int currentScore;
    public int scorePerNote = 100;
    public int scorePerGoodNote = 125;
    public int scorePerPerfectNote = 150;

    public int currentMulitplier;
    public int mulitplierTracker;
    public int[] mulitplierThresholds;

    public Text scoreText;
    public Text multiText;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        scoreText.text = "SCORE: 0";
        currentMulitplier = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(!startPlaying)
        {
            if(Input.anyKeyDown)
            {
                startPlaying = true;
                theBS.hasStarted = true;

                    theMusic.Play();
            }
        }
    }
    public void NoteHit()
    {
        if (currentMulitplier - 1 < mulitplierThresholds.Length)
        {
            mulitplierTracker++;

            if (mulitplierThresholds[currentMulitplier - 1] <= mulitplierTracker)
            {
                mulitplierTracker = 0; 
                currentMulitplier++;
            }
        }
        multiText.text = "MULTIPLIER: x" + currentMulitplier;
        currentScore += scorePerNote * currentMulitplier;
        scoreText.text = "SCORE: " + currentScore;
        Debug.Log("hit");

    }
    public void NoteMiss()
    {
        Debug.Log("miss");
        currentMulitplier = 1;
        mulitplierTracker = 0;
        multiText.text = "MULTIPLIER: x" + currentMulitplier;
        
    }
    public void NormalHit()
    {
        currentScore += scorePerNote * currentMulitplier;
        NoteHit();
    }
    public void GoodHit()
    {
        currentScore += scorePerGoodNote * currentMulitplier;
        NoteHit();
    }
    public void PerfectHit()
    {
        currentScore += scorePerPerfectNote * currentMulitplier;
        NoteHit();
    }
}

