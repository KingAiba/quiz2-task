using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject barrel;

    public float fireRate = 2;
    // Start is called before the first frame update
    void Start()
    {
        barrel = transform.Find("Barrel").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FireWeapon()
    {
        
        Instantiate(projectilePrefab, barrel.transform.position, barrel.transform.rotation);
    }
}
