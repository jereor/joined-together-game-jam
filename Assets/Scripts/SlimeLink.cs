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

    private GameObject _line;

    Health health;

    private void Start()
    {
        // Setup Link line and line renderer
        _line = new GameObject();
        _line.AddComponent<LineRenderer>();
        _line.GetComponent<LineRenderer>().startWidth = 0.1f;
        _line.GetComponent<LineRenderer>().endWidth = 0.1f;
        _line.GetComponent<LineRenderer>().material = new Material(linkMaterial);

        // Health script reference
        health = FindObjectOfType<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health.GetHealth() - 1 >= 0 && health.GetHealth() -1 < colors.Length)
            DrawLine(greenSlime.transform.position, blueSlime.transform.position, colors[health.GetHealth() - 1]);
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
}
