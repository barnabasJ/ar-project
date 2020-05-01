using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Animations;
using UnityEngine;
using UnityEditor;

public enum Exercise
{
    Plank = 1,
    PushUp = 2,
    Situp = 3
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
            case Exercise.Situp:
                this.animatorController.SetInteger("ExcerciseNumber", 3);
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

    void setSitupNumber(int number)
    {
        this.animatorController.SetInteger("SitupsRemaining", number);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
