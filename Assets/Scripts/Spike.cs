using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private Health _health;
    private ScreenShakeController _shakeController;

    private void Start()
    {
        _health = FindObjectOfType<Health>();
        _shakeController = FindObjectOfType<ScreenShakeController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _health.TakeDamage(1);
        _shakeController.StartShake();
    }
}
