using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using TMPro;
using System;

public class TimeCounter : MonoBehaviour
{
    // VARIABLES

    // Scripts
    public PuzzleManager S_PuzzleManager;

    // Other
    public Stopwatch Stopwatch = new Stopwatch();

    
    public TMP_Text Txt_TimeCounter;

    public TimeSpan TimePassed;
    

// START
    void Start()
    {
        FindingCalls();

        TimeCounterStart();
    }

// UPDATE
    void Update()
    {
        TimeCounterRunning();



    }

// FUNCTIONS

    public void TimeCounterStart()
    {
        Stopwatch.Start();
        
    }

    public void TimeCounterRunning()
    {
        TimePassed = Stopwatch.Elapsed;
        Txt_TimeCounter.text = TimePassed.ToString();

    }

    public void TimeCounterStop()
    {
        Stopwatch.Stop();

        S_PuzzleManager.TimeFinal.text = TimePassed.ToString();


    }



// FINDING CALLS
    public void FindingCalls()
    {
        Txt_TimeCounter = GameObject.Find("TimeCounter").GetComponent<TMP_Text>();

    }



}
