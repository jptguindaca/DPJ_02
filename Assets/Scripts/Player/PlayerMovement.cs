using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private float speed;


    private Movimento actions;
    private Vector2 moveDirection;
    private Rigidbody2D rb;
    private Animator anim;
    void Awake()    
    {
        actions = new Movimento();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {

    }
    
    void Update()
    {
        ReadMovement();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    
    private void OnEnable()
    {
        actions.Enable();
        
    }

    private void OnDisable()
    {
        actions.Disable();
    }

    private void ReadMovement()
    {
        moveDirection = actions.Movement.Move.ReadValue<Vector2>().normalized;



        if (moveDirection == Vector2.zero)
        {

        
            anim.SetBool("Moving", false);


            return;
        }
        else
        {
            anim.SetFloat("MoveX", moveDirection.x);

            anim.SetFloat("MoveY", moveDirection.y);

            anim.SetBool("Moving", true);
        }
    }

    private void Move()
    {
        rb.MovePosition(rb.position + moveDirection * (speed * Time.fixedDeltaTime));
    }

}
