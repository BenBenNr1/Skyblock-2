using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float xRotSpeed;
    [SerializeField] float yRotSpeed;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        RotateCam();
    }

    private void FixedUpdate()
    {
        if (Input.GetAxis("Horizontal") != 0) { rb.AddForce(transform.right * Input.GetAxis("Horizontal") * speed); }
        if (Input.GetAxis("Vertical") != 0) { rb.AddForce(transform.forward * Input.GetAxis("Vertical") * speed); }
        if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0)
        { rb.linearVelocity = new Vector3(rb.linearVelocity.x * 0.9f, rb.linearVelocity.y, rb.linearVelocity.z * 0.9f); }
    }

    private void RotateCam()
    {
        float xRot = Input.mousePositionDelta.x * Time.deltaTime;
        float yRot = Input.mousePositionDelta.y * Time.deltaTime;
        Transform cam = Camera.main.transform;

        transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y + xRot * xRotSpeed, 0);
        cam.rotation = Quaternion.Euler(cam.eulerAngles.x + -yRot * yRotSpeed,cam.eulerAngles.y,cam.eulerAngles.z);
    }
}
