using UnityEngine;

public class Clock : Pickup
{
    public int timeToAdd = 10;

    protected override void Pick()
    {
        base.Pick(); //Destroy

        GameManager.Instance.AddTime(timeToAdd);
    }
}
