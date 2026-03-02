using UnityEngine;

public class Key : Pickup
{
    public KeyType keyType;

    protected override void Pick()
    {
        base.Pick();

        GameManager.Instance.AddKey(keyType);
    }
}

public enum KeyType
{
    Gold, Silver, Bronze
}

