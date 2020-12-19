using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlayer3 : MonoBehaviour {

    // Cached references

    // State variables
    float xInput = 0f;
    float yInput = 0f;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        xInput = Input.GetAxis("Horizontal3");
        yInput = Input.GetAxis("Vertical3");
        GetComponent<PlayerMovement>().SetInput(xInput, yInput);
    }


}
