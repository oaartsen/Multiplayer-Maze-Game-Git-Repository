using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    // Configuration parameters
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] AudioClip deathSFX = null;
    [SerializeField] float deathSFXVolume = 1f;

    // Cached references
    Rigidbody2D myRigidBody = null;
    Animator myAnimator = null;
    BoxCollider2D myBoxCollider = null;

    // State variables
    float xInput = 0f;
    float yInput = 0f;
    bool playerHasHorizontalSpeed = false;
    bool isDead = false;
    bool isWalking = false;

    // Start is called before the first frame update
    void Start() {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBoxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update() {
        if (!isDead) {
            PlayerRun();
            FlipSprite();
        }
        if (!isWalking) {
            myRigidBody.velocity = new Vector2(0, 0);
        }
    }

    private void PlayerRun() {

        isWalking = false;
        if (xInput != 0) {
            myRigidBody.velocity = new Vector2(xInput * moveSpeed, myRigidBody.velocity.y);
            isWalking = true;
        }
        if (yInput != 0) {
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, yInput * moveSpeed);
            isWalking = true;
        }
        if (myRigidBody.velocity.magnitude > moveSpeed && xInput + yInput != 0) {
            myRigidBody.velocity = myRigidBody.velocity / Mathf.Sqrt(xInput * xInput + yInput * yInput); // Scaling the velocity vector so that it's magnitude won't exceed the moveSpeed
        }
        myAnimator.SetBool("isWalking", isWalking);
    }

    private void FlipSprite() {
        playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;

        if (playerHasHorizontalSpeed) {
            transform.localScale = new Vector3(-Mathf.Sign(myRigidBody.velocity.x) * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            // PROBLEM: So this localscale change doesn't work when an animation is playing; for some reason any animation (even the ones that do nothing with the scale of the object) constantly sets the scale of the object back to 1
        }
    }

    public void SetInput(float x, float y) {
        xInput = x;
        yInput = y;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Killer") {
            Die();
        }
    }

    private void Die() {
        myBoxCollider.enabled = false;
        Vector3 camPos = Camera.main.transform.position;
        camPos.z = camPos.z + 3f;
        AudioSource.PlayClipAtPoint(deathSFX, camPos, deathSFXVolume);
        myRigidBody.velocity = new Vector2(0, 0);
        isDead = true;
        myAnimator.SetBool("isDead", isDead);
    }

    private void DestroyGameObject() {
        Destroy(gameObject); // Maybe instead of destroying the game object we could also instead set the sprite renderer to inactive
    }
}
