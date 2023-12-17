using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    Vector2 direction;
    [Header("Movimentação")]
    [Tooltip("Estas variáveis serão utilizadas para movimentação")]
    [SerializeField]
    [Range(2.0f, 15.0f)]
    private float velocity = 5.0f;

    [Header("Movimentação")]
    [SerializeField]
    private Rigidbody2D rig;

    [Header("Animação")]
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private SpriteRenderer spt;

    [Header("Pulo")]
    [SerializeField]
    [Range(2.0f, 15.0f)]
    float jumpForce = 7.0f;
    bool isJumping;
    [SerializeField]
    private float groundCheckRadius;
    [SerializeField]
    private LayerMask whatIsGround;
    private bool isGround;
    [SerializeField]
    private Transform rayCastCheck;

    [SerializeField]
    bool hasWeapon = false;
    private bool isShoot = false;

    public int countCoins = 0;
    public Text coinText;
    public Text countLifesText;
    public int countLifes = 3;

    public Image weapomImage;
    void Start()
    {
        anim = GetComponent<Animator>();
        spt = GetComponent<SpriteRenderer>();
        this.isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {

        isGround = Physics2D.Raycast(rayCastCheck.position, Vector2.down, groundCheckRadius, whatIsGround).collider != null;
        //print(isGround);
        direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (!hasWeapon)
        {
            NormalMove();
        }
        else
        {
            WeaponMove();
            if (Input.GetButtonDown("Fire1") && !isShoot)
            {
                float timeAnimation = Shooting();
                print(timeAnimation);
                Invoke(nameof(VoltarAtaque), timeAnimation);
            }
        }
    }

    public void TakeDamage()
    {
        countLifes--;
        countLifesText.text = countLifes.ToString();
    }
    public void SetWeapon()
    {
        hasWeapon = true;
        weapomImage.gameObject.SetActive(true);

    }
    public void SetCountCoin()
    {
        countCoins++;
        coinText.text = countCoins.ToString();
    }
    private float Shooting()
    {
        isShoot = true;
        anim.Play("MariaShoot");
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        return stateInfo.length;
    }
    public void VoltarAtaque()
    {
        isShoot = false;
        print("Alterou isShoot");
    }
    private void WeaponMove()
    {
        if (direction.x > 0)
        {
            if (isGround && !isShoot)
            {
                spt.flipX = false;
                anim.Play("MariaWalkingWeapon");
            }
        }
        else if (direction.x < 0)
        {
            if (isGround && !isShoot)
            {
                spt.flipX = true;
                anim.Play("MariaWalkingWeapon");
            }
        }
        else if (direction.x == 0 && !isShoot)
        {
            if (isGround)
            {
                anim.Play("MariaIdleWeapon");
            }
        }

        if (Input.GetButtonDown("Jump") && isGround)
        {
            isJumping = true;
        }
        if (!isGround && !isShoot)
        {
            anim.Play("MariaJumpWeapon");
        }
    }

    private void NormalMove()
    {
        if (direction.x > 0)
        {
            if (isGround)
            {
                spt.flipX = false;
                anim.Play("MariaWalking");
            }
        }
        else if (direction.x < 0)
        {
            if (isGround)
            {
                spt.flipX = true;
                anim.Play("MariaWalking");
            }
        }
        else if (direction.x == 0)
        {
            if (isGround)
            {
                anim.Play("MariaIdle");
            }
        }

        if (Input.GetButtonDown("Jump") && isGround)
        {
            isJumping = true;
        }
        if (!isGround)
        {
            anim.Play("MariaJump");
        }
    }
    private void FixedUpdate()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        rig.velocity = new Vector2(direction.x * velocity, rig.velocity.y);
    }

    private void Jump()
    {
        if (isJumping)
        {
            rig.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumping = false;
        }
    }
}
