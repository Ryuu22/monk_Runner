using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    Player player;
    MenuLevelList levelList;
    public bool gamePlayScene;

	void Start ()
    {
        if (gamePlayScene) player = GetComponent<Player>();
        else levelList = FindObjectOfType<MenuLevelList>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(gamePlayScene)
        {
            if (Input.GetKey(KeyCode.RightArrow) && player.landed) player.MakePlayerRun();   
            if (Input.GetKeyUp(KeyCode.RightArrow)) player.running = false;                    
            if (Input.GetKeyDown(KeyCode.UpArrow)) player.MakePlayerJump(); 
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                levelList.MoveRight();
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                levelList.MoveLeft();
            }
        }
    
    }
}
