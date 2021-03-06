﻿using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExerciseController : MonoBehaviour
{
    public GameObject trainerModel;
    [SerializeField] private int repetitions;
    [SerializeField] private float duration;
    [SerializeField] private float durationToExerciseModificator;

    private GameObject trainerModelObject;
    private GameObject repetionButtonObject;
    private GameObject durationButtonObject;
    private GameObject startButtonObject;
    private GameObject stopButtonObject;
    private GameObject spawnerObject;
    private GameObject repetitionCircleObject;
    private GameObject durationCircleObject;

    private TrainerSpawner spawner;
    private bool started = false;
    private bool finished = false;
    private float currentDuration = 0.0f;
    private int currentRepetion = 0;
    private bool trainerPlaced = false;
    private bool trainerPlacedLastUpdate = false;

    void Start()
    {
        Debug.Log("Start Exercise: " + gameObject);
        // get other objects
        repetionButtonObject = GameObject.FindWithTag("RepetitionButton");
        durationButtonObject = GameObject.FindWithTag("DurationButton");
        startButtonObject = GameObject.FindWithTag("StartButton");
        stopButtonObject = GameObject.FindWithTag("StopButton");
        spawnerObject = GameObject.FindWithTag("Spawner");

        //UI animations
        repetitionCircleObject = GameObject.FindWithTag("RepetitionCircle");
        durationCircleObject = GameObject.FindWithTag("DurationCircle");

        spawner = spawnerObject.GetComponent<TrainerSpawner>();
        spawner.exercise = gameObject;
        spawner.onSpawn(obj =>
        {
            spawnerObject.SetActive(false);
            trainerPlaced = true;
            trainerModelObject = obj;
        });

        // setup buttons 
        stopButtonObject.SetActive(false);
        startButtonObject.SetActive(false);
        startButtonObject.GetComponent<Button>().onClick.AddListener(toggleStart);
        stopButtonObject.GetComponent<Button>().onClick.AddListener(stop);
    }

    // Update is called once per frame
    void Update()
    {
        updateInfoButtons();
        updateStatus();
    }

    void updateStatus()
    {
        if (started && !finished)
        {
            currentDuration += Time.deltaTime;
            if (currentDuration >= duration)
            {
                currentDuration = 0;
                currentRepetion += 1;
                started = false;

                if (currentRepetion >= repetitions)
                {
                    finished = true;
                }
            }
        }
    }

    void updateInfoButtons()
    {

        var durAnimation = durationCircleObject.GetComponent<Image>();
        durAnimation.fillAmount = (float)currentDuration /(float)duration;

        var repAnimation = repetitionCircleObject.GetComponent<Image>();
        repAnimation.fillAmount = (float) currentRepetion / (float)repetitions;

        Debug.Log((float)currentRepetion / (float)repetitions);


        var repText = repetionButtonObject.GetComponentInChildren<TextMeshProUGUI>();
        repText.text = $"{currentRepetion}/{repetitions}";

        var durText = durationButtonObject.GetComponentInChildren<TextMeshProUGUI>();
        durText.text = $"{Mathf.Round(duration - currentDuration)}";

        if (trainerPlaced && !trainerPlacedLastUpdate)
            startButtonObject.SetActive(true);
        else
            startButtonObject.SetActive(!started);
        trainerPlacedLastUpdate = trainerPlaced;

        //var startPause = startButtonObject.GetComponentInChildren<TextMeshProUGUI>();
        //startText.text = started ? "Pause" : "Start";
    }

    void toggleStart()
    {
        if (!finished && trainerPlaced)
            started = !started;

        if (started)
        {
            trainerModelObject
                .GetComponentInChildren<AnimationControllerScript>()
                .startExercise((int)(duration / durationToExerciseModificator));
        }
    }

    public void stop()
    {
        Debug.Log("Destroy Exercise");
        trainerPlaced = false;
        stopButtonObject.SetActive(true);
        startButtonObject.SetActive(true);
        spawnerObject.SetActive(true);
        Destroy(trainerModelObject, 1f);
        Debug.Log("Exercise destroyed");
    }
}