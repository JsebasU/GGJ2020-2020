using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noiseGenerator : MonoBehaviour
{
    public int height = 256;
    public int width = 256;
    public float scale = 1;

    private void Awake()
    {
        Renderer renderer = GetComponent<MeshRenderer>();
        renderer.material.mainTexture = generate();
    }

    Texture2D generate()
    {
        Texture2D texture = new Texture2D(width, height);

        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y<height; y++)
            {
                Color color = calculateColor(x,y);
                texture.SetPixel(x, y, color);

            }
        }
        texture.Apply();
        return texture;
    }

    Color calculateColor(int x, int y)
    {
        float xCord = (float)x / width * scale;
        float yCord = (float)y / height * scale;

        float sample = Mathf.PerlinNoise(xCord, yCord) * 5 - 2; 
        return new Color(sample, sample, sample);
    }
}
