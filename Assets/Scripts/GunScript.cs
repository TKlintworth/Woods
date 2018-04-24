using UnityEngine;
using System.Collections;

public class GunScript : MonoBehaviour {

    public float damage = 10f;
    public float range = 100f;

    //public GameObject player;
    public GameObject impactEffect;
    //public ParticleSystem muzzleFlash;
    

    //public Camera fpsCam;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //Debug.Log("Inside getbuttondown");
            Shoot();
            /*
            Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
            Debug.DrawRay(transform.position, forward, Color.green, 2.0f);
            */
        }
	}

    void Shoot()
    {
        //Debug.Log("Inside Shoot");
        //muzzleFlash.Play();
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            //Debug.Log("ray origin: " + ray.origin + " ray direction: " + ray.direction);
            //Debug.Log("camera raycast hit");
            Transform objectHit = hit.transform;
            Debug.Log(objectHit);

            Target target = objectHit.transform.GetComponent<Target>();
            if (target != null)
            {
                //Debug.Log("Damage applied: " + damage);
                target.TakeDamage(damage);
            }
            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal)) as GameObject;
            Destroy(impactGO, 2f);
        }
        /*if (Physics.Raycast(player.transform.position, player.transform.forward, out hit))
        {
            //Debug.DrawRay(player.transform.position, player.transform.forward, Color.red, 5.0f);
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
        */
    }
}
