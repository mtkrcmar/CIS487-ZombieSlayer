using UnityEngine;
using System.Collections;
using RAIN.Core;

public class EnemyWeapon : MonoBehaviour
{
    public int damageValue = 20;
    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    void OnTriggerEnter(Collider collider)
	{
        if (collider.gameObject.name == "Player")
		{
            FirstPersonController player = collider.gameObject.GetComponent<FirstPersonController>();

            if (player && player.isInvincible == false)
            {
                player.takeDamage(damageValue);

            }
        }
    }
}
