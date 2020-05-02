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

    // mapę
    public static Dictionary<string, bool> excercises = new Dictionary<string, bool>()
    {

        ["plank"] = false,
        ["pushups"] = false,
        ["situps"] = false
        
   };

    public static bool  plank = false;
    public static bool pushup = false;
    public static bool situp = false;

    

    // Start is called before the first frame update
    void Start()
    {
        plankButton = GameObject.FindWithTag("PlankButton");
        pushupButton = GameObject.FindWithTag("PushUpsButton");
        situpButton = GameObject.FindWithTag("SitupsButton");
        startTrainingButton = GameObject.FindWithTag("StartTrainingButton");

        plankButton.GetComponent<Button>().onClick.AddListener(() => excercises["plank"] = !excercises["plank"]);
        pushupButton.GetComponent<Button>().onClick.AddListener(() => excercises["pushups"] = !excercises["pushups"]);
        situpButton.GetComponent<Button>().onClick.AddListener(() => excercises["situps"] = !excercises["situps"]);

        //lISTENER THAT RULES START THE TRAINING 
        startTrainingButton.GetComponent<Button>().onClick.AddListener(launchTraining);

        //UserInput
        repetitionInput = GameObject.FindWithTag("RepetitionInput");
        durationInput = GameObject.FindGameObjectWithTag("DurationInput");

        plankButton.GetComponent<Image>().color = Color.yellow;
        pushupButton.GetComponent<Image>().color = Color.yellow;
        situpButton.GetComponent<Image>().color = Color.yellow;


    }

    // Update is called once per frame void Update()
    void Update()
    {        
    }


    void launchTraining()
    {
      
            if(correctUserInput() && atLeastOneInDicWasSelected())
            SceneManager.LoadScene("Barnabas");
    }



    bool correctUserInput()
    {

        bool result = true;

        float testRep;
        float testDur;

        if (
            float.TryParse(repetitionInput.GetComponent<InputField>().text, out testRep) &&
            float.TryParse(durationInput.GetComponentInChildren<InputField>().text, out testDur) &&
            (testRep) > 0 && (testDur > 0)

           )
        {

            repetitions = testRep;
            duration = testDur;

            Debug.Log(repetitions);
            Debug.Log(duration);

            return true;
        }

        else return false;
    }

        bool atLeastOneInDicWasSelected()
        {
            
            foreach (var ex in excercises)
                {
                    if (ex.Value == true)
                    {
                     return true;
                    }
                }
            return false;
            
        
        }
    }


