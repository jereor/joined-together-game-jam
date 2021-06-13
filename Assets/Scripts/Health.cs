using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    [SerializeField] int maxHealth;
    [SerializeField] int health;

    [SerializeField] TextMeshProUGUI healthDisplay;

    SceneLoader sceneLoader;
    Invincibility invincibility;

    private void Start()
    {
        health = maxHealth;
        sceneLoader = FindObjectOfType<SceneLoader>();
        invincibility = FindObjectOfType<Invincibility>();
        healthDisplay.text = health.ToString();
    }

    public int GetHealth()
    {
        return health;
    }

    public void TakeDamage(int dmg)
    {
        if (invincibility.isInvincible)
            return;

        invincibility.BecomeInvincible();
        health -= dmg;
        healthDisplay.text = health.ToString();

        if (health <= 0)
            GameOver();
    }

    private void GameOver()
    {
        sceneLoader.RestartScene();
    }
}
