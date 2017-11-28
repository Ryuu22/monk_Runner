using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


    [SerializeField] private bool running;
    // Use this for initialization
    void Start()
    {
        running = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (running)
        {

        }
    }

    void MakePlayerRun()
    {
        running = true;
    }

    void MakePlayerStop()
    {

    }

}
