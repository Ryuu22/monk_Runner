using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {

    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform cameraTransform;

    [SerializeField] private float freq;
    [SerializeField] private float focusFreq;
    [SerializeField] private bool focusMode;

    [SerializeField] private GameObject tempFocusPoint;

    private Vector2 cameraPos;


    void Start ()
    {

        GameObject player = GameObject.FindWithTag("Player");
        playerTransform = player.GetComponent<Transform>();

        cameraTransform = this.GetComponent<Transform>();
	}
	

	void Update ()
    {

        if(focusMode)
        {
            cameraPos = Vector2.Lerp(cameraTransform.position, tempFocusPoint.transform.position, focusFreq);

            cameraTransform.position = new Vector3(cameraPos.x, cameraPos.y, -10);
        }
        else
        {
            cameraPos = Vector2.Lerp(cameraTransform.position, playerTransform.position, freq);

            cameraTransform.position = new Vector3(cameraPos.x, cameraPos.y, -10);
        }

	}
    public void EnterFocusMode(GameObject focuspoint)
    {
        focusMode = true;
        tempFocusPoint = focuspoint;
    }

    public void ExitFocusMode()
    {
        focusMode = false;
    }
}
