using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public float maxHp = 150;
    public float curHp = 0;

    public Vector3 moveDirection;
    public movementScript enemyMovementScript;

    public GameObject target;

    public bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        SetCurHp(maxHp);
        enemyMovementScript = GetComponent<movementScript>();
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        LookAtTarget();
        CheckDeath();
    }

    private void FixedUpdate()
    {
        rotateObject();
        moveObject();
    }

    public void LookAtTarget()
    {
        if(target != null)
        {
            moveDirection = (target.transform.position - transform.position).normalized;
        }
    }

    public void rotateObject()
    {
        enemyMovementScript.rotateObject(moveDirection);
    }

    public void moveObject()
    {
        enemyMovementScript.moveObject(moveDirection);
    }

    public void SetCurHp(float val)
    {
        curHp = val;
    }

    public void TakeDamage(float val)
    {
        curHp -= val;
        if(curHp <= 0)
        {
            curHp = 0;
            isDead = true;
        }
    }

    public void DeathOnWallCollision()
    {
        isDead = true;
        Destroy(gameObject);
    }

    public void CheckDeath()
    {
        if(isDead)
        {
            Destroy(gameObject);
        }
    }
}
