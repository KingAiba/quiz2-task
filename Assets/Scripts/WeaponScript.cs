using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject barrel;

    public float fireRate = 2;

    public AudioClip weaponSound;
    public AudioSource weaponAS;
    // Start is called before the first frame update
    void Start()
    {
        barrel = transform.Find("Barrel").gameObject;
        weaponAS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FireWeapon()
    {
        weaponAS.PlayOneShot(weaponSound);
        Instantiate(projectilePrefab, barrel.transform.position, barrel.transform.rotation);
    }
}
