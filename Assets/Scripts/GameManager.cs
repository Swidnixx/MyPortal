using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    
    public int time = 90;
    bool paused;
    private int diamonds = 0;
    int GoldKeys, SilverKeys, BronzeKeys = 0;

    private void Start()
    {
        InvokeRepeating(nameof(Stopper), 3, 1);
    }

    void Stopper()
    {
        time--;
        if (time <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        CancelInvoke(nameof(Stopper));
    }

    public void AddDiamond()
    {
        diamonds++;
    }

    public void AddKey(KeyType keyType)
    {
        switch (keyType)
        {
            case KeyType.Gold:
                GoldKeys++;
                break;
            case KeyType.Silver:
                SilverKeys++;
                break;
            case KeyType.Bronze:
                BronzeKeys++;
                break;
        }
    }
}
