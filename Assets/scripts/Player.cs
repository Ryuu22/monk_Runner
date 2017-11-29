using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


    [SerializeField] private bool running;
    [SerializeField] private Vector2 speed;
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
        if (Input.GetKeyDown(KeyCode.RightArrow)) MakePlayerRun();
        if (Input.GetKeyUp(KeyCode.RightArrow)) MakePlayerStop();

        if (running)
        {
            rb.AddForce(speed);
        }

        //Animation
        anim.SetBool("running", running);

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
