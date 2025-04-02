using System.Collections.Generic;
using CosmicCuration.Utilities;

namespace CosmicCuration.Bullets
{
    public class BulletPool : GenericObjectPool<BulletController>
    {
        private BulletView bulletPrefab;
        private BulletScriptableObject bulletSO;

        public BulletPool(BulletView bulletPrefab, BulletScriptableObject bulletSO)
        {
            this.bulletPrefab = bulletPrefab;
            this.bulletSO = bulletSO;
        }

        public BulletController GetBullet() => GetObject();

        protected override BulletController CreateObject() => new (bulletPrefab, bulletSO);

        public void ReturnBullet(BulletController bullet) => ReturnObjectToPool(bullet);
    }
}