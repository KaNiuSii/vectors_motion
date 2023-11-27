using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSprite : MonoBehaviour
{
    public Sprite one;
    public Sprite two;
    private bool flag = false;
    private Image image;
    private void Start()
    {
        image = GetComponent<Image>();
    }

    public void ChangeMySprite()
    {
        image.sprite = flag ? one : two;
        flag = !flag;
    }
}
