using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (Input.GetKey(KeyCode.RightArrow)) MakePlayerRun();      //provisional Run input
        if (Input.GetKeyUp(KeyCode.RightArrow) && landed) MakePlayerStop();       //provisional Stop input

        if (Input.GetKeyDown(KeyCode.UpArrow)) MakePlayerJump();       //provisional Stop input

        
        //Animation
        anim.SetBool("running", running);

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
        rb.velocity = Vector3.zero;
    }
    void MakePlayerJump()
    { 
        Vector2 jumpForceV = new Vector2(0, jumpForce);
        rb.AddForce(jumpForceV);
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
