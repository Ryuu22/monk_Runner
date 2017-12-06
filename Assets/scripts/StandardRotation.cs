using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardRotation : MonoBehaviour {

    // Use this for initialization
    [SerializeField] float speed;
    [SerializeField] float time;
    [SerializeField] float timeCounter;



    // Update is called once per frame
    void Update ()
    {
        if (timeCounter < time) timeCounter += Time.deltaTime;
        else
        {
            timeCounter = 0;
            speed *= -1;
        }
        this.transform.Rotate(new Vector3(0, 0, speed));
	}
}
