using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManagerScript : MonoBehaviour
{
    public float maxHp = 150;
    public float curHp = 0;

    public bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        SetCurHp(maxHp);
    }

    // Update is called once per frame
    void Update()
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

    public void DeathOnCollision()
    {
        isDead = true;
        Destroy(gameObject);
    }

    public void CheckDeath()
    {
        if (isDead)
        {
            Destroy(gameObject);
        }
    }
}
