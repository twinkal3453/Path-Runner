
using UnityEngine;
//using UnityStandardAssets.CrossPlatformInput;

public class MoveScript : MonoBehaviour
{
    private Rigidbody rb;
    private float dirX;
    public float moveSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       // dirX = CrossPlatformInputManager.GetAxis("Horizontal") * moveSpeed;
        rb.velocity = new Vector3(dirX, 0f, 0f);
    }
}
