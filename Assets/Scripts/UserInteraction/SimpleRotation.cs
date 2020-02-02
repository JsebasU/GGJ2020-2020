using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRotation : MonoBehaviour
{
    private float moveSpeed = 1f;
    public ObjectType type = ObjectType.moon;
    public Vector3 direction = Vector3.up;
    public bool isSprite = false;
    private Camera camera;
    public enum ObjectType
    {
        moon,
        cow,
        ufo
    };
    
    private void Start()
    {
        switch(type)
        {
            case ObjectType.moon:
                this.moveSpeed = GameVariables.MoonSpeed;
                break;
            case ObjectType.cow:
                this.moveSpeed = GameVariables.CowSpeed;
                break;
            case ObjectType.ufo:
                this.moveSpeed = GameVariables.UfoSpeed;
                break;
        }
        this.camera = Camera.main;
    }

    void Update()
    {
        transform.Rotate(Time.deltaTime * this.moveSpeed * this.direction);
        transform.GetChild(0).LookAt(this.camera.transform);
    }
}
