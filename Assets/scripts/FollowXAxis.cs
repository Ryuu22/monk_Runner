using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowXAxis : MonoBehaviour {

    public Transform cameraGO;
    public float time;

    Vector2 newPosition;


	// Use this for initialization
	void Start ()
    {
        cameraGO = GameObject.FindObjectOfType<Player>().transform;	
	}
	
	// Update is called once per frame
	void Update ()
    {

        this.transform.position = new Vector3(cameraGO.position.x,this.transform.position.y, this.transform.position.z);

    }
}
