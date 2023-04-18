using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class Flasher : MonoBehaviour
{
    public static Flasher Instance;

    public Image image;
    
    void Awake()
    {
        Instance = this;
    }

    public void Flash(Color color, float time)
    {
        StopAllCoroutines();
        image.color = color;
        StartCoroutine(FlashAnim(color, time));
    }
    
    IEnumerator FlashAnim(Color color, float time)
    {
        
        float t = 0;
        image.color = color;
        
        while (t < time)
        {
            image.color = Color.Lerp(color, Color.clear, t);
            t += Time.deltaTime;
            yield return null;
        }
        image.color = Color.clear;
        yield return null;
    }
}
