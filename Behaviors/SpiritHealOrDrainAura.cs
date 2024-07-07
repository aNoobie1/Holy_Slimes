using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using ModdedIds;

namespace HolySlimes.Behaviors
{
    public class SpiritHealOrDrainAura : SRBehaviour
    {
        public void ChangeHP(int val)
        {
            playerState.model.currHealth = playerState.model.currHealth + val;
            if (playerState.model.currHealth >= playerState.model.maxHealth)
            {
                playerState.model.currHealth = playerState.model.maxHealth;
            }

        }
        public void Awake()
        {
            ResetDamageAmnesty();
        }
        public void Start()
        {
            playerState = SRSingleton<SceneContext>.Instance.PlayerState;
            player = SRSingleton<SceneContext>.Instance.Player;
            emotions = transform.parent.GetComponent<SlimeEmotions>();
            StartCoroutine("Random");
        }
        public void ResetDamageAmnesty()
        {
            nextTime = Time.time + 0.1f;
        }
        IEnumerator Random()
        {
            while (true)
            {
                if (randomize)
                {
                    if (emotions.model.emotionAgitation.currVal == 1f)
                    {
                        mode = (HealDrainMode)UnityEngine.Random.Range(-1, 1);
                    }
                    else
                    {
                        mode = (HealDrainMode)UnityEngine.Random.Range(-1, 2);
                    }
                }
                yield return new WaitForSeconds(10f);
            }

        }
        public void OnTriggerEnter(Collider col)
        {
            if (Time.time >= nextTime && col.gameObject == player)
            {
                TryToHealOrDrain(col.gameObject);
            }
        }
        public void OnTriggerStay(Collider col)
        {
            if (Time.time >= nextTime && col.gameObject == player)
            {
                TryToHealOrDrain(col.gameObject);
            }
        }
        public void OnTriggerExit(Collider col)
        {
            if (col.gameObject == player && mode == HealDrainMode.DRAIN)
            {
                playerState.Damage(1, gameObject);
            }
        }
        public void TryToHealOrDrain(GameObject gameObj)
        {
            int num;
            if (mode == HealDrainMode.DRAIN)
            {
                num = -Mathf.CeilToInt(health);
            }
            else if (mode == HealDrainMode.HEAL)
            {
                num = Mathf.CeilToInt(health);
            }
            else
            {
                num = 0;
            }
            ChangeHP(num);
            nextTime = Time.time + repeatTime;
            if (playerState.GetCurrHealth() <= 0)
            {
                DeathHandler.Kill(gameObj, DeathHandler.Source.SLIME_ATTACK, base.gameObject, "SpiritHealOrDrainAura.TryToHealOrDrain");
            }
        }
        public float health = 100f;
        public float repeatTime;
        private float nextTime;
        private SlimeEmotions emotions;
        private PlayerState playerState;
        private GameObject player;
        internal HealDrainMode mode;
        internal bool randomize = true;
    }
}
