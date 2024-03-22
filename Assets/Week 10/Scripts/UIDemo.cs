using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIDemo : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public SpriteRenderer sr;

    public Color start;
    public Color end;

    public Vector3 startSize = new Vector3(0.5f, 0.5f, 0.5f);
    public Vector3 endSize = new Vector3(2f, 2f, 2f);

    float interpolation;
    public void SliderHasChangedValue(Single value)
    {
        interpolation = value;
        sr.transform.localScale = Vector3.Lerp(startSize, endSize, interpolation);
    }

    public void DropdownHasChangedValue(int value)
    {
        Debug.Log(dropdown.options[value].text);
    }

    private void Update()
    {
        
    }
}
