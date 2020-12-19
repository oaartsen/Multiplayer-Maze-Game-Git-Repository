using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIsKiller : MonoBehaviour {

    // State variables
    bool iskiller = true;
    GameObject killerObject = null;

    // Start is called before the first frame update
    void Start() {
        if (iskiller) {
            gameObject.tag = "Killer";
        }
    }

    // Update is called once per frame
    void Update() {
        
    }

    //public void SetIsKillerToTrue() {
    //    iskiller = true;
    //}

}
