using UnityEngine;
using System.Collections;

public class CameraControllerV2 : MonoBehaviour {

    public Transform target;
    public float smoothing = 5f;

    //store the distance between the camera and player 
    Vector3 offset;

    void Start()
    {
        //vector from camera to player
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {
        //useFixedUpdated to move camera since its following player ( a physics object)
        //need a target position for the camera to try to reach
        Vector3 targetCamPos = target.position + offset;
        //move the camera. lerp moves smoothly between positions
        //ive got my current posiiton and position i wanna be, i wanna try to move a little bit towards that...plus how fast
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
