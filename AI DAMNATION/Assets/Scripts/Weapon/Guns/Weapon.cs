using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float distance = 20f;
    [SerializeField] float damage = 30f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] AmmoType ammoType;
    [SerializeField] GrenadeType grenadeType;
    Ammo slots;
    [SerializeField] float shootTimeDelay = 0.5f;
    bool canShoot = true;
    [SerializeField] TextMeshProUGUI ammoText;
    [SerializeField] TextMeshProUGUI ammoTypeText;
    [SerializeField] float impactForce = 2000f;
    float destroyTime = 0f;
    AudioSource gunSound;

    private void OnEnable()
    {
        canShoot = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        slots = GetComponentInParent<Ammo>();
        gunSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayCurrentAmmo();

        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            StartCoroutine("Shoot");
        }
    }

    private void DisplayCurrentAmmo()
    {
        ammoTypeText.text = ammoType.ToString();
        ammoText.text = slots.showAmmoAmount(ammoType).ToString();
    }

    IEnumerator Shoot()
    {
        canShoot = false;

        if (slots.showAmmoAmount(ammoType) > 0) 
        {
            gunSound.Play();

            slots.ReduceAmmo(ammoType);

            ProcessRaycast();

            PlayMuzzleFlash();
        }

        yield return new WaitForSeconds(shootTimeDelay);

        canShoot = true;
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;

        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.TransformDirection(Vector3.forward), out hit, distance))
        {
            //Debug.Log("We hit " + hit.transform.name);

            Debug.DrawRay(FPCamera.transform.position, FPCamera.transform.TransformDirection(Vector3.forward) * distance, Color.red);

            EnemyHealth health = hit.transform.GetComponent<EnemyHealth>();

            CreateHitImpact(hit);

            AddImpactForce(hit);

            if (health == null) return;

            health.EnemyDamage(damage, destroyTime);
        }

        else
        {
            return;
        }
    }


    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }


    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));

        Destroy(impact, 1);

    }

    private void AddImpactForce(RaycastHit hit)
    {
        if (hit.rigidbody != null)
        {
            hit.rigidbody.AddForce(-hit.normal * impactForce);
        }
    }


}
