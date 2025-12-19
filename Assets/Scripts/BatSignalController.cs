using UnityEngine;

/// <summary>
/// Bat-Signal moves smoothly in X and Y (oscillation)
/// </summary>
public class BatSignalController : MonoBehaviour
{
    public KeyCode toggleKey = KeyCode.B;
    public Vector2 moveAmount = new Vector2(1f, 0.5f); // مقدار حرکت در X و Y
    public float moveSpeed = 1f; // سرعت حرکت

    private SpriteRenderer spriteRenderer;
    private Vector3 startPosition;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false; // ابتدا خاموش
        startPosition = transform.position;
    }

    void Update()
    {
        HandleToggle();
        MoveSignal();
    }

    void HandleToggle()
    {
        if (Input.GetKeyDown(toggleKey))
            spriteRenderer.enabled = !spriteRenderer.enabled;
    }

    void MoveSignal()
    {
        if(!spriteRenderer.enabled) return;

        float offsetX = Mathf.Sin(Time.time * moveSpeed) * moveAmount.x;
        float offsetY = Mathf.Cos(Time.time * moveSpeed) * moveAmount.y;

        transform.position = startPosition + new Vector3(offsetX, offsetY, 0f);
    }
}
