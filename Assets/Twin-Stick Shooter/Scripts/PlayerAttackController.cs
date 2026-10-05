using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerController))]
public class PlayerAttackController : MonoBehaviour
{
    PlayerController m_playerController;

    public GameObject m_bulletPrefab;
    public float m_attackSpeed;
    Vector3 aimPosition;
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

        if (m_fireMode == m_FireMode.SemiAuto)

        if (m_attackTimer > 0)
            m_attackTimer -= Time.deltaTime;
    }

    void PlayerInput()
    {
        aimPosition.z = 0;

        Vector3 aimDirection = aimPosition.normalized;
       
        if (aimPosition != Vector3.zero)
        {
            SpawnBullet(aimDirection);
        }
        
        
                
    }

    public void OnAttack(InputValue value)
    {
        aimPosition = value.Get<Vector2>();
    }

    void SpawnBullet(Vector3 aimDirection)
    {
        print(transform.position);

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