using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    [Header("Stats")]

    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    [Header("States")]

    public bool landed;
    public bool hittingWall;

    [SerializeField] private bool dialogMode;

    [Header("DetectionBoxes")]
    private ContactFilter2D filter;

    private Vector3 sideBoxSize;
    private Vector3 sideBoxPosition;

    private Vector3 floorBoxSize;
    private Vector3 posFloor;
    private Vector3 floorBoxPosition;


    public bool running; //Deserialize later
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
    }

    public void ExitDialogMode()
    {
        dialogMode = false;
    }

}
