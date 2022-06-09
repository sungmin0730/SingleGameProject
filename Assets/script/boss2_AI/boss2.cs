using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss2 : MonoBehaviour
{
    public Transform player;
    public float speed;

    public float atkCooltime = 1; //���ݼӵ�
    public float atkDelay;

    public float skillatkCooltime = 10; //���ݼӵ�
    public float skillatkDelay;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (atkDelay >= 0)
            atkDelay -= Time.deltaTime;

        if (skillatkDelay >= 0)
            skillatkDelay -= Time.deltaTime;
    }
}
