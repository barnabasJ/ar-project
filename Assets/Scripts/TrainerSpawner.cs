using System;
using UnityEngine;

public class TrainerSpawner : MonoBehaviour
{
    public GameObject exercise;
    private PlacementIndicator placementIndicator;
    private Action<GameObject> onSpawnAction;

    private void Start()
    {
        placementIndicator = FindObjectOfType<PlacementIndicator>();
    }

    private void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            var trainerModel = exercise.GetComponent<ExerciseController>().trainerModel;
            var obj = Instantiate(trainerModel, placementIndicator.transform.position,
                placementIndicator.transform.rotation);
            onSpawnAction(obj);
        }
    }

    public void onSpawn(Action<GameObject> action)
    {
        onSpawnAction = action;
    }
}