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

    public GameObject shotFlash;
    public GameObject reloadItem;
    public GameObject down;

    public Animator animatorRE;
    public Animator animatorPress;

    public AudioClip shotSound;
    public AudioClip shotgunReload;
    public AudioSource audioSource;
    public Text ammo;

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
                animatorPress.SetBool("Press", true);
                ammoCurrent -= 1;
                readyToShot = false;
            }
            
        }

        ammo.text = "" + ammoCurrent;

        if (Input.GetButton("Fire2") && !readyToShot && ammoCurrent > 0)
        {
            readyToShot = true;
            animatorRE.SetBool("Check", true);
        }
    }

    void rayCastShoot()
    {
        audioSource.PlayOneShot(shotSound);

        RaycastHit hit;

        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, shotRange))
        {
            Debug.Log("shooting " + hit.collider);
        }
    }

    bool shoot()
    {
        if (Input.GetButton("Fire1") && ((timeShot += Time.deltaTime) > 0.2))
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


}
