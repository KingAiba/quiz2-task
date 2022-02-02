using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolderScript : MonoBehaviour
{
    public List<GameObject> Weapons;

    
    public int maxWeaponSlots;

    public GameObject curWeapon;
    public int currWeaponSlot=0;
    // Start is called before the first frame update
    void Start()
    {
        GetAllWeapon();
        maxWeaponSlots = Weapons.Count;
        PickWeapon(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetAllWeapon()
    {
        foreach(Transform child in transform)
        {
            if(child.CompareTag("Weapon"))
            {
                Weapons.Add(child.gameObject);
            }
        }
    }

    public void ActivateCurrWeapon(int i)
    {
        if(curWeapon != null)
        {
            curWeapon.SetActive(false);
        }
        Weapons[i].SetActive(true);

        currWeaponSlot = i;
        curWeapon = Weapons[i];
    }

    public void PickWeapon(int i)
    {
        if(i >= 0 && i < maxWeaponSlots)
        {
            ActivateCurrWeapon(i);
        }
    }

    public void FireActiveWeapon()
    {
        curWeapon.GetComponent<WeaponScript>().FireWeapon();
    }
}
