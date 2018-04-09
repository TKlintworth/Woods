using UnityEngine;
using System.Collections;

public class CharController : MonoBehaviour {

    [SerializeField]
    float moveSpeed = 4f;
    

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
        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("HorizontalKey");
        Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("VerticalKey");

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);
        //Debug.Log("heading: " + heading);

        //Check if heading vector is zero, if not, update movement vectors
        //without this check, gives error about zero vector
        if(heading != Vector3.zero)
        {
            transform.forward = heading;
            transform.position += rightMovement;
            transform.position += upMovement;
        }
       
        
       

    }
}
