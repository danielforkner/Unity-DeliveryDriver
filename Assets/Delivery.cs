using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage = false;
    [SerializeField] float destroyDelay = 0.5f;

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        Debug.Log("Ouch!");
    }
    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package picked up!");
            hasPackage = true;
            Destroy(collider.gameObject, destroyDelay);
        }
        if (collider.tag == "Customer" && hasPackage)
        {
            Debug.Log("Package Delivered!");
            hasPackage = false;
        }
    }
}
