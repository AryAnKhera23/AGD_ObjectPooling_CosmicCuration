using System.Collections.Generic;
using CosmicCuration.Utilities;
using UnityEngine.Pool;

namespace CosmicCuration.Enemy
{
    public class EnemyPool : GenericObjectPool<EnemyController>
    {
        private EnemyView enemyPrefab;
        private EnemyData enemyData;

        public EnemyPool(EnemyView enemyPrefab, EnemyData enemyData)
        {
            this.enemyPrefab = enemyPrefab;
            this.enemyData = enemyData;
        }

        protected override EnemyController CreateObject() => new (enemyPrefab, enemyData);

        public EnemyController GetEnemy() => GetObject();
        public void ReturnEnemy(EnemyController enemy) => ReturnObjectToPool(enemy);
    }
}
