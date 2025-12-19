using UnityEngine;

/// <summary>
/// کنترل حرکت ساده‌ی 2D برای Batman و Batmobile.
/// شامل حرکت عادی و افزایش سرعت با نگه داشتن Shift.
/// بدون Rigidbody و انیمیشن.
/// </summary>
public class CharacterMovement2D : MonoBehaviour
{
    [Header("Movement Settings")]
    public float normalSpeed = 3f;
    public float boostSpeed = 6f;

    private float currentSpeed;

    void Update()
    {
        HandleMovement();
    }

    /// <summary>
    /// دریافت ورودی‌های کیبورد و جابجایی کاراکتر فعال.
    /// </summary>
    void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal"); // A/D یا ←/→
        float vertical = Input.GetAxis("Vertical");     // W/S یا ↑/↓

        // بررسی نگه داشتن کلید Shift برای افزایش سرعت
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = boostSpeed;
        }
        else
        {
            currentSpeed = normalSpeed;
        }

        Vector3 movement = new Vector3(horizontal, vertical, 0f);
        transform.position += movement * currentSpeed * Time.deltaTime;
    }
}
