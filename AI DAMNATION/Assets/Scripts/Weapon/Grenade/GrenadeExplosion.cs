using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeExplosion : MonoBehaviour
{
    float delay = 1.4f;
    float countdown;
    bool exploded = false;
    float damage = 100f;
    [SerializeField] float explosionRadius = 20;
    [SerializeField] float explosiveForce = 100f;
    [SerializeField] GameObject explosiveEffect;
    [SerializeField] GameObject destroyEffect;
    float destroyTime = 1f;
    public AudioSource grenadeExplosionSound;
    public AudioSource grenadeCollisionSound;
    bool isDestroyed = false;

    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;
        GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;

        if (countdown <= 0 && !exploded)
        {
            Explode();
            exploded = true;

        }
    }


    void Explode()
    {
        GameObject impact = Instantiate(explosiveEffect, transform.position, Quaternion.identity);

        Destroy(impact, 2);

        grenadeExplosionSound.Play();

        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach(Collider nearByObject in colliders)
        {
            Rigidbody rb = nearByObject.GetComponent<Rigidbody>();

            if(rb != null && rb.gameObject.tag == "enemy")
            {
                rb.AddExplosionForce(explosiveForce, transform.position, explosionRadius);

                nearByObject.gameObject.GetComponent<Ammo>();
                EnemyHealth enemyHealth = nearByObject.transform.GetComponent<EnemyHealth>();

                enemyHealth.EnemyDamage(damage, destroyTime);
            }
        }

        foreach(Transform child in gameObject.transform)
        {
            child.gameObject.SetActive(false);
        }

        Destroy(gameObject, 2);

        isDestroyed = true;

    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "surface" && !isDestroyed)
        {
            grenadeCollisionSound.Play();
        }




    }



}
