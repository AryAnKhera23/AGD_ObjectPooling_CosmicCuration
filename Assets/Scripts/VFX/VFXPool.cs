using CosmicCuration.Utilities;
using UnityEngine.Pool;

namespace CosmicCuration.VFX
{
    public class VFXPool : GenericObjectPool<VFXController>
    {
        private VFXView vfxPrefab;
        
        public VFXController GetVFX(VFXView vfxPrefab)
        {
            this.vfxPrefab = vfxPrefab;
            return GetItem<VFXController>();
        }

        protected override VFXController CreateItem<T>() => new (vfxPrefab);
    }
}