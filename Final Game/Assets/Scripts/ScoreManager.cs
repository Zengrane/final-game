using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI text;
    int score;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
            
    }

    public void ChangeScore(int canValue)
    {
        score += canValue;
<<<<<<< HEAD
        text.text = "X " + score.ToString() + " / 5";
=======
        text.text = "X " + score.ToString() + " / 7";
>>>>>>> parent of 8113d951 (Rubbish Spawning +)
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
