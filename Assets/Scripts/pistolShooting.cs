using UnityEngine;
using System.Collections;

public class pistolShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject bullet;

    public GameObject bulletEmitter;
	public AudioSource handGunFireSound;
    public GameObject pauseMenu;
    float bulletImpulse = 100f;

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (pauseMenu.GetComponent<PauseScript>().paused == false)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Debug.Log("Shoot");
                Camera cam = Camera.main;
                Vector3 shootFrom = bulletEmitter.transform.position;
                shootFrom.y += 1;
                GameObject theBullet = (GameObject)Instantiate(bullet, bulletEmitter.transform.position, bulletEmitter.transform.rotation);
                // GameObject theBullet = (GameObject)Instantiate(bullet, gun.transform.position + gun.transform.forward + (gun.transform.up /5), gun.transform.rotation);         
                theBullet.GetComponent<Rigidbody>().AddForce(cam.transform.forward * bulletImpulse, ForceMode.Impulse);
                handGunFireSound.Play(); // play handgun fire sound
            }
        }
	}
}
