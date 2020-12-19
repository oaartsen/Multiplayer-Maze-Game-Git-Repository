using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if(other.GetComponent<PlayerItem>().HeldItem == -1 && other.GetComponent<PlayerItem>().CanPickup)
            {
                //start the player item script

                other.GetComponent<PlayerItem>().StartPickup();
                Destroy(this.gameObject);
            }
        }
    }
}
