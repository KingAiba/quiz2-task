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
    // Start is called before the first frame update
    void Start()
    {
        projectileRB = GetComponent<Rigidbody>();
        Launch();
        StartCoroutine(TTLTimer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Launch()
    {
        projectileRB.AddForce(transform.forward * speed, ForceMode.Impulse);
    }

    public void PushEnemy(Rigidbody otherRB)
    {
        otherRB.AddForce(transform.forward * forcePush, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<HealthManagerScript>().TakeDamage(damage);
            PushEnemy(other.GetComponent<Rigidbody>());

            StopCoroutine(TTLTimer());
            Destroy(gameObject);
        }
    }

    IEnumerator TTLTimer()
    {
        yield return new WaitForSeconds(ttl);
        Destroy(gameObject);
    }
}
