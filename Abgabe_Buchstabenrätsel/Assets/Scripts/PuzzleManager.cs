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
    [HideInInspector] public TimeCounter S_TimeCounter;

    // WordCounter int
    [HideInInspector] public int _WordsFoundCounter;
    private int _wordsTotal = 3;

    // AudioSources
    public AudioSource Audio_FailSound;
    public AudioSource Audio_CorrectSound;
    public AudioSource Audio_FinishGameSound;
    [Space]

    // Solution Words
    public GameObject[] A_Word1_Game = new GameObject[4];
    public GameObject[] A_Word2_Thief = new GameObject[5];
    public GameObject[] A_Word3_Bye = new GameObject[3];

    // Random Letters
    public TMP_Text[] A_RandomizableLetters;
    [HideInInspector] public string[] A_Alphabet = new string[26] { "A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z" };

    // CheckWord Bools
    [HideInInspector] public bool[] A_Word1_Bool = new bool[3];
    [HideInInspector] public bool[] A_Word2_Bool = new bool[4];
    [HideInInspector] public bool[] A_Word3_Bool = new bool[2];

    [HideInInspector] public bool[] A_WordCorrect_Bool = new bool[3];

    // UI Objects
    private GameObject _EndScreen;
    private TMP_Text Txt_WordCounter;
    public TMP_Text Txt_TimeFinal;

    // START
    void Start()
    {
        // Finding Calls
        FindObjects();

        S_TimeCounter = GameObject.Find("PuzzleManager").GetComponent<TimeCounter>();


        // Functions at Start
        RandomizeLetters();
        
    }

// FUNCTIONS

    // Randomizes all Letters that do not belong to the searched words
    public void RandomizeLetters()
    {
        for (int i = 0; i < A_RandomizableLetters.Length; i++)
        {
            A_RandomizableLetters[i].text = A_Alphabet[Random.Range(0, A_Alphabet.Length)].ToString();

        }

    }

    public void WordCorrect()
    {
        // Play Correct Sound
        Audio_CorrectSound.Play();

        // _WordsFoundCounter + 1 / Total Words 
        _WordsFoundCounter++;
        // Write Counter in UI
        Txt_WordCounter.text = _WordsFoundCounter.ToString();
    }

    public void GameFinish()
    {
        // If _WordsFoundCounter = Words Total
        if (_WordsFoundCounter == _wordsTotal)
        {
            // Show EndScreen
            _EndScreen.SetActive(true);

            // Play EndGameSound
            Audio_FinishGameSound.Play();

            S_TimeCounter.TimeCounterStop();



        }      

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
            Audio_FailSound.Play();

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
            Audio_FailSound.Play();

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
            Audio_FailSound.Play();

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
    
    // EndScreen
    public void FindObjects()
    {
        // EndScreen + Final Counter Find&Disable
        _EndScreen = GameObject.Find("EndScreen");
        Txt_TimeFinal = GameObject.Find("TimeFinal").GetComponent<TMP_Text>();
        _EndScreen.SetActive(false);

        // Find Word Counter 
        Txt_WordCounter = GameObject.Find("WordCounter").GetComponent<TMP_Text>();
        

    }

}
