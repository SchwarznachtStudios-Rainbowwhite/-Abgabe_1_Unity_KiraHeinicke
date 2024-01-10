using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter : MonoBehaviour
{
    // VARIABLES

    public PuzzleManager S_PuzzleManager;



// START
    void Start()
    {
        S_PuzzleManager = GameObject.Find("PuzzleManager").GetComponent<PuzzleManager>();
    }

// FUNCTIONS

    public void EventTriggerDown()
    {
        if (CompareTag("RandomLetter"))
        {
            Debug.Log("Letter wrong");

            // color button red

        }
        else if (CompareTag("Word1_Test") || CompareTag("Word2_Hallo") || CompareTag("Word3_Bye"))
        {
            S_PuzzleManager.CheckWords();


            // color button green
        }


    }



}
