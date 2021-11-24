using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHealth = 100f;

    public GameObject enemy;

    public GameObject floor;

    [SerializeField] public TextMeshProUGUI enemiesKilledText;
    public static int enemiesKilled = 0;

    Ammo ammo;

    float yPos;
    float xPos_1;
    float zPos_1;

    float xPos_2;
    float zPos_2;
    float floorLengthX;
    float floorLengthZ;

    public void Start()
    {
        yPos = enemy.transform.position.y;
        floorLengthX = floor.transform.localScale.x;
        floorLengthZ = floor.transform.localScale.z;
        ammo = FindObjectOfType<Ammo>();
    }

    public void Update()
    {
        xPos_1 = Random.Range(-floorLengthX / 2, floorLengthX / 2)/2;
        zPos_1 = Random.Range(-floorLengthZ / 2, floorLengthZ / 2)/2;

        xPos_2 = Random.Range(-floorLengthX / 2, floorLengthX / 2)/2;
        zPos_2 = Random.Range(-floorLengthZ / 2, floorLengthZ / 2)/2;
        
    }



    public void EnemyDamage(float damage, float destroyTime)
    {
        enemyHealth -= damage;

        //BroadcastMessage("OnDamageTaken");

        if (enemyHealth <= 0)
        {
            GenerateTwoEnemies();
            Destroy(gameObject, destroyTime);
            DisplayEnemiesKilled();
        }
    }



    private void GenerateTwoEnemies()
    {
        //DisplayEnemiesKilled();
        enemyHealth = 100;
        Instantiate(enemy, new Vector3(xPos_1, yPos, zPos_1), Quaternion.identity);
        Instantiate(enemy, new Vector3(xPos_2, yPos, zPos_2), Quaternion.identity);

    }

    public void DisplayEnemiesKilled()
    {
        enemiesKilled++;
        enemiesKilledText.text = enemiesKilled.ToString();
    }

    public void ResetEnemyKilledScore()
    {
        enemiesKilled = 0;
    }

}
