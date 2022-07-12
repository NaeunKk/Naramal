using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 플랫폼따라가게해주세요 : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("PlayerR") || collision.collider.CompareTag("PlayerL"))
        {

        }
    }
}
