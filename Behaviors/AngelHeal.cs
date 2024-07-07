using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace HolySlimes.Behaviors
{
    public class AngelHeal : SRBehaviour
    {
        public void HealHP(int val)
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
        }
        public void ResetDamageAmnesty()
        {
            nextTime = Time.time + 0.1f;
        }
        public void OnTriggerEnter(Collider col)
        {
            if (Time.time >= nextTime && col.gameObject == player)
            {
                TryToHeal(col.gameObject);
            }
        }
        public void OnTriggerStay(Collider col)
        {
            if (Time.time >= nextTime && col.gameObject == player)
            {
                TryToHeal(col.gameObject);
            }
        }
        public void TryToHeal(GameObject gameObj)
        {
            int num = Mathf.CeilToInt(health);
            if (num > 0)
            {
                HealHP(num);
            }
            if (emotions.model.emotionAgitation.currVal == 1f)
            {
                nextTime = Time.time + (repeatTime * 2);
            }
            else
            {
                nextTime = Time.time + repeatTime;
            }
        }
        public float health = 100f;
        public float repeatTime;
        private float nextTime;
        private SlimeEmotions emotions;
        private PlayerState playerState;
        private GameObject player;
    }
}
