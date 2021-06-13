using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeLink : MonoBehaviour
{
    [Header("Slimes")]
    [SerializeField] GameObject greenSlime;
    [SerializeField] GameObject blueSlime;

    [Header("Line Renderer")]
    [SerializeField] Shader linkShader;
    [SerializeField] Color[] colors;

    private int _colorCount;
    Color color = new Color(0, 1, 0, 0.5f);

    Health health;

    private void Start()
    {
        _colorCount = colors.Length;
        health = FindObjectOfType<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        DrawLine(greenSlime.transform.position, blueSlime.transform.position, color);
    }

    public void DrawLine(Vector3 start, Vector3 end, Color color)
    {
        GameObject line = new GameObject();
        line.transform.position = start;
        line.AddComponent<LineRenderer>();
        LineRenderer lr = line.GetComponent<LineRenderer>();
        lr.material = new Material(linkShader);
        lr.startColor = color;
        lr.endColor = color;
        lr.startWidth = 0.1f;
        lr.endWidth = 0.1f;
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
        Destroy(line, 0.01f);
    }
}
