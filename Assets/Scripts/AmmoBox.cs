using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    public GameObject ammo;

    // Start is called before the first frame update
    void Start()
    {
        spawnAmmo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerLeave(Collider other)
    {
        if (other.gameObject.tag == "Ammo")
        {
            spawnAmmo();
        }
    }

    private void AmmoBox_actionDestroy()
    {
        spawnAmmo();
    }

    private void spawnAmmo()
    {
        GameObject bullet = Instantiate(ammo, new Vector3(transform.position.x, transform.position.y + 0.3f, transform.position.z), Quaternion.identity);
        bullet.GetComponent<Ammo>().actionDestroy += AmmoBox_actionDestroy;
    }
}
