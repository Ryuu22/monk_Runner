using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryPoint : MonoBehaviour {

    public Canvas thisCanvas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            ShowVictory();
            collision.GetComponent<Player>().Victory = true;

            PlayerPrefs.SetInt("unlockedLevels", 1);
        }
    }

    void ShowVictory()
    {
        thisCanvas.gameObject.SetActive(true);
    }

}
