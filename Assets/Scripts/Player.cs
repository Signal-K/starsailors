/*
 * This is a temp class for the player so I can access the inventory : Chris
 */

/* I'm commenting the rest of this out due to this error: `Assets/Scripts/Player.cs(7,14): error CS0101: The namespace '<global namespace>' already contains a definition for 'Player'`
using UnityEngine;

public class Player : InstanceMonoBehaviour<Player>
{
    public Inventory backpack_1 = new Inventory();
    public Inventory backpack_2 = new Inventory();

    protected override void Awake()
    {
        base.Awake();

        backpack_1.Init(10 * 8);
        backpack_2.Init(10 * 8);

        for (int i = 0; i < 6; i++)
        {
            backpack_1.PutItemAt(Item.GetRandomType(), Random.Range(1, 99), i);
            backpack_2.PutItemAt(Item.GetRandomType(), Random.Range(1, 99), i);
        }

        //for (int i = 0; i < backpack.CountItems(); i++)
        //    Debug.Log("item " + i + " is " + backpack.GetItemAt(i).type + " # " + backpack.GetItemAt(i).number);
    }

}
*/