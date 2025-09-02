using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;

    Camera cam;
    bool inputEnabled = false;          
    bool waitingForInitialMouseUp = true; 
    float enableCollisionsAt;

    void Awake()
    {
        cam = Camera.main;
        if (cam == null) Debug.LogError("No camera tagged MainCamera.");
    }

    void Start()
    {
        Cursor.visible = true;                 //show cursor 
        Cursor.lockState = CursorLockMode.None;
        enableCollisionsAt = Time.time + 0.3f; 
        inputEnabled = false;
        waitingForInitialMouseUp = true;      
    }

    void Update()
    {
        if (waitingForInitialMouseUp)
        {
            if (!Input.GetMouseButton(0))      
                waitingForInitialMouseUp = false;
            return;
        }

     
        if (!inputEnabled && Input.GetMouseButtonDown(0))
        {
            inputEnabled = true;
            Cursor.visible = false;
        }

        if (!inputEnabled || cam == null) return;

        // Follow mouse
        Vector3 target = cam.ScreenToWorldPoint(Input.mousePosition);
        target.z = 0f;
        transform.position = Vector3.Lerp(transform.position, target, moveSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (Time.time < enableCollisionsAt) return;
        if (!inputEnabled) return;

        if (other.CompareTag("Wall"))
        {
            inputEnabled = false;
            Cursor.visible = true;   
            if (GameManager.Instance) GameManager.Instance.GameOver();
        }
        else if (other.CompareTag("Goal"))
        {
            inputEnabled = false;
            Cursor.visible = true;   
            if (GameManager.Instance) GameManager.Instance.Win();
        }
    }
}
