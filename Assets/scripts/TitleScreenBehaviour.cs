using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreenBehaviour : MonoBehaviour {

    // Use this for initialization

    bool loadingActive;
    public float transitionTime;
    float counter;

    public Image blackSquare;
    float initialValue;
    public float currentValue;
    public float deltaValue;

    public AudioSource AuSo;

    void Start()
    {
        initialValue = 0;
        blackSquare.color = new Color(0, 0, 0, 0);
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
        else if (loadingActive && transitionTime < counter)
        {
            SceneManager.LoadScene("Menu");
        }
    }
    public void GoToSelectionMenu()
    {
        loadingActive = true;

    }

    public static void ExitGame()
    {
        Application.Quit();
    }

}
