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
    public TimeCounter S_TimeCounter;
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
    public bool[] A_Word1_Bool = new bool[3];
    [HideInInspector] public bool[] A_Word2_Bool = new bool[4];
    [HideInInspector] public bool[] A_Word3_Bool = new bool[2];

    [HideInInspector] public bool[] A_WordCorrect_Bool = new bool[3];

    // Objects
    private GameObject _EndScreen;
    private TMP_Text Txt_WordCounter;
    [HideInInspector] public TMP_Text TimeFinal;

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
        // Write Counter in UI
        Txt_WordCounter.text = WordsFoundCounter.ToString();
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

            S_TimeCounter.TimeCounterStop();



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
        // Fail Word1
        if (!A_WordCorrect_Bool[0])
        {
            //Debug.Log("Reset");

            // Play Fail Sound
            FailSound.Play();

            // Reset Colors to White
            Invoke("ColorReset_Word1", 1);
            //ColorReset_Word1();

            // Reset bools that said letter correct
            for (int i = 0; i < A_Word1_Bool.Length; i++)
            {
                A_Word1_Bool[i] = false;
            }
        }

        // Fail Word2
        if (!A_WordCorrect_Bool[1])
        {
            // Play Fail Sound
            FailSound.Play();

            // Reset Colors to White
            Invoke("ColorReset_Word2", 1);
            //ColorReset_Word2();

            // Reset bools that said letter correct
            for (int i = 0; i < A_Word2_Bool.Length; i++)
            {
                A_Word2_Bool[i] = false;
            }
        }

        // Fail Word3
        if (!A_WordCorrect_Bool[2])
        {
            // Play Fail Sound
            FailSound.Play();

            // Reset Colors to White
            Invoke("ColorReset_Word3", 1);
            //ColorReset_Word3();

            // Reset bools that said letter correct
            for (int i = 0; i < A_Word3_Bool.Length; i++)
            {
                A_Word3_Bool[i] = false;
            }
        }

    }

    public void ColorReset_Word1()
    {
        for (int i = 0; i < A_Word1_Game.Length; i++)
        {
            A_Word1_Game[i].GetComponent<Image>().color = Color.white;
        }
    }

    public void ColorReset_Word2()
    {
        for (int i = 0; i < A_Word2_Thief.Length; i++)
        {
            A_Word2_Thief[i].GetComponent<Image>().color = Color.white;
        }
    }

    public void ColorReset_Word3()
    {
        for (int i = 0; i < A_Word3_Bye.Length; i++)
        {
            A_Word3_Bye[i].GetComponent<Image>().color = Color.white;
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
        TimeFinal = GameObject.Find("TimeFinal").GetComponent<TMP_Text>();
        _EndScreen.SetActive(false);

        Txt_WordCounter = GameObject.Find("WordCounter").GetComponent<TMP_Text>();
        

    }

}
