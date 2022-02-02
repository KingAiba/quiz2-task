using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Vector3 moveDirection;
    public movementScript playerMovementScript;

    public WeaponHolderScript weaponHolder;

    
    void Start()
    {
        playerMovementScript = GetComponent<movementScript>();
        weaponHolder = transform.Find("WeaponHolder").GetComponent<WeaponHolderScript>();
    }

    
    void Update()
    {
        getInput();      
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    public void getInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;

        SwitchWeapons();
        Attack();
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
