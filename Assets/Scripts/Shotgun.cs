using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shotgun : MonoBehaviour
{
    public int damage = 40;
    public int ammoMax = 5;
    public int ammoCurrent = 0;
    public bool readyToShot = false;
    public float shotRange = 1000;
    private float timeShot;
    public int deerKilled = 0;

    public GameObject shotFlash;
    public GameObject reloadItem;
    public GameObject target;

    public Animator animatorRE;

    public AudioClip shotSound;
    public AudioClip shotgunReload;
    public AudioClip reL;
    public AudioSource audioSource;
    public Text ammo;
    public Text deers;

    public Camera camera;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if(ammoCurrent > 0 && readyToShot)
        {
            if (shoot())
            {
                ammoCurrent -= 1;
                readyToShot = false;
            }
            
        }

        ammo.text = "Ammo " + ammoCurrent + "/" + ammoMax;

        if (checkFire2() && !readyToShot && ammoCurrent > 0)
        {
            readyToShot = true;
            audioSource.PlayOneShot(reL);
            animatorRE.SetBool("Check", true);
        }
    }

    void rayCastShoot()
    {
        audioSource.PlayOneShot(shotSound);

        RaycastHit hit;

        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, shotRange))
        {
            if(hit.collider.name == target.name)
            {
                deerKilled += 1;
                //Debug.Log("deer " + deerKilled);
                deers.text = deerKilled.ToString();
                target.transform.position = new Vector3(-120, 0, -60);
            }
        }
    }

    bool shoot()
    {
        if (checkFire1() && ((timeShot += Time.deltaTime) > 0.2))
        {
            timeShot = 0.0f;
            rayCastShoot();

            return true;
        }
        return false;
    }

    public void reload()
    {
        audioSource.PlayOneShot(shotgunReload);
        ammoCurrent++;
    }

    //кнопки A, B на правом контроллере 

    public bool checkFire1()
    {
        //if (Input.GetButton("Fire1"))
        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            return true;
        }
        else return false;
    }

    public bool checkFire2()
    {
        //if (Input.GetButton("Fire2"))
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            return true;
        }
        else return false;
    }


}
