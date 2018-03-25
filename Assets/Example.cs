using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Example : MonoBehaviour
    {
        GameObject[] spawnPoints;
        GameObject currentPoint;
        int index;
    private Renderer rend;
    private bool choose = false;
  float r = 0;
    float g = 0;
    float b = 0;
    float a = 0;



    void Start()
        {
        rend = GetComponent<Renderer>();
        spawnPoints = GameObject.FindGameObjectsWithTag("porte");
            index = Random.Range(0, spawnPoints.Length);
            currentPoint = spawnPoints[index];
        currentPoint.tag = "Player";
        r = currentPoint.GetComponent<Renderer>().material.color.r;
        g = currentPoint.GetComponent<Renderer>().material.color.g;
        b = currentPoint.GetComponent<Renderer>().material.color.b;
        a = currentPoint.GetComponent<Renderer>().material.color.a;
        Debug.Log(r);
        currentPoint.GetComponent<Renderer>().material.color = Color.green;
        }

    private void Update()
    {
        if (choose == true)
        {
            rend = GetComponent<Renderer>();
            spawnPoints = GameObject.FindGameObjectsWithTag("porte");
            index = Random.Range(0, spawnPoints.Length);
            currentPoint = spawnPoints[index];
            currentPoint.tag = "Player";
            r = currentPoint.GetComponent<Renderer>().material.color.r;
            g = currentPoint.GetComponent<Renderer>().material.color.g;
            b = currentPoint.GetComponent<Renderer>().material.color.b;
            a = currentPoint.GetComponent<Renderer>().material.color.a;
            currentPoint.GetComponent<Renderer>().material.color = Color.green;
            choose = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("goal");
            currentPoint.GetComponent<Renderer>().material.color = new Color32((byte)((int)(r * 255)), (byte)((int)(g * 255)), (byte)((int)(b * 255)), (byte)((int)a * 255));
            currentPoint.tag = "porte";
            choose = true;

        }
    }
}

