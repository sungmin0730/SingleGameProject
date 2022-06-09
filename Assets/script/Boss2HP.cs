using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2HP : MonoBehaviour
{
    [SerializeField]
    private float maxHP = 600;
    private float currentHP;
    private SpriteRenderer spriteRenderer;

    public float MaxHP => maxHP;
    public float CurrentHP => currentHP;
    // Start is called before the first frame update
    void Awake()
    {
        currentHP = maxHP;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void TakeDamage(float damage)
    {
        //현재 체력을 damage 만큼 감소
        currentHP -= damage;

        StopCoroutine("HitColorAnimation");
        StartCoroutine("HitColorAnimation");
        if (currentHP <= 0)
        {
            // 체력 0일때 Die() 함수 넣는곳
        }

    }
    private IEnumerator HitColorAnimation()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.05f);
        spriteRenderer.color = Color.white;
    }
}
