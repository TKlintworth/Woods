using UnityEngine;
using System.Collections;

public class burnCalories : MonoBehaviour {

    public float playerHealth = 1000.0f;
    public float maxCalories = 2000.0f;
    public static float currentCalories;
    public static float fatCalories;
    public float calorieBurnRate;
    //public bool isMoving = false;
    //public bool isSedentary = false;
    //public bool isActive = false;
    //public bool isStrenuous = false;

    public GameObject player;
    

	// Use this for initialization
	void Start () {
        fatCalories = 0;
        currentCalories = maxCalories;

        //continuously update calories
        
        StartCoroutine("calorieConsumption");
    }

/*
 * //TODO
 *  
    modCaloriesBurn - Checks current level of activity and switches calorieBurnRate based on what it finds 
*/
    public void modCalorieBurn()
    {
        if (Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.A))
        {
            calorieBurnRate = 2;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                calorieBurnRate = 3;
            }
        }
        
        else
        {
            calorieBurnRate = 1;
        }
    }

    /*Repeats every 1 second. 
      As long as the player has calories left (currentCalories >0), the calorieBurnRate is subtracted from currentCalories once per second
      If no calories left, calorieBurnRate is subtracted from health until health hits zero, then destroying player and setting to null to remove references
    */
    IEnumerator calorieConsumption()
    {
        while (true)
        {
            //if you have 2000 calories or more and youre consuming calories (since youre in the calorieConsumption coroutine)
            //add excess calories to fatCalories
            //and while you still have fatCalories
            //then suspend this coroutine while we start the fat consumption co routine
            if (currentCalories >= 2000)
            {
                float excess = currentCalories - 2000;
                currentCalories -= excess;
                fatCalories += excess;
                while (fatCalories > 0)
                {
                    Debug.Log("fat calories in loop: " + fatCalories);
                    InvokeRepeating("fatCalorieConsumption", 1.0f,1.0f);
                    yield return new WaitForSeconds(1.0f);
                    yield return StartCoroutine(fatCalorieConsumption());
                    Debug.Log("calorieConsumption running again");
                }
            }
           
            if (currentCalories >= 2000)
            {
                float excess = currentCalories - 2000;
                currentCalories -= excess;
                fatCalories += excess;
                Debug.Log("Fat Calories: " + fatCalories);
                
            }
            if (currentCalories != 0)
            {
                InvokeRepeating("calorieConsumption", 1.0f, 1.0f);
                currentCalories = currentCalories - calorieBurnRate;
                //Debug.Log("Current Calories: " + currentCalories);
            }
            //if current calories at 0, subtract from health pool
            if (currentCalories <= 0)
            {
                //if player has health, subtract calories burned from health
                if (playerHealth > 0)
                {
                    InvokeRepeating("calorieConsumption", 1.0f, 1.0f);
                    playerHealth = playerHealth - calorieBurnRate;
                    Debug.Log("Current Calories: " + currentCalories);
                    //player health is 0, kill player
                    if (playerHealth <= 0)
                    {
                        playerHealth = 0;
                        Debug.Log("You starved to death!");
                        Destroy(player);
                        player = null;
                    }
                }
            }
            yield return new WaitForSeconds(1.0f);
        }
    }

    IEnumerator fatCalorieConsumption()
    {
        Debug.Log("fat enumerator created");
        while (true)
        {
            if (fatCalories != 0)
            {
                fatCalories = fatCalories - calorieBurnRate;
                InvokeRepeating("fatCalorieConsumption",1.0f,1.0f);
            }
            if (fatCalories <= 0)
            {
                Debug.Log("Fat calories = 0");
                yield return StartCoroutine(calorieConsumption());
            }
            yield return new WaitForSeconds(1.0f);
        }
    }

   
        

    // Update is called once per frame
    void Update()
    {
        modCalorieBurn();
    }

    

}
