using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExerciseController : MonoBehaviour
{


    public GameObject trainerModel;
    private float repetitions = SelectExcercise.repetitions;
    private float duration = SelectExcercise.duration;
    [SerializeField] [Range(0, 1f)] float progress;

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

    void Start()
    {
        // get other objects
        repetionButtonObject = GameObject.FindWithTag("RepetitionButton");
        durationButtonObject = GameObject.FindWithTag("DurationButton");
        startButtonObject = GameObject.FindWithTag("StartButton");
        stopButtonObject = GameObject.FindWithTag("StopButton");
        spawnerObject = GameObject.FindWithTag("Spawner");

        //UI animations
        repetitionCircleObject = GameObject.FindWithTag("RepetitionCircle");
        durationCircleObject = GameObject.FindWithTag("DurationCircle");



        spawnerObject.SetActive(true);
        spawner = spawnerObject.GetComponent<TrainerSpawner>();
        spawner.exercise = gameObject;
        spawner.onSpawn(obj =>
        {
            spawnerObject.SetActive(false);
            trainerPlaced = true;
        });

        // setup buttons 
        stopButtonObject.SetActive(false);
        //trial
        startButtonObject.SetActive(false);
        startButtonObject.GetComponent<Button>().onClick.AddListener(toggleStart);
    }

    // Update is called once per frame
    void Update()
    {


        updateInfoButtons();
        updateStatus();
        Debug.Log(repetitions);

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
        //Ui COMPONENTS



        var durAnimation = durationCircleObject.GetComponent<Image>();
        durAnimation.fillAmount = duration;

        var repAnimation = repetitionCircleObject.GetComponent<Image>();
        repAnimation.fillAmount = repetitions;




        var repText = repetionButtonObject.GetComponentInChildren<TextMeshProUGUI>();
        repText.text = $"{currentRepetion}/{repetitions}";

        var durText = durationButtonObject.GetComponentInChildren<TextMeshProUGUI>();
        durText.text = $"{Mathf.Round(duration - currentDuration)}";

        if (trainerPlaced && !startButtonObject.activeInHierarchy)
            startButtonObject.SetActive(true);
        else if (!trainerPlaced && startButtonObject.activeInHierarchy)
            startButtonObject.SetActive(false);

        var startText = startButtonObject.GetComponentInChildren<TextMeshProUGUI>();
        startText.text = started ? "Pause" : "Start";
    }

    void toggleStart()
    {
        if (!finished && trainerPlaced)
            started = !started;
    }
}