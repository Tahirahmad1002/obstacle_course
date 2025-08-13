using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private float smoothTime = 0.1f;
    
    [Header("Movement Limits (Optional)")]
    [SerializeField] private bool useBoundaries = false;
    [SerializeField] private float minX = -10f;
    [SerializeField] private float maxX = 10f;
    [SerializeField] private float minZ = -10f;
    [SerializeField] private float maxZ = 10f;
    
    // Private variables
    private Vector3 targetPosition;
    private Vector3 currentVelocity;
    private Vector3 inputDirection;
    
    void Start()
    {
        // Set initial target position to current position
        targetPosition = transform.position;
    }
    
    void Update()
    {
        // Get input from arrow keys and WASD
        GetInput();
        
        // Calculate target position
        CalculateMovement();
        
        // Apply smooth movement
        ApplySmoothMovement();
    }
    
    private void GetInput()
    {
        // Reset input direction
        inputDirection = Vector3.zero;
        
        // Try new Input System first, fallback to old system
        if (TryGetNewInputSystem())
        {
            // Successfully got input from new system
            return;
        }
        
        // Fallback to old Input System
        GetLegacyInput();
    }
    
    private bool TryGetNewInputSystem()
    {
        try
        {
            // Get current keyboard state (New Input System)
            var keyboard = Keyboard.current;
            if (keyboard == null) return false;
            
            // Arrow keys
            if (keyboard.leftArrowKey.isPressed)
                inputDirection.x = -1f;
            else if (keyboard.rightArrowKey.isPressed)
                inputDirection.x = 1f;
            
            if (keyboard.upArrowKey.isPressed)
                inputDirection.z = 1f;
            else if (keyboard.downArrowKey.isPressed)
                inputDirection.z = -1f;
            
            // WASD keys
            if (keyboard.aKey.isPressed)
                inputDirection.x = -1f;
            else if (keyboard.dKey.isPressed)
                inputDirection.x = 1f;
            
            if (keyboard.wKey.isPressed)
                inputDirection.z = 1f;
            else if (keyboard.sKey.isPressed)
                inputDirection.z = -1f;
            
            // Normalize diagonal movement
            inputDirection = inputDirection.normalized;
            return true;
        }
        catch
        {
            // New Input System not available, will use legacy
            return false;
        }
    }
    
    private void GetLegacyInput()
    {
        // Legacy Input System (works with old Unity Input Manager)
        
        // Arrow keys
        if (Input.GetKey(KeyCode.LeftArrow))
            inputDirection.x = -1f;
        else if (Input.GetKey(KeyCode.RightArrow))
            inputDirection.x = 1f;
        
        if (Input.GetKey(KeyCode.UpArrow))
            inputDirection.z = 1f;
        else if (Input.GetKey(KeyCode.DownArrow))
            inputDirection.z = -1f;
        
        // WASD keys
        if (Input.GetKey(KeyCode.A))
            inputDirection.x = -1f;
        else if (Input.GetKey(KeyCode.D))
            inputDirection.x = 1f;
        
        if (Input.GetKey(KeyCode.W))
            inputDirection.z = 1f;
        else if (Input.GetKey(KeyCode.S))
            inputDirection.z = -1f;
        
        // Normalize diagonal movement
        inputDirection = inputDirection.normalized;
    }
    
    private void CalculateMovement()
    {
        // Calculate target position based on input
        if (inputDirection != Vector3.zero)
        {
            Vector3 movement = inputDirection * moveSpeed * Time.deltaTime;
            targetPosition = transform.position + movement;
            
            // Apply boundaries if enabled
            if (useBoundaries)
            {
                targetPosition.x = Mathf.Clamp(targetPosition.x, minX, maxX);
                targetPosition.z = Mathf.Clamp(targetPosition.z, minZ, maxZ);
            }
        }
        else
        {
            // If no input, target position is current position (stops smoothly)
            targetPosition = transform.position;
        }
    }
    
    private void ApplySmoothMovement()
    {
        // Apply smooth movement using SmoothDamp
        transform.position = Vector3.SmoothDamp(
            transform.position, 
            targetPosition, 
            ref currentVelocity, 
            smoothTime
        );
    }
    
    // Optional: Method to set boundaries at runtime
    public void SetBoundaries(float minX, float maxX, float minZ, float maxZ)
    {
        this.minX = minX;
        this.maxX = maxX;
        this.minZ = minZ;
        this.maxZ = maxZ;
        useBoundaries = true;
    }
    
    // Optional: Method to disable boundaries
    public void DisableBoundaries()
    {
        useBoundaries = false;
    }
    
    // Optional: Get current movement info for debugging
    public Vector3 GetCurrentVelocity()
    {
        return currentVelocity;
    }
    
    public Vector3 GetInputDirection()
    {
        return inputDirection;
    }
}