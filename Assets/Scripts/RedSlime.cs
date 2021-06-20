using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedSlime : MonoBehaviour
{
    private bool greenAtGoal = false;
    private bool blueAtGoal = false;

    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GreenSlime"))
            greenAtGoal = true;
        if (collision.gameObject.CompareTag("BlueSlime"))
            blueAtGoal = true;

        if (greenAtGoal && blueAtGoal)
            sceneLoader.LoadNextScene();
            
    }
}
