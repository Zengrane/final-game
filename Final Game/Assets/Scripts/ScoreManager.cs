using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI text;
    public int targetScore;
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
        text.text = "X " + score.ToString() + " / 7";

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
