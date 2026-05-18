using UnityEngine;

public class Diamond : Pickup
{
    protected override void Pick()
    {
        base.Pick(); //Destroy

        GameManager.Instance.points++;
    }
}
