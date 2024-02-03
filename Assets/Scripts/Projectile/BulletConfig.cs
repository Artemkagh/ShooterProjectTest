using UnityEngine;

namespace Projectile
{
    [CreateAssetMenu(fileName = "New BulletConfig", menuName = "Bullet Config", order = 51)]
    public class BulletConfig : ScriptableObject
    {
        [SerializeField] private string bulletName;
        [SerializeField] private string description;
        [SerializeField] private BulletType type;
        [SerializeField] private int damage;
        [SerializeField] private Color bulletColor;

        public string BulletName => bulletName;

        public string Description => description;

        public BulletType Type=>  type;

        public int Damage => damage;

        public Color BulletColor => bulletColor;
    }
}
