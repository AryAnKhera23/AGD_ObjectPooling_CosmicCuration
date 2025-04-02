using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.Enemy
{
    public class EnemyPool
    {
        private EnemyView enemyView;
        private EnemyScriptableObject enemyScriptableObject;
        private List<PooledEnemy> enemiesPool = new List<PooledEnemy>();

        public class PooledEnemy
        {
            public EnemyController enemyConntroller;
            public bool isUsed;
        }

        public EnemyPool(EnemyView enemyView, EnemyScriptableObject enemyScriptableObject)
        {
            this.enemyView = enemyView;
            this.enemyScriptableObject = enemyScriptableObject;
        }

        public EnemyController GetEnemy()
        {
            if(enemiesPool.Count > 0)
            {
                PooledEnemy enemy = enemiesPool.Find(item => !item.isUsed);
                if (enemy != null)
                {
                    enemy.isUsed = true;
                    return enemy.enemyConntroller;
                }
            }
            return CreateEnemy();
        }

        private EnemyController CreateEnemy()
        {
            PooledEnemy newEnemy = new PooledEnemy();
            newEnemy.enemyConntroller = new EnemyController(enemyView, enemyScriptableObject.enemyData);
            newEnemy.isUsed = true;
            enemiesPool.Add(newEnemy);
            return newEnemy.enemyConntroller;
        }

        public void ReturnToEnemyPool(EnemyController enemyController)
        {
            PooledEnemy enemy = enemiesPool.Find(item => item.Equals(enemyController));
            if (enemy != null)
            {
                enemy.isUsed = false;
            }
        }
    }
}