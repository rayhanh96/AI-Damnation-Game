using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySprawl : MonoBehaviour
{
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        SprawlEnemy();
    }

    private void SprawlEnemy()
    {
        Instantiate(enemy, new Vector3(0, 2f, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
