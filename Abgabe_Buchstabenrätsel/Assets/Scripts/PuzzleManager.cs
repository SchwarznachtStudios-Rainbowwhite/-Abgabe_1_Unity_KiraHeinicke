using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PuzzleManager : MonoBehaviour
{
// VARIABELS

    // Scripts
    public Letter S_Letter;

    // Solution Words
    public TMP_Text[] A_Word1_Test;
    public TMP_Text[] A_Word2_Hallo;
    public TMP_Text[] A_Word3_Bye;

    // Random Letters
    public TMP_Text[] RandomizableLetters;
    public string[] Alphabet = new string[26] { "A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z" };

    // CheckWord Bools
    public bool[] A_Word1_Bool = new bool[3];
    private bool[] A_Word2_Bool;
    private bool[] A_Word3_Bool;



    // START
    void Start()
    {
        RandomizeLetters();
        
    }

// UPDATE
    void Update()
    {
        
    }

// FUNCTIONS

    public void RandomizeLetters()
    {
        for (int i = 0; i < RandomizableLetters.Length; i++)
        {
            RandomizableLetters[i].text = Alphabet[Random.Range(0, Alphabet.Length)].ToString();

        }

    }



    public void CheckWords()
    {

        
        // Check which letter is in the text(or button?) that has been clicked on
        // if the letter is fitting one of the three words, color button green, if not red
        // if one time red -> reset all 
        // repeat until end of word. if all buttons of a word are colored green, disable the clicking?


        /*if (A_Word1_Test[0].text == "T" || A_Word2_Hallo[0].text == "H"  ||  A_Word3_Bye[0].text == "B" )
        {
            Debug.Log("Letter 1 correct");

            // make button turn green

        }*/

    }

    


}
