using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    // префаб снаряда для стрельбы
    public Transform shotPrefab;
    // время перезарядки в секундах
    public float shootingRate = 0.25f;

    // перезарядка
    private float shootCooldown;
    void Start()
    {
        shootCooldown = 0.0f;
    }
    void Update()
    {
        if (shootCooldown > 0.0f)
        {
            shootCooldown -= Time.deltaTime;
        }
    }
    // создание нового снаряда если это возможно
    public void Attack(bool isEnemy)
    {
        if (CanAttack)
        {
            shootCooldown = shootingRate;
            // создаем новый выстрел
            var shotTransform = Instantiate(shotPrefab) as Transform;
            shotTransform.position = transform.position;
            // свойство врага
            ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
            if (shot != null)
                shot.isEnemyShot = isEnemy;
            MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
            if (move != null)
                move.direction = this.transform.right;
        }
    }
    // готов ли новый снаряд
    public bool CanAttack
    {
        get
        {
            return shootCooldown <= 0.0f;
        }
    }

}
