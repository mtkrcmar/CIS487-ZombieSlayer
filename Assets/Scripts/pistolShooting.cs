using UnityEngine;
using System.Collections;

public class pistolShooting : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bulletEmitter;
    public AudioSource handGunFireSound;
    float bulletImpulse = 100f;
    

    void Start ()
    {

    }

    // Update is called once per frame
    void Update ()
    {
            if (Input.GetButtonDown("Fire1"))
            {
                GameObject theBullet = (GameObject)Instantiate(bullet, bulletEmitter.transform.position, bulletEmitter.transform.rotation);
                theBullet.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * bulletImpulse, ForceMode.Impulse);
                handGunFireSound.Play(); // play handgun fire sound
            }
    }
}
