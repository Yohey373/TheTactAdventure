using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacterAnimationController : CharacterAnimationControllerBase
{
    private SpriteRenderer enemySpriteRenderer;

    private Rigidbody2D enemyRigidbody2D;

    private float speedPower = 1.8f;

    public EnemyPlayerSearch EnemyPlayerSearch;
    
    // Start is called before the first frame update
    void Start()
    {
        // Ž©•ª‚ÌSpriteRenderer‚ÌŽæ“¾
        enemySpriteRenderer = this.GetComponent<SpriteRenderer>();
        enemyRigidbody2D = this.GetComponent<Rigidbody2D>();

        SetAnimation(Animation_Idle);
    }

    // Update is called once per frame
    void Update()
    {
        if (!EnemyPlayerSearch.IsSearchPlayer)
        {
            SetAnimation(Animation_Idle);
            return;
        }
        if (EnemyPlayerSearch.PlayerCharacterDistance <0)
        {
            enemyRigidbody2D.velocity = Vector2.right * speedPower;
            SetAnimation(Animation_Walk);
            enemySpriteRenderer.flipX = false;
        }
        else
        {
            enemyRigidbody2D.velocity = Vector2.left * speedPower;
            SetAnimation(Animation_Walk);
            enemySpriteRenderer.flipX = true;
        }
    }
}
