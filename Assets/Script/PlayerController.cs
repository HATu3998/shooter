using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 2f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator animator;
    private Camera mainCamera;

    public GameObject bulletPrefabs;
    public Transform firePoint;
    public float fireRate = 0.5f;
    private float nextFireTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        UpdateAnimationState();
        if(Input.GetMouseButtonDown(0) && Time.time > nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = moveInput.normalized * moveSpeed;
        RotatePlayer();
    }
    void UpdateAnimationState()
    {
        if(moveInput.magnitude > 0)
        {
            animator.SetBool("IsRunnning",true);
        }
        else
        {
            animator.SetBool("IsRunnning",false);

        }
    }
    void RotatePlayer()
    {
        Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDirection = mousePosition - rb.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x)* Mathf.Rad2Deg;
        rb.rotation = angle;
    }
    void Shoot()
    {
        Instantiate(bulletPrefabs, firePoint.position, firePoint.rotation);
    }
}
