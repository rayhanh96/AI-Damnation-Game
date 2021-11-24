using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    [SerializeField] float speed = 150f;
    PlayerHealth playerHealthScript;
    AudioSource pickUpSound;

    private void Start()
    {
        playerHealthScript = FindObjectOfType<PlayerHealth>();
        pickUpSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, -speed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            pickUpSound.Play();
            Destroy(gameObject, 1);
            playerHealthScript.ResetMaxHealth();
            playerHealthScript.playerHealth = 100f;

        }
    }






}
 