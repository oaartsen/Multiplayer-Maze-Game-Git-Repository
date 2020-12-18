using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    // Configuration parameters
    [SerializeField] float moveSpeed = 5f;

    // Cached references
    Rigidbody2D myRigidBody = null;

    // State variables
    float xInput = 0f;
    float yInput = 0f;
    bool playerHasHorizontalSpeed = false;

    // Start is called before the first frame update
    void Start() {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        PlayerRun();
        FlipSprite();
    }

    private void PlayerRun() {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

        if (xInput != 0) {
            myRigidBody.velocity = new Vector2(xInput * moveSpeed, myRigidBody.velocity.y);
        }
        if (yInput != 0) {
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, yInput * moveSpeed);
        }
    }

    private void FlipSprite() {
        playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;

        if (playerHasHorizontalSpeed) {
            transform.localScale = new Vector2(-Mathf.Sign(myRigidBody.velocity.x) * Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }
    }
}
