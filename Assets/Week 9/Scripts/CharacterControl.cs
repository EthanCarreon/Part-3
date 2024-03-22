using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterControl : MonoBehaviour
{
    public TMPro.TextMeshProUGUI currentSelection;

    public TMP_Dropdown dropdown;

    public Vector3 startSize = new Vector3(0.5f, 0.5f, 0.5f);
    public Vector3 endSize = new Vector3(2f, 2f, 2f);

    float interpolation;

    public GameObject[] characters;

    public static Villager SelectedVillager { get; private set; }
    public static void SetSelectedVillager(Villager villager)
    {
        if (SelectedVillager != null)
        {
            SelectedVillager.Selected(true);
        }
        SelectedVillager = villager;
        SelectedVillager.Selected(true);
    }

    public void DropdownHasChangedValue(int value)
    {
        
        dropdown.value = value;
        Debug.Log(dropdown.value);

    }

    public void SliderChangedValue(Single value)
    {
        interpolation = value;
        SelectedVillager.transform.localScale = Vector3.Lerp(startSize, endSize, interpolation);
    }

    private void Update()
    {
        if(SelectedVillager != null)
        {
            currentSelection.text = SelectedVillager.GetType().ToString();
        }
    }
}
