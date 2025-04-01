using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CosmicCuration.Bullets
{
    public class BulletPool
    {
        private BulletView bulletView;
        private BulletScriptableObject bulletScriptableObject;
        private List<PooledBullet> bulletsPool = new List<PooledBullet>();


        public class PooledBullet
        {
            public BulletController bulletController;
            public bool isUsed;
        }

        public BulletPool(BulletView bulletView, BulletScriptableObject bulletScriptableObject)
        {
            this.bulletView = bulletView;
            this.bulletScriptableObject = bulletScriptableObject;
        }

        public BulletController GetBullet()
        {
            if (bulletsPool.Count > 0)
            {
                PooledBullet bulletPool = bulletsPool.Find(item => !item.isUsed);
                if (bulletPool != null) 
                {
                    bulletPool.isUsed = true;
                    return bulletPool.bulletController;
                }
            }
            return CreateBulletController();
        }


        private BulletController CreateBulletController()
        {
            PooledBullet bullet = new PooledBullet();
            bullet.bulletController = new BulletController(bulletView, bulletScriptableObject);
            bullet.isUsed = true;
            bulletsPool.Add(bullet);
            return bullet.bulletController;
        }

        public void ReturnBulletToPool(BulletController bulletController)
        {
            PooledBullet bullet = bulletsPool.Find(item => item.Equals(bulletController));
            if (bullet != null)
            {
                bullet.isUsed = false;
            }
        }

    }
}

