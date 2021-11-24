using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    DisplayDamage displayDamage;
    public float playerHealth = 100;
    [SerializeField] Image healthBar;
    [SerializeField] TextMeshProUGUI healthScore;
    AudioSource bloodySound;
    EnemyHealth enemyHealthScript;

    public void Start()
    {
        displayDamage = GetComponent<DisplayDamage>();
        bloodySound = GetComponent<AudioSource>();
        enemyHealthScript = FindObjectOfType<EnemyHealth>();
    }

    private void Update()
    {
        healthBar.fillAmount = playerHealth / 100;
    }

    public void PlayerDamage(float playerDamage)
    {
        ReducePlayerHealthBar(playerDamage);

        playerHealth -= playerDamage;

        bloodySound.Play();

        displayDamage.ShowDamageImpact();

        if (playerHealth <= 0)
        {
            GetComponent<DeathHandler>().HandleDeath();
            enemyHealthScript.ResetEnemyKilledScore();

        }

    }

    void ReducePlayerHealthBar(float playerDamage)
    {
        healthBar.fillAmount = healthBar.fillAmount - (playerDamage / 100);
        healthScore.text = "Health: " + (playerHealth - playerDamage).ToString() + "%";
    }
    
    public void ResetMaxHealth()
    {
        healthScore.text = "Health: " + 100 + "%";
    }

}
