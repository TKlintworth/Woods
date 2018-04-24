using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharController : MonoBehaviour {

    [SerializeField]
    public float moveSpeed = 4f;

    public GameObject player;
    
    Vector3 forward, right;

    int floorMask;
    Rigidbody playerRigidbody;
    float camRayLength = 1000f;
<<<<<<< HEAD
    bool inFireMode = false;
    float speed;
=======
>>>>>>> 5884b73da0cd4f0982500abe8ce8b10967035504

    void Awake()
    {   
        playerRigidbody = GetComponent<Rigidbody>();
        floorMask = LayerMask.GetMask("Floor");
    }

    void FixedUpdate()
    {
<<<<<<< HEAD
        //only enable aim to cursor if pressed F
        if (inFireMode)
        {
            Turning();
        }
        
=======
        Turning();
>>>>>>> 5884b73da0cd4f0982500abe8ce8b10967035504
    }

    // Use this for initialization
    void Start ()
    {
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        //Debug.Log("Forward: " + forward);
   
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
        //Debug.Log("right: " + right);
	}
	
	// Update is called once per frame
	void Update ()
    {
<<<<<<< HEAD
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!inFireMode)
            {
                inFireMode = true;
            }
            else
            {
                inFireMode = false;
            }
            
        }
=======
>>>>>>> 5884b73da0cd4f0982500abe8ce8b10967035504
        //Turning();
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
<<<<<<< HEAD
        
        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

        if (rightMovement.magnitude > 1 || upMovement.magnitude > 1)
        {
            rightMovement.Normalize();
            upMovement.Normalize();
        }
=======

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

        //Debug.Log("heading: " + heading);
        //Debug.Log("Right movement: " + rightMovement);
        //Debug.Log("up movement: " + upMovement);
>>>>>>> 5884b73da0cd4f0982500abe8ce8b10967035504

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

<<<<<<< HEAD
        // Debug.Log("SPRINT: heading: " + heading);
        // Debug.Log("SPRINT: Right movement: " + rightMovement);
        // Debug.Log("SPRINT: up movement: " + upMovement);

        //rightMovement = Vector3.Normalize(rightMovement);
        //upMovement = Vector3.Normalize(upMovement);


        
=======
        //Debug.Log("SPRINT: heading: " + heading);
        //Debug.Log("SPRINT: Right movement: " + rightMovement);
        //Debug.Log("SPRINT: up movement: " + upMovement);

>>>>>>> 5884b73da0cd4f0982500abe8ce8b10967035504
        if (heading != Vector3.zero)
        {
            transform.forward = heading;
            transform.position += rightMovement;
            transform.position += upMovement;
        }
    }

    void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit floorHit;
        //Debug.Log("In Turning outside IF");

        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;

            playerToMouse.y = 0;

            //Debug.Log("In Turning inside IF... playerToMouse:" + playerToMouse);

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            playerRigidbody.MoveRotation(newRotation);
        }
    }

}
