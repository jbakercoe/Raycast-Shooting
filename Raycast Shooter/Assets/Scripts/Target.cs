using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {

    public float health = 50f;

    [SerializeField] GameObject crackedObject;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if(health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(crackedObject, transform.position, transform.rotation);
        Destroy(gameObject);
    }
    

}
