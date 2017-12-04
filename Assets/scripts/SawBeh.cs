using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawBeh : MonoBehaviour {

    private Transform sprite;

    [SerializeField]private float speedRotation;

    private void Start()
    {
        sprite = GetComponentInChildren<Transform>();
    }

    void Update ()
    {
        sprite.Rotate(new Vector3(0, 0, speedRotation));
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        player.Die();
    }
}
