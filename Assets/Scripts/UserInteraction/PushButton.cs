using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PushButton : MonoBehaviour
{
    public Sprite[] buttonSprite;
    public Image buttonImage;
    
    public void ChangeSprite()
    {
        this.buttonImage.sprite = (this.buttonImage.sprite == buttonSprite[0] ? buttonSprite[1] : buttonSprite[0]);
    }
}
