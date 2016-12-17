using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class FirstPersonController : MonoBehaviour
{
    //guns
    public GameObject pistol;
    public GameObject machineGun;
    // helth
    public int maxHealth = 100;
    public int currentHealth;

    //movement
    public float movementSpeed = 10.0f;
    public float mouseSensitivity = 4.0f;
    float verticalRotation = 0;
    float vertVelocity = 0;
    public float upDownRange = 60.0f;
    public float jumpSpeed = 5;


    public float invincibilityTime = 1.0f;

    public AudioSource walkingSound;

    // gun control
    public List<string> weapons = new List<string>();
    public GameObject gun;
    public GameObject gunPlacement;
    public GameObject pauseMenu;
	public GameObject damagePlane;
    bool gunpickup = false;
    public bool isSpedUp = false;
    public bool isInvincible = false;
    
    CharacterController cc;

    public Text healthDisplay;

    // Use this for initialization
    void Start ()
    {
        Cursor.visible = false;
        cc = GetComponent<CharacterController>();
        currentHealth = maxHealth;
        setHealthDisplay();
      
        addWeapon("pistol");

        gun = (GameObject)Instantiate(pistol, gunPlacement.transform.position, gunPlacement.transform.rotation);
        gun.transform.parent = Camera.main.transform;

    }
    
    // Update is called once per frame
    void Update ()
	{
        //Rotation
        if (pauseMenu.GetComponent<PauseScript>().paused == false)
        {
            float rotLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity;
            transform.Rotate(0, rotLeftRight, 0);

            float rotUpDown = Input.GetAxis("Mouse Y") * mouseSensitivity;

            verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
            verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
            Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
        }
        //Movement
        float forwardSpeed = Input.GetAxis ("Vertical") * movementSpeed;
        float sideSpeed = Input.GetAxis ("Horizontal") * movementSpeed;

        //if any movement acitivate walking sound
        if (forwardSpeed != 0||sideSpeed!=0)
        {
            if (!walkingSound.isPlaying)
            {
                if (cc.isGrounded)
                {                  
                    walkingSound.Play();
                }
            }
        }
        //if no movement deacitivate walking sound
        if (forwardSpeed == 0 && sideSpeed == 0) {
            if (walkingSound.isPlaying) {
                walkingSound.Stop ();
            }
        }


        //set velocity to constant acceleration
        vertVelocity += Physics.gravity.y * Time.deltaTime;
        
        //jump
        if(Input.GetButtonDown("Jump") && cc.isGrounded)
        {
            vertVelocity = jumpSpeed;
            walkingSound.Stop();
        }

        //set speed
        Vector3 speed = new Vector3(sideSpeed, vertVelocity, forwardSpeed);
       
        //apply rotation speed
        speed = transform.rotation * speed;

        //move character
        cc.Move(speed * Time.deltaTime);

        //change weapon
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log(getWeapons().Contains("MachineGun"));
            if (getWeapons().Contains("MachineGun"))
            {
                Destroy(gun);
                gun = (GameObject)Instantiate(machineGun, gunPlacement.transform.position, gunPlacement.transform.rotation);
                gun.transform.parent = Camera.main.transform;

            }
        }
    }
     
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "machinegun")
        {
            Debug.Log("gun Collision");
            addWeapon("MachineGun");
            Destroy(hit.gameObject);
            
           // GameObject machinegun = (GameObject)Instantiate(gun, gunPlacement.transform.position, gunPlacement.transform.rotation);
        }
        else if(hit.gameObject.tag == "zombieWeapon")
        {
            Debug.Log("Weapon Collision");
            takeDamage(20);
        }
    }
    
    public void setHealthDisplay()
    {
        healthDisplay.text = "Health: " + currentHealth.ToString() + " / " + maxHealth.ToString();
    }

    public void speedUp(float speedMultiplier, float speedTime)
    {
        movementSpeed *= speedMultiplier;
        isSpedUp = true;
        stopSpeedBoost(speedTime);
    }

    public void stopSpeedBoost(float speedTime)
    {
        StartCoroutine(resetSpeed(speedTime));
    }

    IEnumerator resetSpeed(float speedTime)
    {
        yield return new WaitForSeconds(speedTime);
        movementSpeed = 10.0f;
        isSpedUp = false;
    }

    public void heal(int healValue)
    {
        if (currentHealth + healValue <= 100)
        {
            currentHealth += healValue;
        }
        else
        {
            currentHealth = 100;
        }
        setHealthDisplay();
    }

    public void takeDamage(int damageValue)
    {
        currentHealth -= damageValue;
        isInvincible = true;
        setHealthDisplay();
		StartCoroutine(damageScreen());

        StartCoroutine(endInvincibility());
        if (currentHealth <= 0)
        {
			ZombieKillCount.zombieKillCount = 0;
            currentHealth = 0;
            setHealthDisplay();
            pauseMenu.GetComponent<PauseScript>().Reload();
        }
    }

	IEnumerator damageScreen()
	{
		damagePlane.SetActive (true);
		yield return new WaitForSeconds(0.1f);
		damagePlane.SetActive (false);
	}

    IEnumerator endInvincibility()
    {
        yield return new WaitForSeconds(invincibilityTime);
        isInvincible = false;
    }

    //Handle player weapons
    void addWeapon(string weapon)
    {
        Debug.Log("Added weapon!");
        weapons.Add(weapon);
        foreach(string a in weapons)
        {
            Debug.Log(a);
        }
    }
    List<string> getWeapons()
    {
        return weapons;
    }
}
