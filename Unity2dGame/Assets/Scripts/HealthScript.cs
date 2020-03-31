using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    // всего хитпоинтов
    public int hp = 1;
    // враг или игрок
    public bool isEnemy = true;
    // наносим урон и проверяем, должен ли объект быть уничтожен
    public void Damage(int damageCount)
    {
        hp -= damageCount;
        if (hp <= 0)
        {
            SoundEffectsHelper.Instance.MakeExplosionSound();
            Destroy(gameObject);
        }
    }

    // обработчик столкновения
    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        // это выстрел?
        ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();
        if (shot != null)
        {
            // избегаем дружественного огня
            if (shot.isEnemyShot != isEnemy)
            {
                Damage(shot.damage);
                // уничтожить выстрел
                Destroy(shot.gameObject);
            }
        }
    }
}
