using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI scoreTextLeft;
    public TextMeshProUGUI scoreTextRight;

    private int scoreLeft = 0;
    private int scoreRight = 0;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ScoreGoalLeft()
    {
        this.scoreRight += 1;
        UpdateUI();
    }
    public void ScoreGoalRight()
    {
        this.scoreLeft += 1;
        UpdateUI();
    }

    private void UpdateUI()
    {
        this.scoreTextLeft.text = this.scoreLeft.ToString();
        this.scoreTextRight.text = this.scoreRight.ToString();
    }
}
