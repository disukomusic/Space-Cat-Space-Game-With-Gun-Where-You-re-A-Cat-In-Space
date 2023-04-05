using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player Instance;
    
    private void Awake()
    {
        Instance = this;
    }

    public float health;
    public float score;
    public TMP_Text HealthText;
    public TMP_Text ScoreText;


    public void IncreaseHealth(float value)
    {
        health += value;
        HealthText.text = $"HP: {health}";
    }
    
    public void IncreaseScore(float value)
    {
        score += value;
        ScoreText.text = $"HP: {score}";
    }
    public void ResetPlayerPosition()
    {
        transform.position = new Vector3(0, 0f, 0f);
    }
}