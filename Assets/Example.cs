using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Example : MonoBehaviour
    {
        private RotationModule _rotationModule;
        GameObject[] spawnPoints;
        GameObject currentPoint;
        int index;
        private Renderer rend;
        private bool choose = false;
        float r = 0;
        float g = 0;
        float b = 0;
        float a = 0;
        public static int lesPoints = 0;

        public List<PostTeleportationTarget> Targets;

        void Start()
        {
            _rotationModule = GameObject.FindGameObjectWithTag("Building").GetComponent<RotationModule>();
            spawnPoints = GameObject.FindGameObjectsWithTag("porte");
            choose = true;
        }

        private void Update()
        {
            if (choose == true)
            {
                if(currentPoint != null) 
                    currentPoint.GetComponentInParent<door>().IsObjective = false;
                rend = GetComponent<Renderer>();
                index = Random.Range(0, spawnPoints.Length);
                currentPoint = spawnPoints[index];
                currentPoint.tag = "Goal";
                currentPoint.GetComponentInParent<door>().IsObjective = true;
                r = currentPoint.GetComponent<Renderer>().material.color.r;
                g = currentPoint.GetComponent<Renderer>().material.color.g;
                b = currentPoint.GetComponent<Renderer>().material.color.b;
                a = currentPoint.GetComponent<Renderer>().material.color.a;
                currentPoint.GetComponent<Renderer>().material.color = Color.green;
                choose = false;
                var target = Targets.FirstOrDefault(t => t.IsPositionInside(currentPoint.GetComponent<Transform>().position));
                if (target != null) _rotationModule.RubberBandToRotation(target.PlaneRotation);
            }

        if (lesPoints == 5)
        {
            SceneManager.LoadScene("Wins");
        }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.tag == "Goal")
            {
                if (Input.GetKeyDown("w"))
                {
                    FindObjectOfType<audioclipmanager>().Play("madame");
                    Debug.Log("goal");
                    currentPoint.GetComponent<Renderer>().material.color = new Color32((byte)((int)(r * 255)), (byte)((int)(g * 255)), (byte)((int)(b * 255)), (byte)((int)a * 255));
                    currentPoint.tag = "porte";
                    lesPoints++;
                    choose = true;
                }

            }
        }
}

