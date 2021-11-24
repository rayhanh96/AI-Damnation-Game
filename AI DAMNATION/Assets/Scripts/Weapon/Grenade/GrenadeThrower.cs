using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GrenadeThrower : MonoBehaviour
{
    [SerializeField] GameObject grenadePrefab;
    [SerializeField] float throwForce = 20f;
    Ammo grenadeSlot;
    GrenadeType grenadeType;
    Ammo slots;
    [SerializeField] TextMeshProUGUI ammoAmountText;
    [SerializeField] TextMeshProUGUI ammoTypeText;

    // Start is called before the first frame update
    void Start()
    {
        grenadeSlot = FindObjectOfType<Ammo>();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayGrenadeAmount();

        if (Input.GetMouseButtonDown(0) && grenadeSlot.showGrenadeAmount(grenadeType) > 0)
        {
            ThrowGrenade();
        }       
    }

    void ThrowGrenade()
    {
        GameObject genade = Instantiate(grenadePrefab, transform.position, transform.rotation);

        genade.GetComponent<Rigidbody>().AddForce(transform.forward * throwForce, ForceMode.VelocityChange);

        grenadeSlot.ReduceGrenadeAmount(grenadeType);

    }

    private void DisplayGrenadeAmount()
    {
        ammoTypeText.text = grenadeType.ToString();
        ammoAmountText.text = grenadeSlot.showGrenadeAmount(grenadeType).ToString();
    }



}
