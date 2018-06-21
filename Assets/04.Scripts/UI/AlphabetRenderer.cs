using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlphabetRenderer : MonoBehaviour {

    [Range(0, 26)] //0~26 사이의 값
    private int _value = 0;

    [SerializeField]
    private Image image = null;

    [SerializeField]
    private Sprite[] sprites = new Sprite[7];

    public int Value
    {
        get { return _value; }
        set
        {
            _value = value;
            Render();
        }
    }

    private void Render()
    {
        if (0 <= Value && Value < sprites.Length)
        {
            image.sprite = sprites[Value];
        }
    }

}
