﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    [Header("Stats")]

    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    [Header("States")]

    [SerializeField] private bool landed;
    [SerializeField] private bool hittingWall;

    [Header("DetectionBoxes")]
    [SerializeField] private ContactFilter2D filter;

    [SerializeField] private Vector3 sideBoxSize;
    [SerializeField] private Vector3 sideBoxPosition;

    [SerializeField] private Vector3 floorBoxSize;
    [SerializeField] private Vector3 posFloor;
    [SerializeField] private Vector3 floorBoxPosition;


    [SerializeField] private bool running; //Deserialize later
    [SerializeField] private bool falling; //Deserialize later
    [SerializeField] private bool raising; //Deserialize later

    private Rigidbody2D rb;
    public Animator anim;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        running = false;
        speed = 10.0f;

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) && landed) MakePlayerRun();      //provisional Run input
        if (Input.GetKeyUp(KeyCode.RightArrow)) running = false;       //provisional Stop input

        if (Input.GetKeyDown(KeyCode.UpArrow)) MakePlayerJump();       //provisional Stop input

        if (landed && !running) MakePlayerStop();

        if (!landed && rb.velocity.y < 1.5f)
        {
            falling = true;
            raising = false;
        }
        else if (!landed && rb.velocity.y > 0)
        {
            falling = false;
            raising = true;
        }
        else
        {
            falling = false;
            raising = false;
        }
            //Animation
            anim.SetBool("running", running);
        anim.SetBool("landed", landed);
        anim.SetBool("falling", falling);
        anim.SetBool("raising", raising);

        DetectFloor();

    }
    void FixedUpdate()
    {
        if (running)
        {
            Vector2 speedV = new Vector2(speed, 0);
            rb.AddForce(speedV);
        }
    }

    void MakePlayerRun()//switches on the boolean and activates the animation
    {
        running = true;
    }

    void MakePlayerStop()
    {
        running = false;
        rb.velocity = new Vector3 (0,rb.velocity.y,0);
    }
    void MakePlayerJump()
    { 
        if(landed)
        {
            Vector2 jumpForceV = new Vector2(0, jumpForce);
            rb.AddForce(jumpForceV);
        }

    }
    public void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    #region Environment detection

    void DetectFrontWall()
    {

    }

    void DetectFloor()
    {
        posFloor = this.transform.position + (Vector3)floorBoxPosition;
        Collider2D[] results = new Collider2D[1];

        int numColliders = Physics2D.OverlapBox(posFloor, floorBoxSize, 0, filter, results);

        if (numColliders > 0) landed = true;
        else landed = false;

    }

    #endregion

    private void OnDrawGizmos()
    {
       Gizmos.color = Color.red;


        //Gizmos.DrawWireCube(sideBoxPosition,sideBoxSize);
        Gizmos.DrawWireCube(posFloor, floorBoxSize);
    }

}
