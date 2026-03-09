using UnityEngine;

public class Freeze : Pickup
{
    public int freezeTime = 10;

    protected override void Pick()
    {
        base.Pick(); //Destroy

        GameManager.Instance.FreezeTime(freezeTime);
    }
}
