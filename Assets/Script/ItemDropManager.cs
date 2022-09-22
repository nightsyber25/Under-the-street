using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropManager : MonoBehaviour
{
    Animator myAni;
    BoxCollider2D myBox;

    void Awake()
    {
        myBox= GetComponent<BoxCollider2D>();
        myAni = GetComponent<Animator>();
        myAni.Play("awake");
    }

    public void EnableBox()
    {
        myBox.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        other.GetComponent<Health>().Heal();
        Destroy(gameObject);
    }
}
