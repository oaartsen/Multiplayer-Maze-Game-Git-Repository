using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killer : MonoBehaviour {

    // State variables
    bool canKill = false;
    GameObject otherPlayer = null;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        KillPlayer();
    }

    private void KillPlayer() {
        if (canKill && Input.GetAxis("Jump") > Mathf.Epsilon) {
            // play sound and maybe animation
            otherPlayer.GetComponent<PlayerDeath>().Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            Debug.Log("CAN KILL");
            canKill = true;
            otherPlayer = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Player") {
            canKill = false;
        }
    }

}
