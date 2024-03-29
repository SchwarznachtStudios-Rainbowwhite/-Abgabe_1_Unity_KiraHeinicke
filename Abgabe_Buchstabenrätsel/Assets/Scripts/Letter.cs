using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Letter : MonoBehaviour
{
// VARIABLES

    // Scripts
    [HideInInspector] public PuzzleManager S_PuzzleManager;

    // Text on Clicked Button
    public TMP_Text Txt_ClickedText;

    


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
            // Letters that do not belong to word are turned red
            GetComponent<Image>().color = Color.red;
            // Reset color back to white
            StartCoroutine(ColorResetRandom());

            S_PuzzleManager.Audio_FailSound.Play();
            // Reset when random letter clicked

            S_PuzzleManager.ResetIfWrongLetterClicked();


        }
        else if (CompareTag("Word1_Game") || CompareTag("Word2_Thief") || CompareTag("Word3_Bye"))
        {
            // Executes Word Checks
            CheckWord_One();
            CheckWord_Two();
            CheckWord_Three();

        }


    }

    // Gets Text Component on Clicked Button
    public void GetTextComponent()
    {
        Txt_ClickedText = GetComponentInChildren<TMP_Text>();

    }


    // WordChecks
    // Checks if Button belongs to Word
    //   Checks which Letter in Clicked Button/Text
    //     Checks if Letter before the clicked one was clicked, if not resets all buttons/letters of word
    public void CheckWord_One()
    {

        if (CompareTag("Word1_Game"))
        {

            if (Txt_ClickedText.text == "G")
            {
                GetComponent<Image>().color = Color.green;
                S_PuzzleManager.A_Word1_Bool[0] = true;
                Debug.Log("green");

            }

            if (Txt_ClickedText.text == "A")
            {
                if (S_PuzzleManager.A_Word1_Bool[0])
                {
                    GetComponent<Image>().color = Color.green;
                    S_PuzzleManager.A_Word1_Bool[1] = true;
                }
                else
                {
                    GetComponent<Image>().color = Color.red;
                    Debug.Log("red");
                    S_PuzzleManager.ResetIfWrongLetterClicked();
                }
            }

            if (Txt_ClickedText.text == "M")
            {
                if (S_PuzzleManager.A_Word1_Bool[1])
                {
                    GetComponent<Image>().color = Color.green;
                    S_PuzzleManager.A_Word1_Bool[2] = true;
                }
                else
                {
                    GetComponent<Image>().color = Color.red;
                    Debug.Log("red");
                    S_PuzzleManager.ResetIfWrongLetterClicked();
                }
            }

            if (Txt_ClickedText.text == "E")
            {
                if (S_PuzzleManager.A_Word1_Bool[2])
                {
                    GetComponent<Image>().color = Color.green;

                    S_PuzzleManager.A_WordCorrect_Bool[0] = true;
                    S_PuzzleManager.WordCorrect();
                    S_PuzzleManager.GameFinish();

                    Debug.Log(S_PuzzleManager._WordsFoundCounter);
                }
                else
                {
                    GetComponent<Image>().color = Color.red;
                    Debug.Log("red");
                    S_PuzzleManager.ResetIfWrongLetterClicked();
                }

            }

        }

    }

    public void CheckWord_Two()
    {
        if (CompareTag("Word2_Thief"))
        {

            if (Txt_ClickedText.text == "T" )
            {
                GetComponent<Image>().color = Color.green;
                S_PuzzleManager.A_Word2_Bool[0] = true;

            }

            if (Txt_ClickedText.text == "H")
            {
                if (S_PuzzleManager.A_Word2_Bool[0])
                {
                    GetComponent<Image>().color = Color.green;
                    S_PuzzleManager.A_Word2_Bool[1] = true;
                }
                else
                {
                    GetComponent<Image>().color = Color.red;
                    Debug.Log("red");
                    S_PuzzleManager.ResetIfWrongLetterClicked();
                }
            }

            if (Txt_ClickedText.text == "I")
            {
                if (S_PuzzleManager.A_Word2_Bool[1])
                {
                    GetComponent<Image>().color = Color.green;
                    S_PuzzleManager.A_Word2_Bool[2] = true;
                }
                else
                {
                    GetComponent<Image>().color = Color.red;
                    Debug.Log("red");
                    S_PuzzleManager.ResetIfWrongLetterClicked();
                }
            }

            if (Txt_ClickedText.text == "E")
            {
                if (S_PuzzleManager.A_Word2_Bool[2])
                {
                    GetComponent<Image>().color = Color.green;
                    S_PuzzleManager.A_Word2_Bool[3] = true;
                }
                else
                {
                    GetComponent<Image>().color = Color.red;
                    Debug.Log("red");
                    S_PuzzleManager.ResetIfWrongLetterClicked();
                }
            }

            if (Txt_ClickedText.text == "F")
            {
                if (S_PuzzleManager.A_Word2_Bool[3])
                {
                    GetComponent<Image>().color = Color.green;

                    S_PuzzleManager.A_WordCorrect_Bool[1] = true;
                    S_PuzzleManager.WordCorrect();
                    S_PuzzleManager.GameFinish();

                    Debug.Log(S_PuzzleManager._WordsFoundCounter);
                }
                else
                {
                    GetComponent<Image>().color = Color.red;
                    Debug.Log("red");
                    S_PuzzleManager.ResetIfWrongLetterClicked();
                }
            }

        }
        

    }

    public void CheckWord_Three()
    {
        if (CompareTag("Word3_Bye"))
        {

            if (Txt_ClickedText.text == "B")
            {
                GetComponent<Image>().color = Color.green;
                S_PuzzleManager.A_Word3_Bool[0] = true;

            }

            if (Txt_ClickedText.text == "Y")
            {
                if (S_PuzzleManager.A_Word3_Bool[0])
                {
                    GetComponent<Image>().color = Color.green;
                    S_PuzzleManager.A_Word3_Bool[1] = true;
                }
                else
                {
                    GetComponent<Image>().color = Color.red;
                    Debug.Log("red");
                    S_PuzzleManager.ResetIfWrongLetterClicked();
                }
            }

            if (Txt_ClickedText.text == "E")
            {
                if (S_PuzzleManager.A_Word3_Bool[1])
                {
                    GetComponent<Image>().color = Color.green;

                    S_PuzzleManager.A_WordCorrect_Bool[2] = true;
                    S_PuzzleManager.WordCorrect();
                    S_PuzzleManager.GameFinish();

                    Debug.Log(S_PuzzleManager._WordsFoundCounter);
                }
                else
                {
                    GetComponent<Image>().color = Color.red;
                    Debug.Log("red");
                    S_PuzzleManager.ResetIfWrongLetterClicked();
                }

            }

            

        }

    }


    // Random Letter Color Reset
    IEnumerator ColorResetRandom()
    {
        yield return new WaitForSeconds(1);

        GetComponent<Image>().color = Color.white;

    }


    // Color Letter red Function
    // function here so it can be called in PuzzleManager
    public void MakeLetterRed()
    {
        GetComponent<Image>().color = Color.red;
    }
}
