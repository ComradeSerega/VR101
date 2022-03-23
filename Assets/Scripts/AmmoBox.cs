using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    public GameObject ammo;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(ammo, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "Ammo")
        {
            Instantiate(ammo, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
        }
    }
}
