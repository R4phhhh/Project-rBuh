using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [Header("References")]
    public Transform player;
    public Transform rotatingPart;
    public float orbitRadius = 1.5f;

    private Camera mainCam;

    float timer = 0f;
    private List<Collider2D> enemiesInRange = new List<Collider2D>();

    void Start()
    {
        if (!player) player = GameObject.FindWithTag("Player")?.transform;
        mainCam = Camera.main;
        if (!rotatingPart) rotatingPart = transform;

        // Initialize at player's right side (0 degrees)
        UpdatePositionAndRotation(0f);
    }

    void Update()
    {
        if (!player || !mainCam) return;

        // Get cursor angle (0 = right, 90 = up, 180 = left, 270 = down)
        Vector2 cursorPos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(
            cursorPos.y - player.position.y,
            cursorPos.x - player.position.x
        ) * Mathf.Rad2Deg;

        if (timer < 1f)
        {
            timer += Time.deltaTime;
        }
        else
        {
            DamageAllEnemiesInRange();
            timer = 0f;
        }

            UpdatePositionAndRotation(angle);
        }

    void UpdatePositionAndRotation(float angle)
    {
        // Calculate orbit position (instant)
        Vector2 orbitPos = new Vector2(
            Mathf.Cos(angle * Mathf.Deg2Rad),
            Mathf.Sin(angle * Mathf.Deg2Rad)
        ) * orbitRadius;

        // Apply instant position and rotation
        transform.position = (Vector2)player.position + orbitPos;
        rotatingPart.rotation = Quaternion.Euler(0, 0, angle + 90f); // Outward facing
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<enemyMove>(out _))
        {
            enemiesInRange.Add(collider);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        enemiesInRange.Remove(collider);
    }

    private void DamageAllEnemiesInRange()
    {
        // Create a copy of the collection to safely iterate
        var enemiesToDamage = new List<Collider2D>(enemiesInRange);
        
        foreach (Collider2D enemyCollider in enemiesToDamage)
        {
            if (enemyCollider != null && 
                enemyCollider.TryGetComponent<enemyMove>(out var enemyScript))
            {
                Debug.Log("Damaging: " + enemyCollider.gameObject.name);
                enemyScript.TakeDamage(5);
            }
        }
    }

    void OnDrawGizmos()
    {
        if (!player) return;
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(player.position, orbitRadius);
    }
}
