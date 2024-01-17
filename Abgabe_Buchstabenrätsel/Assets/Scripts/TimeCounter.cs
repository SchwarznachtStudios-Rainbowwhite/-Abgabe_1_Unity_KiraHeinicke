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
    public Stopwatch _Stopwatch = new Stopwatch();

    
    public TMP_Text Txt_TimeCounter;

    public TimeSpan _TimePassed;
    

// START
    void Start()
    {
        // Finding Calls
        FindingCalls();
        S_PuzzleManager = GameObject.Find("PuzzleManager").GetComponent<PuzzleManager>();

        // Starts _Stopwatch
        TimeCounterStart();
    }

// UPDATE
    void Update()
    {
        // Display Time in UI
        TimeCounterRunning();

    }

// FUNCTIONS

    // Starts _Stopwatch
    public void TimeCounterStart()
    {
        _Stopwatch.Start();
        
    }

    // Display Time in UI
    public void TimeCounterRunning()
    {
        _TimePassed = _Stopwatch.Elapsed;
        Txt_TimeCounter.text = _TimePassed.ToString();

    }

    // Stops _Stopwatch and Displays Time in Endscreen UI when called
    public void TimeCounterStop()
    {
        _Stopwatch.Stop();

        S_PuzzleManager.Txt_TimeFinal.text = _TimePassed.ToString();

    }



// FINDING CALLS
    public void FindingCalls()
    {
        Txt_TimeCounter = GameObject.Find("TimeCounter").GetComponent<TMP_Text>();

    }



}
