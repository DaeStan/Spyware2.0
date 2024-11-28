using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpriteController : MonoBehaviour
{
    public Image image;
    public Sprite glitchSprite;
    public Sprite baseSprite;

    public void ChangeToGlitchingSprite()
    {
        image.sprite = glitchSprite;
    }

    public void ChangeToBaseSprite()
    {
        image.sprite = baseSprite;
    }
}
