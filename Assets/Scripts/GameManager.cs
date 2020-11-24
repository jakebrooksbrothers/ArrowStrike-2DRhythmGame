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

    public float totalNotes;
    public float normalHits;
    public float goodHits;
    public float perfectHits;
    public float missedHits;

    public GameObject resultsScreen;
    public Text normalsText, goodsText, perfectsText, missesText, finalScoreText;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        scoreText.text = "SCORE: 0";
        currentMulitplier = 1;

        totalNotes = FindObjectsOfType<NoteObject>().Length;
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
        else
        {
            if(!theMusic.isPlaying && !resultsScreen.activeInHierarchy)
            {
                resultsScreen.SetActive(true);
                normalsText.text = "" + normalHits;
                goodsText.text = "" + goodHits;
               perfectsText.text = "" + perfectHits;
                missesText.text = "" + missedHits;
                finalScoreText.text = "" + currentScore;
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
        missedHits++;
        
    }
    public void NormalHit()
    {
        currentScore += scorePerNote * currentMulitplier;
        NoteHit();
        normalHits++;
    }
    public void GoodHit()
    {
        currentScore += scorePerGoodNote * currentMulitplier;
        NoteHit();
        goodHits++;
    }
    public void PerfectHit()
    {
        currentScore += scorePerPerfectNote * currentMulitplier;
        NoteHit();
        perfectHits++;
    }
}

