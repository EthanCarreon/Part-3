using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;

public class Growing : MonoBehaviour
{
    public GameObject square;
    public GameObject triangle;
    public GameObject circle;
    public TextMeshProUGUI squareTMP;
    public TextMeshProUGUI triangleTMP;
    public TextMeshProUGUI circleTMP;
    public TextMeshProUGUI crTMP;
    public int running;
    Coroutine coroutine;

    void Start()
    {
        StartCoroutine(GrowingShapes());
        StartCoroutine(Circle());
    }

    void Update()
    {
        crTMP.text = "Coroutine: " + running.ToString();
    }

    IEnumerator GrowingShapes()
    {
        running += 1;
        yield return StartCoroutine(Square());
        //yield return new WaitForSeconds(1);
        coroutine = StartCoroutine(Triangle());
        yield return coroutine;
        running -= 1;
    }

    IEnumerator Square()
    {
        running += 1;
        float size = 0; 
        while (size < 5)
        {
            size += Time.deltaTime;
            Vector3 scale = new Vector3(size, size, size);
            square.transform.localScale = scale;
            squareTMP.text = "Square: " + scale;

            yield return null;
        }
        running -= 1;
    }
    IEnumerator Triangle()
    {
        running += 1;
        float size = 0;
        while (size < 5)
        {
            size += Time.deltaTime;
            Vector3 scale = new Vector3(size, size, size);
            triangle.transform.localScale = scale;
            triangleTMP.text = "Triangle: " + scale;

            yield return null;
        }
        running -= 1;
    }
    IEnumerator Circle()
    {
        while (gameObject.activeSelf)
        {
            Coroutine grow = StartCoroutine(GrowCircle());
            yield return grow;
            Coroutine shrink = StartCoroutine(ShrinkCircle());
            yield return shrink;
        }
        
    }

        IEnumerator GrowCircle()
        {
            float size = 0;
            while (size < 5)
            {
                size += Time.deltaTime;
                Vector3 scale = new Vector3(size, size, size);
                circle.transform.localScale = scale;
                circleTMP.text = "Cirlce: " + scale;

                yield return null;
            }
        }

        IEnumerator ShrinkCircle()
        {
        float size = 5;
            while (size > 0)
            {
                size -= Time.deltaTime;
                Vector3 scale = new Vector3(size, size, size);
                circle.transform.localScale = scale;
                circleTMP.text = "Cirlce: " + scale;

                yield return null;
                StartCoroutine(GrowCircle());
            }
        }
        
    
}
