using UnityEngine;

namespace CosmicCuration.VFX
{
    public class VFXView : MonoBehaviour
    {
        private VFXController controller;
        private ParticleSystem vfx;

        public void SetController(VFXController controllerToSet) => controller = controllerToSet;

        public void ConfigureAndPlay(Vector2 positionToSet)
        {
            transform.position = positionToSet;
            vfx = GetComponent<ParticleSystem>();
            gameObject.SetActive(true);
        }

        private void Update()
        {
            if (vfx is not null && vfx.isStopped)
                    gameObject.SetActive(false);
                    GameService.Instance.GetVFXService().ReturnVFXToPool(controller);
        }
    }
}