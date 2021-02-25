using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITween : MonoBehaviour
{
    [SerializeField] float time = 0f;
    [SerializeField] LeanTweenType type;
    

    void Start()
    {
        //drop
        LeanTween.moveLocalY(gameObject, 120f,time).setEase(type);
        //Fade
        //LeanTween.alphaText(gameObject.GetComponent<RectTransform>(), 0f, 1f).setEase(LeanTweenType.easeInCirc);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
