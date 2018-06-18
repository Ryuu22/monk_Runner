using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour {

    Player player;
    public VictoryPoint victoryPoint;

   
    

	void Start ()
    {
        player = GetComponent<Player>();
        
	}
	
	// Update is called once per frame
	void Update ()
    {

#if UNITY_STANDALONE


     if (Input.GetKey(KeyCode.RightArrow) && player.landed) player.MakePlayerRun();   
     if (Input.GetKeyUp(KeyCode.RightArrow)) player.running = false;                    
     if (Input.GetKeyDown(KeyCode.UpArrow)) player.MakePlayerJump();
     if (Input.GetKeyDown(KeyCode.K) && victoryPoint.thisCanvas.isActiveAndEnabled) SceneManager.LoadScene("Menu");
 
     
#endif
#if UNITY_EDITOR
     foreach(Touch t in Input.touches)
        {
            if(t.position.x < Screen.width/2)
            {
                if(t.phase == TouchPhase.Began && player.landed)
                {
                    player.MakePlayerRun();
                }
                else if(t.phase == TouchPhase.Ended)
                {
                    player.running = false;
                }
            }
            else
            {
                if(t.phase == TouchPhase.Began)
                {
                    player.MakePlayerJump();
                }
            }
        }



#endif

    }


}
