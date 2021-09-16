using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] GameObject dialogBox;
    [SerializeField] Text dialogText;
    [SerializeField] int lettersPerSecond;

    public static DialogueManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void ShowDialog(Dialogue dialog)
    {
        dialogBox.SetActive(true);
        StartCoroutine(TypeDialog(dialog.Lines[0]));
    }

    public IEnumerator TypeDialog(string dialog)
    {
        dialogText.text = ""; // Setting text in dialogue to empty string
        foreach (var letter in dialog.ToCharArray()) // Pick through each letter in dialogue
        {
            dialogText.text += letter; // Add one by one
            yield return new WaitForSeconds(1f / lettersPerSecond); // Types out dialogue
        }

    }
}
