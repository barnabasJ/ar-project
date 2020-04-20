using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    private PlacementIndicator placementIndicator;

    private void Start()
    {
        placementIndicator = FindObjectOfType<PlacementIndicator>();
    }

    private void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            var obj = Instantiate(objectToSpawn, placementIndicator.transform.position,
                placementIndicator.transform.rotation);
        }
    }
}