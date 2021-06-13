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
        rb.velocity = new Vector3(0f, rb.velocity.y);

        Debug.Log(rb.velocity.y);

        if (currentSlime.CompareTag("GreenSlime"))
            currentSlime = blueSlime;
        else if (currentSlime.CompareTag("BlueSlime"))
            currentSlime = greenSlime;
        currentSlime.GetComponent<PlayerMovement>().enabled = true;

        if (rb.velocity.y == 0)
            rb.isKinematic = true;
    }
}
