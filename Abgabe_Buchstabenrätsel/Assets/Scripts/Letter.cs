using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Letter : MonoBehaviour
{
    // VARIABLES

    public PuzzleManager S_PuzzleManager;

    public TMP_Text TestText;

    


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
        else if (CompareTag("Word1_Game") || CompareTag("Word2_Thief") || CompareTag("Word3_Bye"))
        {
            //S_PuzzleManager.CheckWords();

            CheckWord_One();

        }


    }

    public void GetTextComponent()
    {
        TestText = GetComponentInChildren<TMP_Text>();

    }

    public void CheckWord_One()
    {

        if (CompareTag("Word1_Game"))
        {

            if (TestText.text == "G")
            {
                GetComponent<Image>().color = Color.green;
                S_PuzzleManager.A_Word1_Bool[0] = true;
                

            }
            if (TestText.text == "A" && S_PuzzleManager.A_Word1_Bool[0])
            {
                    GetComponent<Image>().color = Color.green;
                    S_PuzzleManager.A_Word1_Bool[1] = true;
 

            }
            if (TestText.text == "M" && S_PuzzleManager.A_Word1_Bool[1] == true)
            {
                GetComponent<Image>().color = Color.green;
                S_PuzzleManager.A_Word1_Bool[2] = true;


            }
            if (TestText.text == "E" && S_PuzzleManager.A_Word1_Bool[2] == true)
            {
                GetComponent<Image>().color = Color.green;


            }


        }else GetComponent<Image>().color = Color.red;

    }

    public void CheckWord_Two()
    {
        if (CompareTag("Word2_Thief"))
        {

            if (TestText.text == "T")
            {
                GetComponent<Image>().color = Color.green;


            }
            if (TestText.text == "H")
            {
                GetComponent<Image>().color = Color.green;


            }
            if (TestText.text == "I")
            {
                GetComponent<Image>().color = Color.green;


            }
            if (TestText.text == "E")
            {
                GetComponent<Image>().color = Color.green;


            }
            if (TestText.text == "F")
            {
                GetComponent<Image>().color = Color.green;


            }

        }
        else GetComponent<Image>().color = Color.red;

    }

    public void CheckWord_Three()
    {
        if (CompareTag("Word3_Bye"))
        {

            if (TestText.text == "B")
            {
                GetComponent<Image>().color = Color.green;


            }
            if (TestText.text == "Y")
            {
                GetComponent<Image>().color = Color.green;


            }
            if (TestText.text == "E")
            {
                GetComponent<Image>().color = Color.green;


            }

        }
        else GetComponent<Image>().color = Color.red;

    }
}
