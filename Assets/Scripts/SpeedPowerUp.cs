using UnityEngine;
using System.Collections;

public class SpeedPowerUp : MonoBehaviour
{
    public float speedMultiplier = 2.0f;
    public float speedTime = 10.0f;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Player")
        {
            FirstPersonController player = collider.gameObject.GetComponent<FirstPersonController>();
            if (player && (player.isSpedUp == false))
            {
                player.speedUp(speedMultiplier, speedTime);
                Destroy(gameObject);
            }       
        }
    }
}
