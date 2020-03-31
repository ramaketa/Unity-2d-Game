using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    // 1 - скорость объекта
    public Vector2 speed = new Vector2(7, 7);
    // 2 - направление движения
    public Vector2 direction = new Vector2(-1, 0);
    private Rigidbody2D rb2d;
    private Vector2 movement;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        // перемещение
        movement = new Vector2(
        speed.x * direction.x,
        speed.y * direction.y);
    }
    void FixedUpdate()
    {
        // применить движение к rigidbody
        rb2d.velocity = movement;
    }
}
