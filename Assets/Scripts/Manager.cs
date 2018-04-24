using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Manager : MonoBehaviour {


    public static float calories;
    float currentFatCalories;
    //public static float fatCalories;
    Text text;
    

    // Use this for initialization
    public void Awake()
    {
        text = GetComponent<Text>();
        
        //Debug.Log("Onscreen Calories: " + calories);
        
    }

	
	// Update is called once per frame
	void Update ()
    {
        calories = burnCalories.currentCalories;
        currentFatCalories = burnCalories.fatCalories;
        if (text.name == "FatText")
        {
            //Debug.Log("Manager fat calories: " + currentFatCalories);
            if (currentFatCalories <= 0)
            {
                text.text = "edgecase Faaaaat Calories: 0";
            }
            else
            {
                text.text = "Faaaaat Calories: " + currentFatCalories;
            }
            
        }
        if (text.name == "CalorieText")
        {
            text.text = "Calories: " + calories;
        }
	}
}
