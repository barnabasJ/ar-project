using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ExerciseDropdownController : MonoBehaviour
{
    public List<GameObject> exercises = new List<GameObject>();
    // Start is called before the first frame update
    private GameObject exerciseDropdown;
    private GameObject activeExercise;
    void Start() 
    {
        exerciseDropdown = GameObject.FindWithTag("ExerciseDropdown");
        var dropDown = exerciseDropdown.GetComponentInChildren<TMP_Dropdown>();
        dropDown.onValueChanged.AddListener(onDropDownChanged);
        Debug.Log("hello");
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
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
