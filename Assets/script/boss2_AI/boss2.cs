using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss2 : MonoBehaviour
{
    public Transform player;
    public float speed;

    public float atkCooltime = 1; //공격속도
    public float atkDelay;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (atkDelay >= 0)
            atkDelay -= Time.deltaTime;
    }
}
