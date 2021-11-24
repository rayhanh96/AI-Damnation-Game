using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    int selectedWeaponNumber;

    [SerializeField] Canvas weaponIconsCanvas;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ScrollSwitcher();

        //NumberSwitcher();

        SelectWeapon();

        SelectWeaponIcon();
    }

    void ScrollSwitcher()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (selectedWeaponNumber >= transform.childCount - 1)
            {
                selectedWeaponNumber = 0;
            }

            else
            {
                selectedWeaponNumber++;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (selectedWeaponNumber <= 0)
            {
                selectedWeaponNumber = transform.childCount - 1;
            }

            else
            {
                selectedWeaponNumber--;
            }
        }
    }



    //void NumberSwitcher()
    //{
    //    if (Input.GetKeyDown(KeyCode.Alpha1))
    //    {
    //        selectedWeaponNumber = 0;
    //    }

    //    if (Input.GetKeyDown(KeyCode.Alpha2))
    //    {
    //        selectedWeaponNumber = 1;
    //    }

    //    if (Input.GetKeyDown(KeyCode.Alpha3))
    //    {
    //        selectedWeaponNumber = 2;
    //    }

    //    if (Input.GetKeyDown(KeyCode.Alpha4))
    //    {
    //        selectedWeaponNumber = 3;
    //    }
    //}

    void SelectWeapon()
    {
        int weaponIndex = 0;

        foreach (Transform weapon in transform)
        {
            if(weaponIndex == selectedWeaponNumber)
            {
                weapon.gameObject.SetActive(true);
            }

            else
            {
                weapon.gameObject.SetActive(false);
            }

            weaponIndex++;
        }

    }

    void SelectWeaponIcon()
    {
        int weaponIconIndex = 0;

        foreach (Transform weaponIcon in weaponIconsCanvas.transform)
        {
            if (weaponIconIndex == selectedWeaponNumber)
            {
                weaponIcon.gameObject.SetActive(true);
            }

            else
            {
                weaponIcon.gameObject.SetActive(false);
            }

            weaponIconIndex++;
        }
    }



}
