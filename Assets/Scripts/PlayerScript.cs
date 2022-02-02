using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScript : HealthManagerScript
{
    public Vector3 moveDirection;
    public movementScript playerMovementScript;

    public WeaponHolderScript weaponHolder;

    public TMP_Text hpText;


    public override void Start()
    {
        base.Start();
        playerMovementScript = GetComponent<movementScript>();
        weaponHolder = transform.Find("WeaponHolder").GetComponent<WeaponHolderScript>();
        gameManager.playerScript = this;
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

    public void getInput()
    {
        if (!isDead)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;

            SwitchWeapons();
            Attack();
        }

    }

    public void UpdateHPText()
    {
        hpText.SetText("HP:" + curHp + "/" + maxHp);
    }

    public void Attack()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            weaponHolder.FireActiveWeapon();
        }
    }

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

    public void PlayerMovement()
    {
        playerMovementScript.moveObject(moveDirection);
        playerMovementScript.rotateObject(moveDirection);
    }

    
}
