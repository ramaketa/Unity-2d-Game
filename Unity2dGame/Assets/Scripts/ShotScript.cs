using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour
{
    // урон
    public int damage = 1;
    // снаряд наносит урон игроку или врагу
    public bool isEnemyShot = false;
    void Start()
    {
        // ограничение времени жизни объекта 20 секунд
        Destroy(gameObject, 20);
    }
}
