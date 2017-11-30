using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [Header("Stats")]

    [SerializeField] private Vector2 speed;
    [SerializeField] private float jumpForce;

    [SerializeField] private bool running; //deserialize

    private Rigidbody2D rb;
    public Animator anim;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        running = false;
        speed.x = 10.0f;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow)) MakePlayerRun();      //provisional Run input
        if (Input.GetKeyUp(KeyCode.RightArrow)) MakePlayerStop();       //provisional Stop input


        //Animation
        anim.SetBool("running", running);

    }
    void FixedUpdate()
    {
        if (running)
        {
            rb.AddForce(speed);
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

}
