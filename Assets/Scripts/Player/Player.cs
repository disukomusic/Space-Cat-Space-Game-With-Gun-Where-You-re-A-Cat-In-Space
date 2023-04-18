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

    //public SkinnedMeshRenderer _meshRenderer;
    
    public float health;
    public float score;
    
    public TMP_Text HealthText;
    public TMP_Text ScoreText;

    public void HitPlayer(float damage)
    {
        Flasher.Instance.Flash(Color.red, 0.2f);
        DecreaseHealth(damage);
        //StartCoroutine(FlashColor(Color.red, 0.2f));
        
        SoundManager.PlaySoundAtPosition(SoundManager.Sound.PlayerHurt, transform.position);
            
        if (health < 1)
        {
            health = 0;
            GameManager.Instance.OnDeath();
        }
    }

    //todo: Find out how to change color of all player materials at once
    // IEnumerator FlashColor(Color color, float time)
    // {
    //     float t = 0;
    //     int i = 0;
    //
    //     foreach (Material material in _meshRenderer.materials)
    //     {
    //         Color a = color;
    //         Color b = Color.clear;
    //
    //         while (t < time)
    //         {
    //             _meshRenderer.materials[i].color = Color.Lerp(a, b, t);
    //             t += Time.deltaTime;
    //             yield return null;
    //         }
    //         i++;
    //         _meshRenderer.materials[i].color = b;
    //     }
    // }

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