using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerItem : MonoBehaviour
{
    private PlayerMovement Player;
    private GameItemHandler Handle;


    //how long between picking up the item and using it
    public float DelayBeforeItemPickup = 1;
    
    // 0 == null
    public int HeldItem;

    //if player can pickup item
    public bool CanPickup;
    
    //if pressing use button
    private bool UseItem;

    //Stores current held item
    public Item ItmUse;

    //Uses of the item
    private int RemainingItemUses;
    
    // Start is called before the first frame update
    void Start()
    {
        Handle = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameItemHandler>();

        Player = GetComponent<PlayerMovement>();

        ResetItem();
    }

    // Update is called once per frame
    void Update()
    {
        UseItem = Input.GetButtonDown("Item");
        if(UseItem && HeldItem != -1)
        {
            ActivateItem();
        }
    }

    public void StartPickup()
    {
        StartCoroutine(PickUp());
    }

    public IEnumerator PickUp()
    {
        if(HeldItem == -1 && CanPickup)
        {
            CanPickup = false;
            //play pickup animation

            yield return new WaitForSeconds(DelayBeforeItemPickup);
            //Choose item to be held

            int ItemRand = Random.Range(0, Handle.AllItems.Length);

            ItmUse = Handle.AllItems[ItemRand];

            HeldItem = ItemRand;
            RemainingItemUses = ItmUse.Uses;

        }
    }

    public void ActivateItem()
    {
        RemainingItemUses -= 1;

        if(ItmUse.Boost.Length > 0)
        {

            //this item has a boost function so boost
            foreach (ItemBoostFunction ItmBoost in ItmUse.Boost)
            {
                //boost player forward
                Player.Boost(ItmBoost.BoostAmt);
            }

        }

        if(RemainingItemUses <= 0)
        {
            //this item is used up, reset values
            ResetItem();
        }
    }

    
    public void ResetItem()
    {
        ItmUse = null;
        HeldItem = -1;
        CanPickup = true;
    }
}
