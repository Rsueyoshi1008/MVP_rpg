using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVRP.Models;
using MVRP.Views;
using UniRx;
namespace MVRP.Presenter
{
    public sealed class PlayerPresenter : MonoBehaviour
    {
        //  view
        [SerializeField] private PlayerView _playerView;
        //  model
        [SerializeField] private PlayerModel _playerModel;

        private void Start()
        {
            // PlayerのHealthを監視
            _playerModel.Health
                .Subscribe(x =>
                {
                    // Viewに反映
                    _playerView.SetText((int)x);
                }).AddTo(this);
        }
    }
}

