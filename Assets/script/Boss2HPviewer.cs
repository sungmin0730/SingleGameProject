using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss2HPviewer : MonoBehaviour
{
    [SerializeField]
    private Boss2HP boss2HP;
    private Slider sliderHP;
    // Start is called before the first frame update
    void Awake()
    {
        sliderHP = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        sliderHP.value = boss2HP.CurrentHP / boss2HP.MaxHP;
    }
}
