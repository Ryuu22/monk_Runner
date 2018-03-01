using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenseiBehaviour : MonoBehaviour {

    [SerializeField] private bool onDialog;
    [SerializeField] private GameObject focusPoint;
    [SerializeField] private GameObject canvas;
    [SerializeField] private string[] dialogs;
    [SerializeField] private GameObject text;
    private int pointer;

	
	// Update is called once per frame
	void Update ()
    {
		if(onDialog)
        {
            if(Input.GetKey(KeyCode.K) || Input.touchCount > 0) //TODO: change provisional
            {
                if(dialogs.Length > pointer)/*Change by a counter when more text is added*/
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
