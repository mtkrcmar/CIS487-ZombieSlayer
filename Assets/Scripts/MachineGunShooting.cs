using UnityEngine;
using System.Collections;

public class MachineGunShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject bullet;

    public GameObject bulletEmitter;
    public AudioSource MachineGunFireSound;
    public GameObject pauseMenu;
    float bulletImpulse = 100f;
    float timer = .15f;
    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer -= Time.deltaTime;
        if (pauseMenu.GetComponent<PauseScript>().paused == false)
        {
            if (Input.GetButton("Fire1"))
            {
                if (timer <= 0)
                {
                    Debug.Log("Shoot");
                    Camera cam = Camera.main;
                    Vector3 shootFrom = bulletEmitter.transform.position;
                    shootFrom.y += 1;
                    GameObject theBullet = (GameObject)Instantiate(bullet, bulletEmitter.transform.position, bulletEmitter.transform.rotation);
                    timer = .15f;
                    // GameObject theBullet = (GameObject)Instantiate(bullet, gun.transform.position + gun.transform.forward + (gun.transform.up /5), gun.transform.rotation);         
                    theBullet.GetComponent<Rigidbody>().AddForce(cam.transform.forward * bulletImpulse, ForceMode.Impulse);
                    Camera.main.GetComponent<CameraShake>().shakeDuration = .05f;
                    //MachineGunFireSound.Play(); 

                    Debug.Log(timer);
                }
            }
        }
    }
}

