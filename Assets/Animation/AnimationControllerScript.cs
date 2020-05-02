using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControllerScript : MonoBehaviour
{
    public int exerciseParameter = 0;
    private Animator animatorController;

    // Start is called before the first frame update
    void Start()
    {
        this.animatorController = GetComponent<Animator>();
    }

    public void startExercise()
    {
        animatorController.SetInteger("ExerciseParameter", exerciseParameter);
        animatorController.SetTrigger("StartExercise");
    }
}
