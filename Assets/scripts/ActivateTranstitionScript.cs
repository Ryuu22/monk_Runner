using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateTranstitionScript : MonoBehaviour {

    bool loadingActive;
    public float transitionTime;
    float counter;

    public Image blackSquare;
    float initialValue;
    public float currentValue;
    public float deltaValue;

    // Use this for initialization
    void Start()
    {
        loadingActive = true;
        initialValue = blackSquare.color.a;
        currentValue = initialValue;
    }

    // Update is called once per frame
    void Update()
    {

        if (loadingActive && transitionTime > counter)
        {
            currentValue = Easing.QuintEaseOut(counter, initialValue, deltaValue, transitionTime);
            blackSquare.color = new Color(0, 0, 0, currentValue);
            counter += Time.deltaTime;
        }

    }
}
