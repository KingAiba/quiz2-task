using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManagerScript : MonoBehaviour
{
    public float maxHp = 150;
    public float curHp = 0;

    public float destroyDelay = 10f;

    public bool isDead = false;

    public GameManager gameManager;

    // Start is called before the first frame update
    public virtual void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        SetCurHp(maxHp);
    }

    // Update is called once per frame
    public virtual void Update()
    {
        CheckDeath();
    }

    public void SetCurHp(float val)
    {
        curHp = val;
    }

    public void TakeDamage(float val)
    {
        curHp -= val;
        if (curHp <= 0)
        {
            curHp = 0;
            isDead = true;
        }
    }

    public virtual void Death()
    {
        isDead = true;
        curHp = 0;
        Destroy(gameObject, destroyDelay);
    }

    public virtual void CheckDeath()
    {
        if (isDead)
        {
            Death();
        }
    }
}
