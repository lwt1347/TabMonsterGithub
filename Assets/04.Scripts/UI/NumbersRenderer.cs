using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumbersRenderer : MonoBehaviour {

    [Range(0, 9999)]
    private int _value = 0;

    [SerializeField]
    private NumberRenderer[] _numberRenderers = new NumberRenderer[4];

    public int Value
    {
        get
        {
            return _value;
        }
        set
        {
            _value = value;
            Render();
        }
    }

    private void Render()
    {
            _numberRenderers[0].Value = (int)Mathf.Floor(_value / 1000.0f) % 10;
            _numberRenderers[1].Value = (int)Mathf.Floor(_value / 100.0f) % 10;
            _numberRenderers[2].Value = (int)Mathf.Floor(_value / 10.0f) % 10;
            _numberRenderers[3].Value = (int)Mathf.Floor(_value / 1.0f) % 10;

        

    }


}
