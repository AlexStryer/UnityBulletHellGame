using UnityEngine;
using TMPro;

public class BulletCounterUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counterText;

    private void Update()
    {
        _counterText.text = "Bullets: " + Bullet.ActiveBulletCount;
    }
}