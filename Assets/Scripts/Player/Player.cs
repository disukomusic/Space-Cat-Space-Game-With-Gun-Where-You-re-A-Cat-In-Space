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
        SetHealth(999);
        SetScore(0);
    }

    public float health;
    public float score;
    
    public TMP_Text HealthText;
    public TMP_Text ScoreText;


    public void SetHealth(float value)
    {
        health = value;
        HealthText.text = $"HP: {health}";
    }
    public void IncreaseHealth(float value)
    {
        health += value;
        HealthText.text = $"HP: {health}";
    }
    
    public void DecreaseHealth(float value)
    {
        health -= value;
        HealthText.text = $"HP: {health}";
    }
    
    public void SetScore(float value)
    {
        score = value;
        ScoreText.text = $"Score: {score}";
    }
    public void IncreaseScore(float value)
    {
        score += value;
        ScoreText.text = $"Score: {score}";
    }
    public void ResetPlayerPosition()
    {
        transform.position = new Vector3(0, 0f, 0f);
    }

}