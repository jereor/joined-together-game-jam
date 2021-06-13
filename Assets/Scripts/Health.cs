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

    private void Start()
    {
        health = maxHealth;
        sceneLoader = FindObjectOfType<SceneLoader>();
        healthDisplay.text = health.ToString();
    }

    public void TakeDamage(int dmg)
    {
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
