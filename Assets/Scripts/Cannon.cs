using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] GameObject cannonBall;
    
    [Header("Shoot Timer")]
    [SerializeField] float timer;
    [SerializeField] float cooldown;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > cooldown)
            ShootBall(); 
    }

    private void ShootBall()
    {
        timer = 0;
        Instantiate(cannonBall, transform);
    }
}
