using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Texture2D map;
    public ColorToPrefab[] colorMappings;
    public float offset = 5f;

    public void Clear()
    {
        for(int i = transform.childCount - 1; i >= 0; i--)
        {
            Transform child = transform.GetChild(i);
            DestroyImmediate(child.gameObject);
        }
    }

    void GenerateTile(int x, int z)
    {
        Color pixelColor = map.GetPixel(x, z);
        if(pixelColor.a == 0)
        {
            return;
        }
        foreach(ColorToPrefab colorMapping in colorMappings)
        {
            if(colorMapping.color.Equals(pixelColor))
            {
                Vector3 position = new Vector3(x, 0, z) * offset;
                Transform tile = Instantiate(colorMapping.prefab, position, Quaternion.identity, transform).transform;
                tile.localPosition = position;
            }
        }
    }

    public void GenerateLabirynth()
    {
        Clear();

        for(int x = 0; x < map.width; x++)
        {
            for(int z = 0; z < map.height; z++)
            {
                GenerateTile(x,z);
            }
        }
    }

}
