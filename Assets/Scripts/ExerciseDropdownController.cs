using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExerciseDropdownController : MonoBehaviour
{
    public List<GameObject> exercises = new List<GameObject>();
    private GameObject exerciseDropdown;
    private GameObject activeExercise;
    void Start() 
    {
        exerciseDropdown = GameObject.FindWithTag("ExerciseDropdown");
        var dropDown = exerciseDropdown.GetComponentInChildren<TMP_Dropdown>();
        dropDown.onValueChanged.AddListener(onDropDownChanged);
    }

    void onDropDownChanged(int index)
    {
        if (activeExercise != null)
        {
           activeExercise.GetComponent<ExerciseController>().stop();
           Destroy(activeExercise);
           activeExercise = null;
        }
        if (index > 0)
        {
            activeExercise = Instantiate(exercises[index - 1]);
        }
        
    }
}
