using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PuzzleManager : MonoBehaviour
{
// VARIABELS

    // Scripts
    public Letter S_Letter;
    [Space]

    // int
    [HideInInspector] public int WordsFoundCounter;
    private int WordsTotal = 3;

    // AudioSources
    [Space]
    public AudioSource FailSound;
    public AudioSource CorrectSound;
    public AudioSource FinishGameSound;

    [Space]
    // Solution Words
    public GameObject[] A_Word1_Game = new GameObject[4];
    public GameObject[] A_Word2_Thief = new GameObject[5];
    public GameObject[] A_Word3_Bye = new GameObject[3];

    // Random Letters
    [HideInInspector] public TMP_Text[] RandomizableLetters;
    [HideInInspector] public string[] Alphabet = new string[26] { "A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z" };

    // CheckWord Bools
    [HideInInspector] public bool[] A_Word1_Bool = new bool[3];
    [HideInInspector] public bool[] A_Word2_Bool = new bool[4];
    [HideInInspector] public bool[] A_Word3_Bool = new bool[2];

    [HideInInspector] public bool[] A_WordCorrect_Bool = new bool[3];

    // Objects
    private GameObject _EndScreen;

// START
    void Start()
    {
        RandomizeLetters();
        FindObjects();
    }

// UPDATE
    void Update()
    {

    }

// FUNCTIONS

    // Randomizes all Letters that do not belong to the searched words
    public void RandomizeLetters()
    {
        for (int i = 0; i < RandomizableLetters.Length; i++)
        {
            RandomizableLetters[i].text = Alphabet[Random.Range(0, Alphabet.Length)].ToString();

        }

    }

    public void WordCorrect()
    {
        // Play Correct Sound
        CorrectSound.Play();

        // WordsFoundCounter + 1 / Total Words 
        WordsFoundCounter++;
    }

    public void GameFinish()
    {
        // If WordsFoundCounter = Words Total
        if (WordsFoundCounter == WordsTotal)
        {
            // Show EndScreen
            _EndScreen.SetActive(true);

            // Play EndGameSound
            FinishGameSound.Play();
        }      

        // Display Time Needed

    }

    public void Restart()
    {
        // Reload Scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }


    // Complete Reset of Word
    // reset works, but not implemented yet
    public void ResetIfWrongLetterClicked()
    {
        if (CompareTag("Word1_Game"))
        {
            for (int i = 1; i < A_Word1_Game.Length; i++)
            {
                A_Word1_Game[i].GetComponent<Image>().color = Color.white;
            }

            for (int i = 0; i < A_Word1_Bool.Length; i++)
            {
                A_Word1_Bool[i] = false;
            }
        }

        if (CompareTag("Word2_Thief"))
        {
            for (int i = 1; i < A_Word2_Thief.Length; i++)
            {
                A_Word2_Thief[i].GetComponent<Image>().color = Color.white;
            }

            for (int i = 0; i < A_Word2_Bool.Length; i++)
            {
                A_Word2_Bool[i] = false;
            }
        }

        if (CompareTag("Word3_Bye"))
        {
            for (int i = 1; i < A_Word3_Bye.Length; i++)
            {
                A_Word3_Bye[i].GetComponent<Image>().color = Color.white;
            }

            for (int i = 0; i < A_Word3_Bool.Length; i++)
            {
                A_Word3_Bool[i] = false;
            }
        }

        // Play Fail Sound
    }
    public void ResetWordsIfWrong()
    {
        // WORD 1
        // if all W1 bools false 
        if (!A_Word1_Bool[0] && !A_Word1_Bool[1] && !A_Word1_Bool[2])
        {
            S_Letter.MakeLetterRed();


            //Reset Color of all Letters
            for (int i = 0; i < A_Word1_Game.Length; i++)
            {
                Debug.Log("Letter color reset");

                // needs a timer or the letters stay white
                // A_Word1_Game[i].GetComponent<Image>().color = Color.white;
            }
        }
        /*else if()
        {
            
        }*/

        // Word 2
        if (!A_Word2_Bool[0] && !A_Word2_Bool[1] && !A_Word2_Bool[2] && !A_Word2_Bool[3])
        {

            S_Letter.MakeLetterRed();

            for (int i = 0; i < A_Word2_Bool.Length; i++)
            {
                A_Word2_Bool[i] = false;
            }
            for (int i = 0; i < A_Word2_Thief.Length; i++)
            {
                A_Word2_Thief[i].GetComponent<Image>().color = Color.white;
            }
        }
        else
        {
            for (int i = 0; i < A_Word2_Bool.Length; i++)
            {
                A_Word2_Bool[i] = false;
            }
            for (int i = 0; i < A_Word2_Thief.Length; i++)
            {
                A_Word2_Thief[i].GetComponent<Image>().color = Color.white;
            }
        }

        // Word 3
        if (!A_Word3_Bool[0] && !A_Word3_Bool[1])
        {
            S_Letter.MakeLetterRed();


            for (int i = 0; i < A_Word3_Bool.Length; i++)
            {
                A_Word3_Bool[i] = false;
            }
            for (int i = 0; i < A_Word3_Bye.Length; i++)
            {
                A_Word3_Bye[i].GetComponent<Image>().color = Color.white;
            }
        }
        else
        {
            for (int i = 0; i < A_Word3_Bool.Length; i++)
            {
                A_Word3_Bool[i] = false;
            }
            for (int i = 0; i < A_Word3_Bye.Length; i++)
            {
                A_Word3_Bye[i].GetComponent<Image>().color = Color.white;
            }
        }

    }


// FINDING CALLS

    // Nicht benutzt, da es die Objekte in falscher Reihenfolge dem Array zuweist und damit in anderen Funktionen Probleme macht
    public void FindWordButtons()
    {

        A_Word1_Game = GameObject.FindGameObjectsWithTag("Word1_Game");
        A_Word2_Thief = GameObject.FindGameObjectsWithTag("Word2_Thief");
        A_Word3_Bye = GameObject.FindGameObjectsWithTag("Word3_Bye");

    }
    
    // EndScreen
    public void FindObjects()
    {
        _EndScreen = GameObject.Find("EndScreen");
        _EndScreen.SetActive(false);

    }

}
