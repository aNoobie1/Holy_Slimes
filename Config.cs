using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRML.Config.Attributes;
namespace HolySlimes
{
    [ConfigFile("particles", "PARTICLES")]
    public class ParticleConfig
    {
        public static readonly bool SHOW_PARTICLES_INBETWEEN = true;
        public static readonly bool SHOW_PARTICLES_HEAVEN = true;
        //public static readonly bool SHOW_PARTICLES_HADES = true;
    }

    public class ConfigUpdater : SRSingleton<ConfigUpdater> 
    {
        public bool particlesINBprev;
        public bool particlesHVprev;
        public bool particlesHDprev;

        public void Update()
        {
            if (particlesINBprev != ParticleConfig.SHOW_PARTICLES_INBETWEEN)
            {
                UpdateParticleStateINB();
                particlesINBprev = ParticleConfig.SHOW_PARTICLES_INBETWEEN;
            }
        }
        private void UpdateParticleStateINB()
        {
            Zones.inbetweenEffects.Item1.SetActive(ParticleConfig.SHOW_PARTICLES_INBETWEEN);
            Zones.inbetweenEffects.Item2.SetActive(ParticleConfig.SHOW_PARTICLES_INBETWEEN);
        }
    
    }
}
