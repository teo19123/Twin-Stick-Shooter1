using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerAttackController : MonoBehaviour
{
    PlayerController m_playerController;

    public GameObject m_bulletPrefab;
    public float m_attackSpeed;

    float m_attackTimer;

    public enum m_FireMode
    {
        SemiAuto,
        FullAuto
    }

    public m_FireMode m_fireMode;

    void Start()
    {
        m_playerController = GetComponent<PlayerController>();
    }

    void Update()
    {
        PlayerInput();

        if (m_attackTimer > 0)
            m_attackTimer -= Time.deltaTime;
    }

    void PlayerInput()
    {
        Vector3 aimPosition =
            Camera.main.ScreenToWorldPoint(Input.mousePosition);

        aimPosition.z = 0;

        Vector3 aimDirection =
            (aimPosition - transform.position).normalized;

        if (m_fireMode == m_FireMode.SemiAuto)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                SpawnBullet(aimDirection);
            }
        }
        else if (m_fireMode == m_FireMode.FullAuto)
        {
            if (Input.GetKey(KeyCode.Mouse0) && m_attackTimer <= 0)
            {
                SpawnBullet(aimDirection);

                m_attackTimer = m_attackSpeed;
            }
        }
    }

    void SpawnBullet(Vector3 aimDirection)
    {
        GameObject bullet = Instantiate(
            m_bulletPrefab,
            transform.position,
            Quaternion.identity
        );

        var bC = bullet.GetComponent<BulletController>();

        bC.m_direction = aimDirection;
        bC.m_damage = m_playerController.m_attackDamage;
    }
}