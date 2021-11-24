using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjectSprawler : MonoBehaviour
{
    public GameObject package;
    float yPos = 0f;
    float xPos_1;
    float zPos_1;
    float floorLengthX;
    float floorLengthZ;
    public GameObject floor;

    // Start is called before the first frame update
    void Start()
    {
        SprawlAmmoPickUp();
    }

    private void SprawlAmmoPickUp()
    {
        floorLengthX = floor.transform.localScale.x;
        floorLengthZ = floor.transform.localScale.z;
        xPos_1 = Random.Range(-floorLengthX / 2, floorLengthX / 2);
        zPos_1 = Random.Range(-floorLengthZ / 2, floorLengthZ / 2);
        Instantiate(package, new Vector3(xPos_1, yPos, zPos_1), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
