using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace MVRP.Models
{
    public sealed class PlayerModel : MonoBehaviour
    {
        /// <summary>
        /// 体力
        /// ReactivePropertyとして外部に状態をReadOnlyで公開
        /// </summary>
        public IReadOnlyReactiveProperty<int> Health => _health;
        private readonly IntReactiveProperty _health = new IntReactiveProperty(100);

        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Y))
            {
                //Debug.Log("Yキークリック");
                _health.Value -= 10;
                
            }
        }

        /// <summary>
        /// 衝突イベント
        /// </summary>
        private void OnCollisionEnter(Collision collision)
        {
            // Enemyに触れたら体力を減らす
            // if (collision.gameObject.TryGetComponent<Enemy>(out var _))
            // {
            //     _health.Value -= 10;
            // }
        }

        private void OnDestroy()
        {
            _health.Dispose();
        }
    }
}

