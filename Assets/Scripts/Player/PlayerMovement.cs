using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private float speed;

    private Movimento actions;
    private Vector2 moveDirection;
    private Rigidbody2D rb;
    private PlayerAnimations playerAnimations;
    private Player player;

    void Awake()
    {
        actions = new Movimento();
        rb = GetComponent<Rigidbody2D>();
        playerAnimations = GetComponent<PlayerAnimations>();
        player = GetComponent<Player>();
    }

    void Update()
    {
        ReadMovement();
    }

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
            playerAnimations.SetMoveBoolTransition(false);
            return;
        }
        else
        {
            playerAnimations.SetMoveBoolTransition(true);
            playerAnimations.SetMoveAnimation(moveDirection);
        }
    }

    private void Move()
    {
        if (player.Stats.PlayerHealth <= 0)
        {
            return;
        }

        rb.MovePosition(rb.position + moveDirection * (speed * Time.fixedDeltaTime));
    }
}
