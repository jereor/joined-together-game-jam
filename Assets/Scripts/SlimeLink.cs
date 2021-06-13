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

    private GameObject _line;
    private LineRenderer _lineRenderer;
    private int _colorCount;
    private Color _color = new Color(0, 1, 0, 0.5f);

    private Health _health;

    private void Start()
    {
        // Setup Link line and line renderer
        _line = new GameObject();
        _line.AddComponent<LineRenderer>();
        _lineRenderer = _line.GetComponent<LineRenderer>();
        _lineRenderer.startWidth = 0.1f;
        _lineRenderer.endWidth = 0.1f;
        _lineRenderer.material = new Material(linkShader);

        // Color and health variables
        _colorCount = colors.Length;
        _health = FindObjectOfType<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        DrawLine(greenSlime.transform.position, blueSlime.transform.position, _color);
    }

    public void DrawLine(Vector3 start, Vector3 end, Color color)
    {
        _line.transform.position = start;
        _lineRenderer.startColor = color;
        _lineRenderer.endColor = color;
        _lineRenderer.SetPosition(0, start);
        _lineRenderer.SetPosition(1, end);
    }
}
