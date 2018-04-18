using UnityEngine;
using System.Collections;

public class EatFood : MonoBehaviour {

    public GameObject donut;
    public int donutCalories = 180;


    void Awake()
    {
        //donut = GetComponent<GameObject>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Add " + donutCalories + " calories");
            //if (burnCalories.currentCalories >= 2000)
            //{
                //send any calories gained that pushes currentCalories above 2000 to fat reserves
            //    float excess = burnCalories.currentCalories - 2000;
                //reset calories to 2000 because we dont want to show over 2000 calories
            //    burnCalories.currentCalories -= excess;
            //}
            burnCalories.currentCalories += donutCalories;
            donut.SetActive(false);
        }

    }
}
