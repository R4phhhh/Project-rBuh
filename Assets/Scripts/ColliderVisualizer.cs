using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderVisualizer : MonoBehaviour
{
    public Color outlineColor = Color.red;
    public float lineWidth = 0.05f;
    
    private LineRenderer lineRenderer;

    void Start()
    {
        Collider2D col = GetComponent<Collider2D>();
        if (!col) return;

        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = outlineColor;
        lineRenderer.endColor = outlineColor;
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
        lineRenderer.useWorldSpace = false;

        if (col is BoxCollider2D box)
        {
            DrawBox(box);
        }
        else if (col is CircleCollider2D circle)
        {
            DrawCircle(circle);
        }
    }

    void DrawBox(BoxCollider2D box)
    {
        Vector2 size = box.size;
        Vector2 offset = box.offset;
        
        lineRenderer.positionCount = 5;
        lineRenderer.SetPositions(new Vector3[] {
            new Vector3(-size.x/2 + offset.x, -size.y/2 + offset.y, 0),
            new Vector3(size.x/2 + offset.x, -size.y/2 + offset.y, 0),
            new Vector3(size.x/2 + offset.x, size.y/2 + offset.y, 0),
            new Vector3(-size.x/2 + offset.x, size.y/2 + offset.y, 0),
            new Vector3(-size.x/2 + offset.x, -size.y/2 + offset.y, 0)
        });
    }

    void DrawCircle(CircleCollider2D circle, int segments = 32)
    {
        Vector2 offset = circle.offset;
        float radius = circle.radius;
        
        lineRenderer.positionCount = segments + 1;
        Vector3[] points = new Vector3[segments + 1];
        
        for (int i = 0; i <= segments; i++)
        {
            float angle = i * Mathf.PI * 2 / segments;
            points[i] = new Vector3(
                Mathf.Cos(angle) * radius + offset.x,
                Mathf.Sin(angle) * radius + offset.y,
                0
            );
        }
        
        lineRenderer.SetPositions(points);
    }
}
