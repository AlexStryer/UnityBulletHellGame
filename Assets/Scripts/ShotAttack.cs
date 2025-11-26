using UnityEngine;

public static class ShotAttack
{
    public static void SimpleShot(Vector2 origin, Vector2 velocity)
    {
        Bullet bullet = BulletPool.Instance.RequestBullet();
        bullet.transform.position = origin;
        bullet.Velocity = velocity;
    }

    public static void RadialShot(Vector2 origin, Vector2 aimDirection, RadialShotSettings settings)
    {
        float angleBetweenBullets = 360f / settings.NumberOfBullets;

        if (settings.AngleOffset != 0f || settings.PhaseOffset != 0f)
            aimDirection = aimDirection.Rotate(settings.AngleOffset + (settings.PhaseOffset * angleBetweenBullets));

        for (int i = 0; i < settings.NumberOfBullets; i++)
        {
            float bulletDirectionAngle = angleBetweenBullets * i;
            Vector2 bulletDirection = aimDirection.Rotate(bulletDirectionAngle);
            SimpleShot(origin, bulletDirection * settings.BulletSpeed);
        }
    }

    public static void StarShot(Vector2 origin, Vector2 aimDirection, RadialShotSettings settings, bool offsetPhase)
    {
        float angleBetweenBullets = 360f / settings.NumberOfBullets;

        // if offsetPhase = true, shift everything half a step (like the second “layer” of the star)
        float baseOffset = offsetPhase ? angleBetweenBullets / 2f : 0f;

        if (settings.AngleOffset != 0f || settings.PhaseOffset != 0f)
            aimDirection = aimDirection.Rotate(settings.AngleOffset + (settings.PhaseOffset * angleBetweenBullets));

        for (int i = 0; i < settings.NumberOfBullets; i++)
        {
            float bulletDirectionAngle = baseOffset + angleBetweenBullets * i;
            Vector2 bulletDirection = aimDirection.Rotate(bulletDirectionAngle);
            SimpleShot(origin, bulletDirection * settings.BulletSpeed);
        }
    }

}
