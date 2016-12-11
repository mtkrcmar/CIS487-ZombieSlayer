using UnityEngine;
using System.Collections;
using RAIN.Core;

public class Enemy : MonoBehaviour
{
    public int damageValue = 20;
    public int maxHealth = 100;
    public int currentHealth;

    // Use this for initialization
    void Start()
    {
        currentHealth = maxHealth;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "player")
        {
            FirstPersonController player = collider.gameObject.GetComponent<FirstPersonController>();

            if (player && player.isInvincible == false)
            {
                player.takeDamage(damageValue);
            }
        }
        if (collider.gameObject.tag == "bullet")
        {
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            takeDamage(damageValue);
        }
        if(collider.gameObject.tag == "zombie")
        {
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

    public void takeDamage(int damageValue)
    {
        gameObject.GetComponent<Animation>().Play("gethit01");
        gameObject.GetComponent<Animation>().PlayQueued("walkzombie");
        currentHealth -= damageValue;
        if (currentHealth <= 0)
        {
            gameObject.GetComponent<Collider>().enabled = false;
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            gameObject.GetComponent<Animation>().Play("die01");
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            Destroy(gameObject, 1);
        }
    }
}
