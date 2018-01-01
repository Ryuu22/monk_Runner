using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenseiBehaviour : MonoBehaviour {

    [SerializeField] private bool onDialog;
    [SerializeField] private GameObject focusPoint;
    [SerializeField] private GameObject canvas;


	
	// Update is called once per frame
	void Update ()
    {
		if(onDialog)
        {
            if(Input.GetKey(KeyCode.K)) //TODO: change provisional
            {
                if(true)/*Change by a counter when more text is added*/
                {
                    EndDialog();
                }
            }
        }
        //Animation
        canvas.GetComponentInChildren<Animator>().SetBool("display", onDialog);

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == ("Player"))
        {
            other.GetComponent<Player>().EnterDialogMode();

            StartDialog();

        }
    }
    private void StartDialog()
    {
        onDialog = true;

        FindObjectOfType<CameraBehaviour>().EnterFocusMode(focusPoint);

    }
    private void EndDialog()
    {
        FindObjectOfType<Player>().ExitDialogMode();
        FindObjectOfType<CameraBehaviour>().ExitFocusMode();
        onDialog = false;

    }
}
