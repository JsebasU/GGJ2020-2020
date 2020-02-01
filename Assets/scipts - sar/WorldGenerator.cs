using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WorldGenerator : MonoBehaviour
{
    private Vector3[] vertices;
    private Vector3[] vertPositions;
    private MeshFilter mundo;
    private Vector3 center;
    public float scaleX;
    public float scaleY;




    void Awake()
    {
        mundo = GetComponent<MeshFilter>();
        center = mundo.mesh.bounds.center;
        vertices = mundo.mesh.vertices;
        vertPositions = mundo.mesh.vertices;

        
        //generateTerrain();

    }




    void generateTerrain()
    {
        

        for (int i = 0; i < vertices.Length; i++)
        {
            float angle = Vector3.Angle(vertices[i], center);
            angle = Remap(angle, 0, 360, 0, 1);

            float noise = 0.7f;

            vertices[i].x = vertices[i].x + (center.x/angle)*noise;
            vertices[i].y = vertices[i].y + (center.y/angle)*noise;
            vertices[i].z = vertices[i].z + (center.z/angle)*noise;

        }
               
        mundo.mesh.vertices = vertices;
    }
        
 
    float Remap(float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }
}
