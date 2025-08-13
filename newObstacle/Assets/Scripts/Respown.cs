using UnityEngine;

public class Respawn : MonoBehaviour
{
    [Header("Respawn Settings")]
    private Vector3 startPosition;     // Where the car started
    private Quaternion startRotation;  // Car's initial rotation

    [Tooltip("Delay before respawning after collision")]
    [SerializeField] private float respawnDelay = 0.5f;

    [Tooltip("Tag of obstacles that will reset the car")]
    [SerializeField] private string dangerTag = "Danger";

    private void Start()
    {
        // Save the initial position & rotation
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if we collided with the danger object
        if (collision.gameObject.CompareTag(dangerTag))
        {
            // Destroy car visually (disable it)
            gameObject.SetActive(false);

            // Respawn after short delay
            Invoke(nameof(RespawnCar), respawnDelay);
        }
    }

    private void RespawnCar()
    {
        // Reset position & rotation
        transform.position = startPosition;
        transform.rotation = startRotation;

        // Enable the car again
        gameObject.SetActive(true);
    }
}
