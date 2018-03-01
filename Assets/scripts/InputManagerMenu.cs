using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManagerMenu : MonoBehaviour {

    MenuLevelList levelList;
    Vector2 flashTouch = Vector2.zero;
    [Range(0,1000)]public float minimumTouchDistance;

    void Start ()
    {
        levelList = FindObjectOfType<MenuLevelList>();

	}
	
	// Update is called once per frame
	void Update ()
    {
#if UNITY_STANDALONE

        if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                levelList.MoveRight();
            }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                levelList.MoveLeft();
            }
        if(Input.GetKeyDown(KeyCode.Space))
            {
                levelList.EnterScene();
            }
#endif
#if UNITY_EDITOR

        if(Input.touchCount > 0)
        {
                if(Input.GetTouch(0).phase == TouchPhase.Began)
            {
                flashTouch = Input.GetTouch(0).position;
            }
            if(Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                float touchLength = Input.GetTouch(0).position.x - flashTouch.x;

                if(touchLength < -minimumTouchDistance)
                {
                    Debug.Log(Input.GetTouch(0).position.x - flashTouch.x);
                    levelList.MoveRight();
                }
                else if(touchLength > minimumTouchDistance)
                {
                    Debug.Log(Input.GetTouch(0).position.x - flashTouch.x);
                    levelList.MoveLeft();
                }
            }
        }


#endif

    }


}
