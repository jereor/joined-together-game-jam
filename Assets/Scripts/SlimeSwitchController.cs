using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSwitchController : MonoBehaviour
{
    [Header("Slimes")]
    [SerializeField] GameObject greenSlime;
    [SerializeField] GameObject blueSlime;
    [SerializeField] GameObject currentSlime;

    private void Awake()
    {
        currentSlime = greenSlime;
        currentSlime.GetComponent<PlayerMovement>().enabled = true;
        currentSlime.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animation/Focused_GreenSlime") as RuntimeAnimatorController;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            SwitchSlimes();
        }
    }

    private void SwitchSlimes()
    {
        currentSlime.GetComponent<PlayerMovement>().enabled = false;
        var rb = currentSlime.GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;

        if (currentSlime.CompareTag("GreenSlime"))
        {
            currentSlime.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animation/GreenSlime") as RuntimeAnimatorController;
            currentSlime = blueSlime;
            currentSlime.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animation/Focused_BlueSlime") as RuntimeAnimatorController;
        }
        else if (currentSlime.CompareTag("BlueSlime"))
        {
            currentSlime.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animation/BlueSlime") as RuntimeAnimatorController;
            currentSlime = greenSlime;
            currentSlime.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animation/Focused_GreenSlime") as RuntimeAnimatorController;
        }

        rb = currentSlime.GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        currentSlime.GetComponent<PlayerMovement>().enabled = true;
    }
}
