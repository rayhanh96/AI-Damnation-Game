using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{
    [SerializeField] Canvas bloodSplatter;
    [SerializeField] float impactTime = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        bloodSplatter.enabled = false;
    }

    public void ShowDamageImpact()
    {
        StartCoroutine(ShowSplatter());
    }



    IEnumerator ShowSplatter()
    {
        bloodSplatter.enabled = true;

        yield return new WaitForSeconds(impactTime);

        bloodSplatter.enabled = false;


    }


}
