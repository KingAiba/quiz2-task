using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float damage = 50;
    public float speed = 25;
    public float forcePush = 10;

    public float ttl = 8;

    Rigidbody projectileRB;

    public ParticleSystem projectileEffect;
   
    void Start()
    {
        // Get Projectile rigid body
        projectileRB = GetComponent<Rigidbody>();
        // Launch projectile
        Launch();
        // Start ttl timer
        StartCoroutine(TTLTimer());
    }

    
    void Update()
    {
        
    }
    // This function uses rigidbody Addforce to launch the projectile
    public void Launch()
    {
        projectileRB.AddForce(transform.forward * speed, ForceMode.Impulse);
    }
    // Add force to enemy rigidbody
    public void PushEnemy(Rigidbody otherRB)
    {
        otherRB.AddForce(transform.forward * forcePush, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        // if trigger in enemy
        if(other.gameObject.CompareTag("Enemy"))
        {
            // do damage and add force
            other.GetComponent<HealthManagerScript>().TakeDamage(damage);
            PushEnemy(other.GetComponent<Rigidbody>());
            // stop ttl timer and destroy this projectiler
            StopCoroutine(TTLTimer());
            ProjectileDestroy();
        }
        // if collision with wall 
        else if(other.gameObject.CompareTag("Wall"))
        {
            // destroy this projectile
            ProjectileDestroy();
        }
    }
    // destroy projectile and play visual/sound effects
    public void ProjectileDestroy()
    {
        Instantiate(projectileEffect, transform.position, projectileRB.transform.rotation);
        Destroy(gameObject);
    }

    // ttl timer, destroys objects after waiting for given seconds
    IEnumerator TTLTimer()
    {
        yield return new WaitForSeconds(ttl);
        ProjectileDestroy();
    }
}
