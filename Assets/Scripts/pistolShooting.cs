using UnityEngine;
using System.Collections;

public class pistolShooting : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bulletEmitter;
    public AudioSource handGunFireSound;
    float bulletImpulse = 100f;

    float recoilSpeed=  0.01f;    // Speed to move camera
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
                gameObject.GetComponent<Recoil>().StartRecoil(0.2f, 10f, 10f);              
                handGunFireSound.enabled = true;
                handGunFireSound.Play(); // play handgun fire 
                

        }
    }

}
