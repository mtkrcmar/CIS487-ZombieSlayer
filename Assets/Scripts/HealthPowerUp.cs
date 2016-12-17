using UnityEngine;
using System.Collections;

public class HealthPowerUp : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Player")
        {
            FirstPersonController player = collider.gameObject.GetComponent<FirstPersonController>();

            if (player && (player.currentHealth != player.maxHealth))
            {
                player.heal(30);
                Destroy(gameObject);
            }
        }
    }
}