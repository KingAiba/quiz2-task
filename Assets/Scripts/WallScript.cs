using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    HealthManagerScript objHPScript;
    public bool isDistructable = false;

    public float forceStrength;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyScript>().Death();
        }
        else if(collision.gameObject.CompareTag("Player"))
        {
            PlayerScript player = collision.gameObject.GetComponent<PlayerScript>();

            Vector3 forceDir = -(collision.contacts[0].point - transform.position).normalized;
            player.AddForceToPlayer(forceDir * forceStrength, ForceMode.Impulse);

            player.Death();
            
        }
    }
}
