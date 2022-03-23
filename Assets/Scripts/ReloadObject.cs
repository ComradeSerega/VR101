using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ammo")
        {
            if(transform.parent.GetComponentInChildren<Shotgun>().ammoCurrent < transform.parent.GetComponentInChildren<Shotgun>().ammoMax)
            {
                transform.parent.GetComponentInChildren<Shotgun>().reload();
                Destroy(other.gameObject);
            }
        }
    }
}
