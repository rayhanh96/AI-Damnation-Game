using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadePickUp : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 100f;
    int grenadeReloadAmount;
    Ammo ammoScript;
    [SerializeField] GrenadeType grenadeType;
    public GameObject ammo;
    public GameObject floor;

    float yPos = 0f;
    float xPos_1;
    float zPos_1;

    float xPos_2;
    float zPos_2;
    float floorLengthX;
    float floorLengthZ;

    AudioSource grenadePickUpSound;

    private void Start()
    {
        grenadePickUpSound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        floorLengthX = floor.transform.localScale.x;
        floorLengthZ = floor.transform.localScale.z;
        xPos_1 = Random.Range(-floorLengthX / 2, floorLengthX / 2);
        zPos_1 = Random.Range(-floorLengthZ / 2, floorLengthZ / 2);

        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        grenadeReloadAmount = Random.Range(2, 4);
    }

    private void OnTriggerEnter(Collider other)
    {
        ammoScript = FindObjectOfType<Ammo>();

        if (other.gameObject.tag == "Player")
        {
            grenadePickUpSound.Play();
            Destroy(gameObject, 1);
            ammoScript.IncreaseGrenadeAmmo(grenadeType, grenadeReloadAmount);
            GenerateAmmoPickUp();
        }
    }


    private void GenerateAmmoPickUp()
    {
        Instantiate(ammo, new Vector3(xPos_1, yPos, zPos_1), Quaternion.identity);
    }
}
