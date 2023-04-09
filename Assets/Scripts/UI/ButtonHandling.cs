using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonHandling : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public Sprite startNormal;
    public Sprite startHighlight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Image>().sprite = startHighlight;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Image>().sprite = startNormal;
    }

}
