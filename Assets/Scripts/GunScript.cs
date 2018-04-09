using UnityEngine;
using System.Collections;

public class GunScript : MonoBehaviour {

    public float damage = 10f;
    public float range = 100f;

    public GameObject player;
    public GameObject impactEffect;
    //public ParticleSystem muzzleFlash;
    

    //public Camera fpsCam;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
	}

    void Shoot()
    {
        //muzzleFlash.Play();
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("camera raycast hit");
            Transform objectHit = hit.transform;
            Debug.Log(objectHit);

            Target target = objectHit.transform.GetComponent<Target>();
            if (target != null)
            {
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
