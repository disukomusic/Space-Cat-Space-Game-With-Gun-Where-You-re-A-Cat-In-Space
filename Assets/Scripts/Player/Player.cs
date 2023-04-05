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

    public int weapon;

    public void SetWeapon(int id)
    {
        Debug.Log("removed weapon" + weapon);
        weapon = id;
        Debug.Log("equipped weapon" + weapon);
    }
    public void IncreaseHealth(int value)
    {
        health += value;
        HealthText.text = $"HP: {health}";
    }
    
    public void IncreaseScore(int value)
    {
        score += value;
        ScoreText.text = $"HP: {score}";
    }
    public void ResetPlayerPosition()
    {
        transform.position = new Vector3(0, 0f, 0f);
    }
}