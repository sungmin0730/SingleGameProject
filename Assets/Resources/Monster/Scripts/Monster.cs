using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour //, 데미지구조체
{
    [SerializeField]
    public Transform playerTransform;
    public float healthPoint;          // 체력
    public float moveSpeed;            // 이동속도
    public float detectionRange;       // 플레이어 감지범위
    public float attackRange;          // 공격범위
    public float attackDamage;         // 공격력
    public float attackSpeed;          // 공격속도 / attackSpeed = 0.5f then 1초에 두번 공격

    public bool isDetect;
    public bool isAttacking;

    public Animator anim;
    SpriteRenderer sprite;
    int movementFlag; // 0 = stop, 1 = left, 2 = right
    float lastAttackTime;

    public Vector2 dir;

    float distance;

    public GameObject hpBar;
    public GameObject canvas;
    RectTransform hpBarTransform;

    protected virtual void Start()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        lastAttackTime = attackSpeed; // 처음 감지 후 바로 공격하기 위해

        hpBarTransform = Instantiate(hpBar, canvas.transform).GetComponent<RectTransform>();

        StartCoroutine("ChangeMovement");
    }

    protected virtual void Update()
    {
        Detect();
        Move();
        HpBarMove();
        Attack();
    }

    void Move()
    {
        
        Vector3 moveVec = Vector3.zero;

        if (!isDetect)
        {
            moveVec = movementFlag == 1 ? Vector3.left : movementFlag == 2 ? Vector3.right : Vector3.zero;
            sprite.flipX = movementFlag == 1 ? false : movementFlag == 2 ? true : sprite.flipX;
        }
        else
        {
            if (!isAttacking)
            {
                moveVec = dir.x < 0 ? Vector3.left : dir.x > 0 ? Vector3.right : Vector3.zero;
                sprite.flipX = dir.x < 0 ? false : dir.x > 0 ? true : sprite.flipX;
            }
            else
            {
                moveVec = Vector3.zero;
            }
        }
       
        transform.position += moveVec * moveSpeed * Time.deltaTime;
    
    }

    IEnumerator ChangeMovement() // 자유롭게 이동
    {
        while (true)
        {
            movementFlag = Random.Range(0, 3);
            yield return new WaitForSeconds(Random.Range(1f, 3f));
        }
    }

    private void OnDestroy()
    {
        StopCoroutine("ChangeMovement");
    }

    void Detect() // 탐지
    {

        dir = (playerTransform.position - transform.position).normalized;

        if (isAttacking)
        {
            isDetect = true;
            return;
        }

        distance = Vector3.Distance(playerTransform.position, transform.position);
        if (distance <= detectionRange)
        {
            
            int layerMask = (-1) - (1 << LayerMask.NameToLayer("Monster")) - (1 << LayerMask.NameToLayer("MonsterObject"));
            RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, detectionRange, layerMask);
            Debug.DrawRay(transform.position, dir * detectionRange, Color.green, 0);

            if (hit)
            {
                isDetect = hit.collider.tag == "Player";
            }
            else
            {
                isDetect = false;
            }
        }
        else
        {
            isDetect = false;
        }
    }

    void HpBarMove() {
        hpBarTransform.position = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y + 1.75f));
    }

    void Attack()
    {
        lastAttackTime += Time.deltaTime;
        if (isDetect)
        {
            if (!isAttacking && lastAttackTime >= attackSpeed && distance <= attackRange)
            {
                lastAttackTime = 0f;
                StartAttack();
            }
        }
    }
    protected virtual void StartAttack()
    {
        Debug.Log(gameObject.name + " 공격");
    }

    void Die()
    {
        Debug.Log(gameObject.name + " 사망");
        StartCoroutine("StartDead");
    }

    IEnumerator StartDead()
    {
        Color c = sprite.color;

        float alpha = 1f;
        while (alpha > 0f)
        {
            sprite.color = new Color(c.r, c.g, c.b, alpha-=0.01f);
            yield return new WaitForSeconds(0.02f);
        }

        Destroy(gameObject);
    }

}
