using UnityEngine;
using System.Collections;

public class CharController : MonoBehaviour {

    [SerializeField]
    public float moveSpeed = 4f;

   
 
    public GameObject player;
    

    Vector3 forward, right;

	// Use this for initialization
	void Start ()
    {
        

        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        Debug.Log("Forward: " + forward);
   
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
        Debug.Log("right: " + right);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (forward != Vector3.zero)
        {
            if (Input.anyKey)
            {
                Move();
            }
        }
       
	}

    void Move()
    {
        //let burnCalories know that we're moving now
        //player.GetComponent<burnCalories>().isMoving = true;
        //Left Shift send to Sprint to hopefully increase speed
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Sprint();
            player.GetComponent<burnCalories>().modCalorieBurn();
        }
        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("HorizontalKey");
        Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("VerticalKey");

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

        Debug.Log("heading: " + heading);
        Debug.Log("Right movement: " + rightMovement);
        Debug.Log("up movement: " + upMovement);
        //Check if heading vector is zero, if not, update movement vectors
        //without this check, gives error about zero vector
        if(heading != Vector3.zero)
        {
            transform.forward = heading;
            transform.position += rightMovement;
            transform.position += upMovement;
        }
    }

    //Speed double while holding Left Shift
    void Sprint()
    {
        moveSpeed = 8f;
        
        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("HorizontalKey");
        Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("VerticalKey");

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

        Debug.Log("SPRINT: heading: " + heading);
        Debug.Log("SPRINT: Right movement: " + rightMovement);
        Debug.Log("SPRINT: up movement: " + upMovement);

        if (heading != Vector3.zero)
        {
            transform.forward = heading;
            transform.position += rightMovement;
            transform.position += upMovement;
        }
    }

}
