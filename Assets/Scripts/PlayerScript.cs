using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScript : HealthManagerScript
{
    public Vector3 moveDirection;
    public movementScript playerMovementScript;

    public WeaponHolderScript weaponHolder;

    public bool RagdollEnabled = false;

    public TMP_Text hpText;

    public ParticleSystem deathEffect;

    public override void Start()
    {
        base.Start();
        playerMovementScript = GetComponent<movementScript>();
        weaponHolder = transform.Find("Stylized Astronaut").transform.Find("WeaponHolder").GetComponent<WeaponHolderScript>();
        gameManager.playerScript = this;

        DisableRagdoll();
    }


    public override void Update()
    {
        base.Update();
        getInput();
        UpdateHPText();
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }
    // Get input using horizontal and vertical axis
    public void getInput()
    {
        if (!isDead)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            // set movedirection 
            moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;

            SwitchWeapons();
            Attack();
        }

    }
    // update health ui text
    public void UpdateHPText()
    {
        hpText.SetText("HP:" + curHp + "/" + maxHp);
    }
    // attack using weapon on space down
    public void Attack()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            weaponHolder.FireActiveWeapon();
        }
    }
    // switch weapons on key down
    public void SwitchWeapons()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            weaponHolder.PickWeapon(0);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            weaponHolder.PickWeapon(1);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            weaponHolder.PickWeapon(2);
        }
    }
    // player movement using movementScript functions
    public void PlayerMovement()
    {
        playerMovementScript.moveObject(moveDirection);
        playerMovementScript.rotateObject(moveDirection);
    }
    // add force to player rigidbody
    public void AddForceToPlayer(Vector3 force, ForceMode forcemode)
    {
        playerMovementScript.objectRB.AddForce(force, forcemode);
    }
    // death procedure
    public override void Death()
    {
        if (!isDead)
        {
            Instantiate(deathEffect, transform.position, deathEffect.transform.rotation);
            EnableRagdoll();
            base.Death();
        }
    }
    // iterate through all collider and rigidbody(except player object and weapons) and disable them.
    public void DisableRagdoll()
    {
        Rigidbody[] rbArr = GetComponentsInChildren<Rigidbody>();
        Collider[] cArr = GetComponentsInChildren<Collider>();

        foreach (Collider c in cArr)
        {
            if (c.gameObject.CompareTag("Player") || c.gameObject.CompareTag("Weapon"))
            {
                continue;
            }
            else
            {
                c.enabled = false;
            }
        }

        foreach (Rigidbody rb in rbArr)
        {
            if (rb.gameObject.CompareTag("Player") || rb.gameObject.CompareTag("Weapon"))
            {
                continue;
            }
            else
            {
                rb.isKinematic = true;
            }
        }
        RagdollEnabled = false;
    }
    // iterate through all collider and rigidbody and enable them.
    public void EnableRagdoll()
    {
        Rigidbody[] rbArr = GetComponentsInChildren<Rigidbody>();
        Collider[] cArr = GetComponentsInChildren<Collider>();

        foreach (Collider c in cArr)
        {

            c.enabled = true;

        }
        foreach (Rigidbody rb in rbArr)
        {
            rb.isKinematic = false;
        }
        RagdollEnabled = true;
    }



}
