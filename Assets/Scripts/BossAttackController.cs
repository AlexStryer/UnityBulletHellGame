using System.Collections;
using UnityEngine;

public class BossAttackController : MonoBehaviour
{
    [Header("Global")]
    [SerializeField] private float _attackDuration = 10f;
    [SerializeField] private float _timeBetweenAttacks = 1.5f;

    [Header("Attack 1 - Basic circle")]
    [SerializeField] private RadialShotSettings _attack1Settings;
    [SerializeField] private float _attack1Cooldown = 0.7f;

    [Header("Attack 2 - Rotating star")]
    [SerializeField] private RadialShotSettings _attack2Settings;
    [SerializeField] private float _attack2Cooldown = 0.4f;

    [Header("Attack 3 - Spiral stream")]
    [SerializeField] private RadialShotSettings _attack3Settings;
    [SerializeField] private float _spiralStepCooldown = 0.08f;
    [SerializeField] private float _spiralAngleStep = 10f;

    private void Start()
    {
        StartCoroutine(AttackLoop());
    }

    private IEnumerator AttackLoop()
    {
        while (true)
        {
            yield return StartCoroutine(RunRadialAttack(_attack1Settings, _attack1Cooldown));
            yield return new WaitForSeconds(_timeBetweenAttacks);

            yield return StartCoroutine(RunStarAttack(_attack2Settings, _attack2Cooldown));
            yield return new WaitForSeconds(_timeBetweenAttacks);

            yield return StartCoroutine(RunSpiralAttack(_attack3Settings, _spiralStepCooldown, _spiralAngleStep));
            yield return new WaitForSeconds(_timeBetweenAttacks);
        }
    }

    private IEnumerator RunRadialAttack(RadialShotSettings settings, float cooldown)
    {
        float elapsed = 0f;

        while (elapsed < _attackDuration)
        {
            ShotAttack.RadialShot(transform.position, transform.up, settings);
            yield return new WaitForSeconds(cooldown);
            elapsed += cooldown;
        }
    }

    private IEnumerator RunStarAttack(RadialShotSettings settings, float cooldown)
    {
        float elapsed = 0f;
        bool offsetPhase = false;

        while (elapsed < _attackDuration)
        {
            ShotAttack.StarShot(transform.position, transform.up, settings, offsetPhase);
            offsetPhase = !offsetPhase;
            yield return new WaitForSeconds(cooldown);
            elapsed += cooldown;
        }
    }

    private IEnumerator RunSpiralAttack(RadialShotSettings settings, float stepCooldown, float angleStep)
    {
        float elapsed = 0f;
        float currentAngle = 0f;

        while (elapsed < _attackDuration)
        {
            float rad = currentAngle * Mathf.Deg2Rad;
            Vector2 dir = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));

            ShotAttack.SimpleShot(transform.position, dir * settings.BulletSpeed);

            currentAngle += angleStep;
            yield return new WaitForSeconds(stepCooldown);
            elapsed += stepCooldown;
        }
    }
}