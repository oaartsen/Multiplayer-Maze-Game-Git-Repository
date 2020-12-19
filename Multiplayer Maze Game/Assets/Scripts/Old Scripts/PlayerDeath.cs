using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour {

    // State variables
    bool isDead = false;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void Die() {
        isDead = true;
    }

    public bool GetIsDead() { return isDead; }

}
