using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseController : MonoBehaviour
{ 
    /*
     oluşturulan evin kapısına box collider yerleştrildi.
    player collider içinde olduğunu tespit etmek için OnTriggerEnter2D fonksiyonu oluşturuldu
     */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if(player != null)
        {
            GameManager.Instance.LoadScene();
           // SceneManager.LoadScene(0);
        }
    }
}
