using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int LifeMax = 100;

    public Sprite SpritePortrait;

    public SpriteRenderer Visual;

    public int Life = 100;

    public Animator Animator;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void Attack(Character defender)
    {
        Animator.SetTrigger("Attack");
        defender.hit();
    }

    internal void hit()
    {
        Animator.SetTrigger("Hit");
    }
}
