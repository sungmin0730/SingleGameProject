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
        //���� ü���� damage ��ŭ ����
        currentHP -= damage;

        StopCoroutine("HitColorAnimation");
        StartCoroutine("HitColorAnimation");
        if (currentHP <= 0)
        {
            // ü�� 0�϶� Die() �Լ� �ִ°�
        }

    }
    private IEnumerator HitColorAnimation()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.05f);
        spriteRenderer.color = Color.white;
    }
}
