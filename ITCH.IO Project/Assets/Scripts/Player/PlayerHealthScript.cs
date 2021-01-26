using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthScript : MonoBehaviour
{
    SceneMNGR SceneManager;
    Scoremanager ScoreScript;
    private Image healthBar;
    public float currentHealth;
    public float maxHealth = 100f;

    void Start()
    {
        ScoreScript = FindObjectOfType<Scoremanager>();
        SceneManager = FindObjectOfType<SceneMNGR>();
        healthBar = GetComponent<Image>();
        currentHealth = maxHealth;
    }

    public void TakeDamage(float DamageTaken)
    {
        currentHealth -= DamageTaken;
    }

    void FixedUpdate()
    {
        if (healthBar.fillAmount > currentHealth / 100)
        {
            healthBar.fillAmount -= 0.2f * Time.deltaTime;
        }

        if (currentHealth <= 0)
        {
            ScoreScript.ChangeScore();
            SceneManager.StartGameOverScene();
        }
    }
}
