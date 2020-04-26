using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEditor;

public enum Exercise
{
    Plank = 1,
    PushUp = 2
}

public class AnimationControllerScript : MonoBehaviour
{
    private Animator animatorController;

    // Start is called before the first frame update
    void Start()
    {
        this.animatorController = GetComponent<Animator>();
    }

    void setExercise(Exercise exercise)
    {
        switch(exercise)
        {
            case Exercise.Plank:
                this.animatorController.SetInteger("ExcerciseNumber", 1);
                break;
            case Exercise.PushUp:
                this.animatorController.SetInteger("ExcerciseNumber", 2);
                break;
        }
    }

    //Accepts duration in seconds, no less than 30 seconds
    void setPlankDuration(int duration)
    {
        this.animatorController.SetInteger("PlankTimeMultiplier", (duration * 4) / 3);
    }

    void setPushUpNumber(int number)
    {
        this.animatorController.SetInteger("PushUpsRemaining", number);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
