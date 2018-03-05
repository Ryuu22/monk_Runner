﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    [Header("Stats")]

    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private Vector2 maxVelocity;

    [Header("States")]

    public bool landed;
    public bool hittingWall;

    [SerializeField] private bool dialogMode;

    [Header("DetectionBoxes")]
    public ContactFilter2D filter;

    private Vector3 sideBoxSize;
    private Vector3 sideBoxPosition;

    private Vector3 floorBoxSize;
    private Vector3 posFloor;
    private Vector3 floorBoxPosition;


    public bool running; //Deserialize later
    [SerializeField] private bool falling; //Deserialize later
    [SerializeField] private bool raising; //Deserialize later

    private Rigidbody2D rb;
    private float monkVelocity;
    public Animator anim;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        running = false;

    }

    void Update()
    {
        if (this.transform.position.y < -10) Die();

        if(rb.velocity.x > maxVelocity.x)
        {
            rb.velocity = new Vector2(maxVelocity.x,rb.velocity.y);
        }

        if (landed && !running) MakePlayerStop();

        if (!landed && rb.velocity.y < 1.5f)
        {
            if(!running)rb.velocity = new Vector2(monkVelocity,rb.velocity.y);
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
            if(landed)rb.AddForce(speedV);
        }
    }

    public void MakePlayerRun()//switches on the boolean and activates the animation
    {
        if (!dialogMode)
        {
            running = true;
        }

    }

    public void MakePlayerStop()
    {
        running = false;
        rb.velocity = new Vector3 (0,rb.velocity.y,0);
    }
    public void MakePlayerJump()
    { 
        if(landed)
        {
            monkVelocity = rb.velocity.x;

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

    public void EnterDialogMode()
    {
        dialogMode = true;
        if(running)running = false;
        rb.velocity = Vector2.zero;
    }

    public void ExitDialogMode()
    {
        dialogMode = false;
    }

}
