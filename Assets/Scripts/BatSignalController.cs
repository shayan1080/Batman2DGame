using UnityEngine;

/// <summary>
/// کنترل Bat-Signal: روشن/خاموش و چرخش ساده
/// </summary>
public class BatSignalController : MonoBehaviour
{
    public KeyCode toggleKey = KeyCode.B;
    private SpriteRenderer spriteRenderer;

    [Header("Rotation Settings")]
    public float rotationSpeed = 10f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false; // ابتدا خاموش
    }

    void Update()
    {
        HandleToggle();
        RotateSignal();
    }

    void HandleToggle()
    {
        if (Input.GetKeyDown(toggleKey))
            spriteRenderer.enabled = !spriteRenderer.enabled;
    }

    void RotateSignal()
    {
        if (spriteRenderer.enabled)
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
