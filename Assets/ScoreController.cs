using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    public TMP_Text ScoreText;
    [SerializeField]private Camera PlayerCamera;
    [SerializeField]private Transform Player;
    private int theScore;

    private void Update() 
    {
        
    }

    public void ScoreIncrease() {
        theScore++;
        ScoreText.text = theScore.ToString();
    }
}
