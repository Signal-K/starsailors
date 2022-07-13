/*
 * This is a temp class for a generic item screen so I can test the item code : Chris
 */

/* Commenting the rest out due to this error: Assets/Scripts/Items/Store.cs(16,30): error CS0117: 'Player' does not contain a definition for 'Instance'

using UnityEngine;

public class Store : InstanceMonoBehaviour<Store> // store is temp, this is just to test the item windows
{
   public ItemWindow window_1;
   public ItemWindow window_2;

   protected override void Awake()
   {
       base.Awake();

       window_1.Init(Player.Instance.backpack_1, 8, 3, false);
       window_2.Init(Player.Instance.backpack_2, 8, 3, false);
   }

   private void Start()
   {
       window_1.RefreshItems(0);
       window_2.RefreshItems(0);
   }
}
*/