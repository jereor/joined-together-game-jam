using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeLink : MonoBehaviour
{
    [Header("Slimes")]
    [SerializeField] GameObject greenSlime;
    [SerializeField] GameObject blueSlime;

    [Header("Line Renderer")]
    [SerializeField] Material linkMaterial;
    [SerializeField] Color[] colors;

    [Header("Timer")]
    [SerializeField] float timer;
    [SerializeField] float damageWaitTime;

    private GameObject _line;
    private float _lineLen;

    private bool _isBreaking = false;
    private bool _isRed = false;

    Health health;
    ScreenShakeController shakeController;

    private void Start()
    {
        // Setup Link line and line renderer
        _line = new GameObject();
        _line.name = "Line Renderer";
        _line.AddComponent<LineRenderer>();
        _line.GetComponent<LineRenderer>().startWidth = 0.1f;
        _line.GetComponent<LineRenderer>().endWidth = 0.1f;
        _line.GetComponent<LineRenderer>().material = new Material(linkMaterial);

        // Script references
        health = FindObjectOfType<Health>();
        shakeController = FindObjectOfType<ScreenShakeController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health.GetHealth() - 1 >= 0 && health.GetHealth() -1 < colors.Length)
            DrawLine(greenSlime.transform.position, blueSlime.transform.position, colors[health.GetHealth() - 1]);

        if (GetLineLength() > 10)
        {
            _isBreaking = true;
            TakeDamageOverTime();
        }
        else
        {
            timer = 0;
            _isBreaking = false;
        }

        if (_isBreaking)
            shakeController.StartShake(.1f, .1f);
    }

    private void TakeDamageOverTime()
    {
        FlashColors();
        timer += Time.deltaTime;
        if (timer >= damageWaitTime)
        {
            health.TakeDamage(1);
            timer = 0;
        }
    }

    private void FlashColors()
    {
        if (_isRed)
        {
            _line.GetComponent<LineRenderer>().startColor = Color.white;
            _line.GetComponent<LineRenderer>().endColor = Color.white;
            _isRed = false;
        }
        else
        {
            _line.GetComponent<LineRenderer>().startColor = Color.red;
            _line.GetComponent<LineRenderer>().endColor = Color.red;
            _isRed = true;
        }

    }

    public void DrawLine(Vector3 start, Vector3 end, Color color)
    {
        _line.transform.position = start;
        _line.GetComponent<LineRenderer>().startColor = color;
        _line.GetComponent<LineRenderer>().endColor = color;
        _line.GetComponent<LineRenderer>().SetPosition(0, start);
        _line.GetComponent<LineRenderer>().SetPosition(1, end);
        _line.GetComponent<LineRenderer>().sortingOrder = 1;
    }

    public float GetLineLength()
    {
        _lineLen = Vector3.Distance(greenSlime.transform.position, blueSlime.transform.position);
        Debug.Log(_lineLen);
        return _lineLen;
    }
}
