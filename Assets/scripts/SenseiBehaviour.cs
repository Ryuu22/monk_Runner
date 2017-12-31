using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenseiBehaviour : MonoBehaviour {

    [SerializeField] private bool onDialog;
    [SerializeField] private GameObject focusPoint;
    [SerializeField] private GameObject canvas;

	// Use this for initialization
	void Start ()
    {
		
	}
	
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


	}
    private void OnTriggerEnter2D(Collider other)
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

        //TODO:change for an animation in the future
        canvas.SetActive(true);
        
        //add focus function on camera Find.gameobject.camera...
    }
    private void EndDialog()
    {
        FindObjectOfType<Player>().ExitDialogMode();

        //hide canvas
        canvas.SetActive(false);

    }
}
