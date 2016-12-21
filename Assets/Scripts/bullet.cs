using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour
{
    public int damageValue = 20;

    // Use this for initializationaa
    void Start ()
    {
        Destroy(gameObject, 5);
    }

    void OnCollisionEnter()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name ==  "ZombieCartoon")
        {
            Enemy enemy = collider.gameObject.GetComponent<Enemy>();
            if (enemy)
            {
                enemy.takeDamage(damageValue);
                Destroy(gameObject);
            }
        }
    }
}
