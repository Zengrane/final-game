using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences; // Holds all sentences that make up dialog
    private int index;
    public float typingSpeed;

    public GameObject continueButton;
    

    void Start()
    {
        StartCoroutine(Type());
    }

    void Update()
    {
        if(textDisplay.text == sentences[index]) 
        {
            continueButton.SetActive(true);
        }
    }

    IEnumerator Type() //Couroutine allows to execute game logic over a number of frames
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed); //Code below will be delayed by (x)

        } 
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);

        if(index < sentences.Length - 1) //Checks whether index is less than number of elements in array (array start at 0)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }

        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
        }
    }
   
}
