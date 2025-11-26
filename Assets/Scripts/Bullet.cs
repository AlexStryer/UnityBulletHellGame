using UnityEngine;

public class Bullet : MonoBehaviour
{
    private const float MAX_LIFE_TIME = 3f;
    private float _lifeTime = 0f;
    public Vector2 Velocity;

    public static int ActiveBulletCount { get; private set; }

    private void OnEnable()
    {
        ActiveBulletCount++;
    }

    private void OnDisable()
    {
        ActiveBulletCount--;
    }

    private void Update()
    {
        transform.position += (Vector3)Velocity * Time.deltaTime;
        _lifeTime += Time.deltaTime;

        if (_lifeTime > MAX_LIFE_TIME)
            Disable();
    }

    private void Disable()
    {
        _lifeTime = 0f;
        gameObject.SetActive(false);
    }
}