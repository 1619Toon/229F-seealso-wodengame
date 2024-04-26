using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndDoor : MonoBehaviour

{
    // ฉากที่ต้องการโหลดเมื่อผู้เล่นชนกับประตูชนะเกม
    [SerializeField] private string endSceneName = "EndScene";

    // เมื่อมีการชนกันกับประตูชนะเกม
    private void OnTriggerEnter2D(Collider2D other)
    {
        // ตรวจสอบว่าวัตถุที่ชนกันมี Tag เป็น "Player" หรือไม่
        if (other.CompareTag("Player"))
        {
            // โหลดฉาก "EndScene"
            SceneManager.LoadScene(endSceneName);
        }
    }
}


