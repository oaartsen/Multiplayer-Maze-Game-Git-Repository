using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemUiHandler : MonoBehaviour
{
    private bool shuffleSprite; //if the handle shuffles between sprite icons
    public float TimeBtwShuffle; //duration of shuffling an image
    public Sprite[] AllItemGraphics; //cycle through when item is being selected

    public Sprite EmptyItem;

    public Image Img; //what image to change

    public PlayerItem Player; // player's item


    
    // Start is called before the first frame update
    private void Start()
    {
        shuffleSprite = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.HeldItem == -1)
        {
            if(Player.CanPickup)
            {
                //no item is held, no image shown
                Img.sprite = EmptyItem;
            }
            else
            {
                //cycle through all item graphics
                if(shuffleSprite)
                {
                    Invoke("Shuffle",TimeBtwShuffle);
                    shuffleSprite = false;
                }
            }
        }
        else
        {
            Img.sprite = Player.ItmUse.Visual;
        }
    }

    void Shuffle()
    {
        Img.sprite = AllItemGraphics[Random.Range(0, AllItemGraphics.Length)];
        shuffleSprite = true;
    }
}
