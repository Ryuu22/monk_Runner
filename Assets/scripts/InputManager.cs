using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    Player player;
	void Start ()
    {
        player = GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (Input.GetKey(KeyCode.RightArrow) && player.landed) player.MakePlayerRun();   
        if (Input.GetKeyUp(KeyCode.RightArrow)) player.running = false;                    
        if (Input.GetKeyDown(KeyCode.UpArrow)) player.MakePlayerJump();     
    }
}
