using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Letter : MonoBehaviour
{
    // VARIABLES

    public PuzzleManager S_PuzzleManager;

    public TMP_Text ClickedText;

    


// START
    void Start()
    {
        S_PuzzleManager = GameObject.Find("PuzzleManager").GetComponent<PuzzleManager>();
    }

// FUNCTIONS

    public void LetterTriggerDown()
    {
        if (CompareTag("RandomLetter"))
        {
            Debug.Log("Letter wrong");

            GetComponent<Image>().color = Color.red;

        }
        else if (CompareTag("Word1_Game") || CompareTag("Word2_Thief") || CompareTag("Word3_Bye"))
        {

            CheckWord_One();
            CheckWord_Two();
            CheckWord_Three();

            //S_PuzzleManager.ResetWordsIfWrong();
        }


    }

    public void GetTextComponent()
    {
        ClickedText = GetComponentInChildren<TMP_Text>();

    }

    public void CheckWord_One()
    {

        if (CompareTag("Word1_Game"))
        {
            

            if (ClickedText.text == "G")
            {
                GetComponent<Image>().color = Color.green;
                S_PuzzleManager.A_Word1_Bool[0] = true;


            }
            else GetComponent<Image>().color = Color.red; /*S_PuzzleManager.ResetWordsIfWrong();*/

            if (ClickedText.text == "A" && S_PuzzleManager.A_Word1_Bool[0])
            {
                GetComponent<Image>().color = Color.green;
                S_PuzzleManager.A_Word1_Bool[1] = true;
 

            }

            if (ClickedText.text == "M" && S_PuzzleManager.A_Word1_Bool[1] == true)
            {
                GetComponent<Image>().color = Color.green;
                S_PuzzleManager.A_Word1_Bool[2] = true;


            }

            if (ClickedText.text == "E" && S_PuzzleManager.A_Word1_Bool[2] == true)
            {
                GetComponent<Image>().color = Color.green;

                S_PuzzleManager.A_WordCorrect_Bool[0] = true;
                S_PuzzleManager.WordsFoundCounter++;
                S_PuzzleManager.WordCorrect();

                Debug.Log(S_PuzzleManager.WordsFoundCounter);
            }

        }

    }

    public void CheckWord_Two()
    {
        if (CompareTag("Word2_Thief"))
        {

            if (ClickedText.text == "T" )
            {
                GetComponent<Image>().color = Color.green;
                S_PuzzleManager.A_Word2_Bool[0] = true;

            }else GetComponent<Image>().color = Color.red;

            if (ClickedText.text == "H" && S_PuzzleManager.A_Word2_Bool[0] == true)
            {
                GetComponent<Image>().color = Color.green;
                S_PuzzleManager.A_Word2_Bool[1] = true;

            }

            if (ClickedText.text == "I" && S_PuzzleManager.A_Word2_Bool[1] == true)
            {
                GetComponent<Image>().color = Color.green;
                S_PuzzleManager.A_Word2_Bool[2] = true;

            }

            if (ClickedText.text == "E" && S_PuzzleManager.A_Word2_Bool[2] == true)
            {
                GetComponent<Image>().color = Color.green;
                S_PuzzleManager.A_Word2_Bool[3] = true;

            }

            if (ClickedText.text == "F" && S_PuzzleManager.A_Word2_Bool[3] == true)
            {
                GetComponent<Image>().color = Color.green;

                S_PuzzleManager.A_WordCorrect_Bool[1] = true;
                S_PuzzleManager.WordsFoundCounter++;
                S_PuzzleManager.WordCorrect();

                Debug.Log(S_PuzzleManager.WordsFoundCounter);
            }

        }
        

    }

    public void CheckWord_Three()
    {
        if (CompareTag("Word3_Bye"))
        {

            if (ClickedText.text == "B")
            {
                GetComponent<Image>().color = Color.green;
                S_PuzzleManager.A_Word3_Bool[0] = true;

            }
            else GetComponent<Image>().color = Color.red;

            if (ClickedText.text == "Y" && S_PuzzleManager.A_Word3_Bool[0] == true)
            {
                GetComponent<Image>().color = Color.green;
                S_PuzzleManager.A_Word3_Bool[1] = true;

            }

            if (ClickedText.text == "E" && S_PuzzleManager.A_Word3_Bool[1] == true)
            {
                GetComponent<Image>().color = Color.green;

                S_PuzzleManager.A_WordCorrect_Bool[2] = true;
                S_PuzzleManager.WordsFoundCounter++;
                S_PuzzleManager.WordCorrect();

                Debug.Log(S_PuzzleManager.WordsFoundCounter);
            }

            

        }

    }

    public void MakeLetterRed()
    {
        GetComponent<Image>().color = Color.red;
    }
}
