using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Building : MonoBehaviour
{
    public SpriteRenderer[] buildings;

    public float interpolation = 5f;
    void Start()
    {
        StartCoroutine(ScaleBuildings());
    }

    IEnumerator ScaleBuildings()
    {

        for (int i = 0; i < buildings.Length; i++)
        {
            buildings[i].gameObject.SetActive(true);

            float time = 0;
            float speed = 1f;

            Vector3 startSize = buildings[i].transform.localScale;
            Vector3 endSize = startSize * 2;

            while (time < 1)
            {
                buildings[i].transform.localScale = Vector3.Lerp(startSize, endSize, (time / 2));

                time += Time.deltaTime * speed;
                yield return null;
            }
            buildings[i].transform.localScale = endSize;

            yield return new WaitForSeconds(1f);     
        }

    }

}
