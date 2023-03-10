using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerCharacterAnimationController : CharacterAnimationControllerBase
{
    private Rigidbody2D playerRigidbody2D;
    private float speedPower = 2.0f;
    [SerializeField]
    private bool isGround = false;
    private float characterUnderPosYDiff = -0.5f;


    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        playerRigidbody2D = this.GetComponent<Rigidbody2D>();

        SetAnimation(Animation_Idle);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        var pos = transform.position;
        pos.y += characterUnderPosYDiff;
        // Cast a ray straight down
        RaycastHit2D[] hits = Physics2D.RaycastAll(pos, Vector2.down, 0.1f);
        if (hits.Count() == 0)
        {
            isGround = false;
            return;
        }
        foreach (var hit in hits)
        {
            if (hit.collider.tag == "Ground")
            {
                if(!isGround)
                { 
                    isGround = true;
                }
                break;
            }    
            else
            {    
                if (isGround)
                {
                    isGround = false;
                }
            }
        }


    }

    void Update()
    {
        // 空中にいる間は何もできない。もしくは降下モーションを出す
        if (!isGround || isAttackAnimation)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetAnimation(Animation_Attack);
            return;
        }

        // 上方向のボタンが押されたら
        if (Input.GetAxis("Vertical") > 0)
        {
            playerRigidbody2D.AddForce(Vector2.up * 8f);
            SetAnimation(Animation_Jump);
            return;
        }

        if (Input.GetAxis("Horizontal") == 0)
        {
            if (isGround)
            {
                playerRigidbody2D.velocity = Vector2.zero;
            }
            SetAnimation(Animation_Idle);
            return;
        }
        else
        {
            SetAnimation(Animation_Walk);
        }

        if (Input.GetAxis("Horizontal") > 0)
        {
            playerRigidbody2D.velocity = Vector2.right * speedPower;
            playerSpriteRenderer.flipX = false;
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            playerRigidbody2D.velocity = Vector2.left * speedPower;
            playerSpriteRenderer.flipX = true;
        }

    }

}
