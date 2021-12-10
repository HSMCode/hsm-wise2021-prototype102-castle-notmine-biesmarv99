using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public TextMeshProUGUI myScoreText;
    private int scoreNum; 

    void Start()
    {
        scoreNum = 0;
        myScoreText.text = ("Score: " + scoreNum);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag != "platform")
        {
            scoreNum += 1;
            myScoreText.text = ("Score: " + scoreNum);
            }
            

    }
}
