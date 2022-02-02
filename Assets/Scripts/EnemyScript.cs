using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public Vector3 moveDirection;
    public movementScript enemyMovementScript;
    public HealthManagerScript enemyHealthScript;

    public GameObject target;

    public float damage = 10;
    public float deathPushForce = 15;

    private GameManager gameManager; 

    // Start is called before the first frame update
    void Start()
    {
        
        enemyMovementScript = GetComponent<movementScript>();
        enemyHealthScript = GetComponent<HealthManagerScript>();

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager.AddToList(gameObject);

        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        LookAtTarget();
    }

    private void FixedUpdate()
    {
        RotateObject();
        MoveObject();
    }

    public void LookAtTarget()
    {
        if(target != null)
        {
            moveDirection = (target.transform.position - transform.position).normalized;
        }
    }

    public void RotateObject()
    {
        enemyMovementScript.rotateObject(moveDirection);
    }

    public void MoveObject()
    {
        enemyMovementScript.moveObject(moveDirection);
    }

    public void PushObject(Rigidbody otherRB)
    {
        otherRB.AddForce(transform.forward * deathPushForce, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<HealthManagerScript>().TakeDamage(damage);
            PushObject(collision.gameObject.GetComponent<Rigidbody>());
            enemyHealthScript.DeathOnCollision();
        }
    }
}
