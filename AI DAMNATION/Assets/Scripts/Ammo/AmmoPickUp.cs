using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 100f;
    int ammoReloadAmount;
    Ammo ammoScript;
    [SerializeField] AmmoType ammoType;
    public GameObject ammo;
    public GameObject floor;

    float yPos = -9f;
    float xPos_1;
    float zPos_1;

    float xPos_2;
    float zPos_2;
    float floorLengthX;
    float floorLengthZ;
    AudioSource pickUpSound;


    private void Start()
    {
        pickUpSound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        floorLengthX = floor.transform.localScale.x;
        floorLengthZ = floor.transform.localScale.z;
        xPos_1 = Random.Range(-floorLengthX / 2, floorLengthX / 2);
        zPos_1 = Random.Range(-floorLengthZ / 2, floorLengthZ / 2);

        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        ammoReloadAmount = Random.Range(8, 15);
    }

    private void OnTriggerEnter(Collider other)
    {
        ammoScript = FindObjectOfType<Ammo>();

        if (other.gameObject.tag == "Player")
        {
            pickUpSound.Play();

            //foreach (Transform child in gameObject.transform)
            //{
            //    child.gameObject.SetActive(false);
            //}

            Destroy(gameObject, 1);

            ammoScript.IncreaseAmmo(ammoType, ammoReloadAmount);
            GenerateAmmoPickUp();
        }
    }


    private void GenerateAmmoPickUp()
    {
        Instantiate(ammo, new Vector3(xPos_1, yPos, zPos_1), Quaternion.identity);

    }
}
