using UnityEngine;

public class Diamond : Pickup
{
    public AudioClip clip;
    protected override void Pick()
    {
        base.Pick(); //Destroy

        SoundManager.Instance.PlaySFX(clip);
        GameManager.Instance.points++;
    }
}
