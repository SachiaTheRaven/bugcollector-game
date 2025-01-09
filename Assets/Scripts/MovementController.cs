
using UnityEngine;

public class MovementController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rigidBody;
   
    [SerializeField] private float speed;

    void Start()
    {
        rigidBody= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var speedX = Input.GetAxisRaw("Horizontal")*speed;
        var speedY = Input.GetAxisRaw("Vertical")*speed;
        rigidBody.velocity= new Vector3(speedX,speedY,0);
    }
}
