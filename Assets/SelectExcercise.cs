using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SelectExcercise : MonoBehaviour
{
    private GameObject plankButton;
    private GameObject pushupButton;
    private GameObject situpButton;
    private GameObject startTrainingButton;

    //Input
    private GameObject repetitionInput;
    private GameObject durationInput;

    public static float repetitions;
    public static float duration;


    bool plank = false;
    bool pushup = false;
    bool situp = false;

    

    // Start is called before the first frame update
    void Start()
    {
        plankButton = GameObject.FindWithTag("PlankButton");
        pushupButton = GameObject.FindWithTag("PushUpsButton");
        situpButton = GameObject.FindWithTag("SitupsButton");
        startTrainingButton = GameObject.FindWithTag("StartTrainingButton");

        plankButton.GetComponent<Button>().onClick.AddListener(() => plank = !plank);
        pushupButton.GetComponent<Button>().onClick.AddListener(() => pushup = !pushup);
        situpButton.GetComponent<Button>().onClick.AddListener(() => situp = !situp);
        startTrainingButton.GetComponent<Button>().onClick.AddListener(launchTraining);

        //UserInput
        repetitionInput = GameObject.FindWithTag("RepetitionInput");
        durationInput = GameObject.FindGameObjectWithTag("DurationInput");

    }

    // Update is called once per frame void Update()
    void Update()
    {
        //getting update from keyboard

        
    }


    void launchTraining()
    {
        if ((plank || pushup || situp == true ) && correctUserInput() )

        {
            
            //Debug.Log("Done");
            //string log = durationInput.GetComponent<InputField>().text;

            //Debug.Log(log);
            //log = repetitionInput.GetComponent<InputField>().text;
            //Debug.Log(log.ToString());
            SceneManager.LoadScene("Barnabas");

        }

    }



    bool correctUserInput()
    {

        bool result = true;

        try
        {
            float.TryParse(repetitionInput.GetComponent<InputField>().text, out repetitions);
            float.TryParse(durationInput.GetComponentInChildren<InputField>().text, out duration);

            Debug.Log(repetitions);
            Debug.Log(duration);
        }
        catch (FormatException)
        {
            Console.WriteLine($"Unable to parse");
            result = false;
        }
        return result;
    }
   

}
