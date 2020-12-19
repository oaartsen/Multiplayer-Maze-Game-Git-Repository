using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public string Name;
    public string Description;
    public int Uses;

    //How many times boost is called when using the item.
    public ItemBoostFunction[] Boost;

    //for UI later
    public Sprite Visual;
}
