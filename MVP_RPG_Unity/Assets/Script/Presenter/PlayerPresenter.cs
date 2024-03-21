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
        //  SettingView
        [SerializeField] private SettingView _settingView;
        //  CameraModel
        [SerializeField] private CameraControl _cameraControl;

        private void Start()
        {
            // PlayerのHealthを監視
            _playerModel.Health.Subscribe(x =>{_playerView.SetText((int)x);}).AddTo(this);
            
            //  Viewの扉回転ボタンを監視
            _playerView.OnTestButton.Subscribe(x =>{_playerModel.OpenDoor((bool)x);}).AddTo(this);
            
            //  マウスセンシ設定値の監視
            _settingView.Sensitivity.Subscribe(x => {_cameraControl.SyncMouseSensitivity((float)x);}).AddTo(this);

            //  カーソル表示の監視
            _playerModel.IsCursor.Subscribe(x => {_cameraControl.GetCursorVisibility((bool)x);}).AddTo(this);
            _playerModel.IsCursor.Subscribe(x => {_playerView.GetCursorVisibility((bool)x);}).AddTo(this);
            _playerModel.IsCursor.Subscribe(x => {_settingView.GetCursorVisibility((bool)x);}).AddTo(this);
        }
    }
}

