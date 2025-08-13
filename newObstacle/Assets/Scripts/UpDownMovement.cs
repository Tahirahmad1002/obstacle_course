using UnityEngine;

public class UpDownMovement : MonoBehaviour
{
    public float moveDownAmount = 15f; // How far to go down from start position
    public float speed = 7f;           // Movement speed

    private Vector3 startPos;
    private Vector3 downPos;
    private bool goingDown = true;

    void Start()
    {
        startPos = transform.position;
        downPos = startPos - new Vector3(0, moveDownAmount, 0);
    }

    void Update()
    {
        if (goingDown)
        {
            transform.position = Vector3.MoveTowards(transform.position, downPos, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, downPos) < 0.01f)
                goingDown = false;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, startPos) < 0.01f)
                goingDown = true;
        }
    }
}