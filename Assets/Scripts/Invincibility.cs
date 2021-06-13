using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincibility : MonoBehaviour
{
    [SerializeField] GameObject greenSlime;
    [SerializeField] GameObject blueSlime;
    [SerializeField] float invincibilityDuration;
    [SerializeField] float invincibilityTime;
    [SerializeField] public bool isInvincible = false;

    private SpriteRenderer _gSpriteRenderer;
    private SpriteRenderer _bSpriteRenderer;

    private void Start()
    {
        _gSpriteRenderer = greenSlime.GetComponent<SpriteRenderer>();
        _bSpriteRenderer = blueSlime.GetComponent<SpriteRenderer>();
    }

    public void BecomeInvincible()
    {
        StartCoroutine(TemporaryInvincibility());
    }

    // Alternative method that changes slime colors
    private void InvincibilityFlash(Color color1, Color color2)
    {
        _gSpriteRenderer.color = color1;
        _bSpriteRenderer.color = color2;
    }

    private IEnumerator TemporaryInvincibility()
    {
        isInvincible = true;

        for (float i = 0; i < invincibilityDuration; i += invincibilityTime)
        {
            // Alternate between normal and white color to simulate flashing
            if (_gSpriteRenderer.color == Color.white)
                InvincibilityFlash(Color.red, Color.red);
            else
                InvincibilityFlash(Color.white, Color.white);

            yield return new WaitForSeconds(invincibilityTime);
        }

        InvincibilityFlash(Color.white, Color.white);
        isInvincible = false;
    }
}
