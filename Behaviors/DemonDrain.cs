using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace HolySlimes.Behaviors
{
    public class DemonDrain : SRBehaviour, ControllerCollisionListener
    {
        public void DrainHP(int val)
        {
            playerState.model.currHealth = playerState.model.currHealth - val;

        }
        public void Awake()
        {
            ResetDamageAmnesty();
        }
        public void Start()
        {
            playerState = SRSingleton<SceneContext>.Instance.PlayerState;
            player = SRSingleton<SceneContext>.Instance.Player;
            emotions = GetComponent<SlimeEmotions>();
        }
        public void ResetDamageAmnesty()
        {
            nextTime = Time.time + 0.1f;
        }
        public void OnCollisionEnter(Collision col)
        {
            if (Time.time >= nextTime && col.gameObject == player)
            {
                TryToDrain(col.gameObject);
            }
        }
        public void OnControllerCollision(GameObject gameObj)
        {
            if (Time.time >= nextTime && gameObj == player)
            {
                TryToDrain(gameObj);
            }
        }
        public void OnCollisionExit(Collision col)
        {
            if (col.gameObject == player)
            {
                playerState.Damage(1, gameObject);
            }
        }
        public void TryToDrain(GameObject gameObj)
        {
            int num;
            if (emotions.model.emotionAgitation.currVal == 1f)
            {
                num = Mathf.CeilToInt(Time.deltaTime * health * 2);
            }
            else
            {
                num = Mathf.CeilToInt(Time.deltaTime * health);
            }
            if (num > 0)
            {
                DrainHP(num);
            }
            nextTime = Time.time + repeatTime;
            if (playerState.GetCurrHealth() <= 0)
            {
                DeathHandler.Kill(gameObj, DeathHandler.Source.SLIME_ATTACK, base.gameObject, "DemonDrain.TryToDrain");
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
