using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoAmount;
    }

    [SerializeField] AmmoSlot[] ammoSlots;

    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach (AmmoSlot ammoSlot in ammoSlots)
        {
            if (ammoSlot.ammoType == ammoType)
            {
                return ammoSlot;
            }
        }

        return null;
    }

    [System.Serializable]
    private class GrenadeSlot
    {
        public GrenadeType grenadeType;
        public int grenadeAmount;
    }

    [SerializeField] GrenadeSlot[] grenadeSlots;

    private GrenadeSlot GetGrenadeSlot(GrenadeType grenadeType)
    {
        foreach (GrenadeSlot grenadeSlot in grenadeSlots)
        {
            if (grenadeSlot.grenadeType == grenadeType)
            {
                return grenadeSlot;
            }
        }

        return null;
    }

    public int showAmmoAmount(AmmoType ammoType)
    {
        return GetAmmoSlot(ammoType).ammoAmount;
    }

    public int showGrenadeAmount(GrenadeType grenadeType)
    {
        return GetGrenadeSlot(grenadeType).grenadeAmount;
    }

    public void ReduceAmmo(AmmoType ammoType)
    {
        GetAmmoSlot(ammoType).ammoAmount--;
    }

    public void ReduceGrenadeAmount(GrenadeType grenadeType)
    {
        GetGrenadeSlot(grenadeType).grenadeAmount--;
    }

    public void IncreaseGrenadeAmmo(GrenadeType grenadeType, int grenadeReloadAmount)
    {
        GetGrenadeSlot(grenadeType).grenadeAmount += grenadeReloadAmount;
    }

    public void IncreaseAmmo(AmmoType ammoType, int ammoReloadAmount)
    {
        GetAmmoSlot(ammoType).ammoAmount += ammoReloadAmount;
    }
}
