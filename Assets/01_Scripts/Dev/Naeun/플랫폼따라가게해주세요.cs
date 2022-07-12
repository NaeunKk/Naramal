using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 플랫폼따라가게해주세요 : MonoBehaviour
{
<<<<<<< HEAD
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
=======
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("PlayerR") || collision.collider.CompareTag("PlayerL"))
        {

        }
>>>>>>> e576fd37775dc95fdac017103bf0c5853818328d
    }
}
