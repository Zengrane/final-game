using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Dialog : MonoBehaviour
{
	public GameObject textBox; // Gets the text box game object
	public TextMeshProUGUI textDisplay;
	public PlayerMovement script;
	public Can can;
	public string[] sentences; // Holds all sentences that make up dialog
	private int index;
	public float typingSpeed;
	public GameObject continueButton;
	public GameObject[] cans;


	void Start()
	{
		continueButton.SetActive(false);
		textBox.SetActive(false);

		foreach (GameObject can in cans)
		{
			can.SetActive(false);
		}
	}

	
	void Update()
	{

		if (textDisplay.text == sentences[index])
		{
			continueButton.SetActive(true);
			textBox.SetActive(true);

		}

		
	
	}


	private void OnTriggerEnter2D(Collider2D other)
	{
		

		if (other.CompareTag("Player"))
		{
			Debug.Log("Player in range");

			script.canMove = false;

			StartCoroutine(Type());

		}

		
	}

	private void OnTriggerExit2D(Collider2D other)
	{
	

		if (other.CompareTag("Player"))
		{
			Debug.Log("Player left range");

		   
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
			textBox.SetActive(false);

			script.canMove = true;

			foreach (GameObject can in cans)
			{
				can.SetActive(true);
			}



		}
	}

	
}
