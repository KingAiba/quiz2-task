using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : HealthManagerScript
{

    public Vector3 moveDirection;
    public movementScript enemyMovementScript;
    public HealthManagerScript enemyHealthScript;

    public GameObject target;

    public float damage = 10;
    public float deathPushForce = 15;

    public ParticleSystem hitEffect;


    public override void Start()
    {
        base.Start();
        enemyMovementScript = GetComponent<movementScript>();
        enemyHealthScript = GetComponent<HealthManagerScript>();
   
        gameManager.AddToList(gameObject);

        target = GameObject.Find("Player");
    }

    public override void Update()
    {
        base.Update();
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

    public override void Death()
    {   
        gameManager.RemoveFromList(gameObject);
        gameManager.AddScore(10);
        base.Death();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            PlayerScript player = collision.gameObject.GetComponent<PlayerScript>();

            player.TakeDamage(damage);
            player.AddForceToPlayer(transform.forward * deathPushForce, ForceMode.Impulse);

            Instantiate(hitEffect, collision.contacts[0].point, hitEffect.transform.rotation);
            enemyHealthScript.Death();
        }
    }

}
