﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
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
    public int exerciseNumber;
    public int plankTime = 0;
    public int pushUps;
    public int situps;
    private Animator animatorController;

    // Start is called before the first frame update
    void Start()
    {
        this.animatorController = GetComponent<Animator>();
    }

    public void startExercise()
    {
        animatorController.SetInteger("SitupsRemaining", situps);
        animatorController.SetInteger("PushUpsRemaining", pushUps);
        animatorController.SetInteger("PlankTimeMultiplier", (plankTime * 4) / 3);
        animatorController.SetInteger("ExcerciseNumber", exerciseNumber);
    }
}