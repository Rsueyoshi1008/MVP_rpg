using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVRP.Models
{
    public class CameraControl : MonoBehaviour
    {
        float yaw = 0.0f;
        float pitch = 0.0f;
        float sensitivity;// マウスのセンシ
        // Start is called before the first frame update
        void Start()
        {
            
        }
    
        
        void Update()
        {
            Vector3 temporaryPosition = transform.position;//   現在の位置を取得
            
            if(Cursor.visible == false)//   カーソル表示時にカメラ操作の停止
            {
                // マウスの入力を取得する
                float mouseX = Input.GetAxis("Mouse X") * sensitivity;
                float mouseY = Input.GetAxis("Mouse Y") * sensitivity;
    
                // Y軸の回転量を計算する
                yaw += mouseX;
                // X軸の回転量を計算する（上下方向の回転を制限する）
                pitch -= mouseY;
    
                pitch = Mathf.Clamp(pitch, -90f, 90f); // 上下方向の回転を制限する
    
                // カメラの回転を適用する
                transform.eulerAngles = new Vector3(pitch, yaw, 0f);
                
            }
            transform.position = new Vector3(temporaryPosition.x,1.0f,temporaryPosition.z);//   高さのみ固定
    
            
        }
    
        //  設定したマウスセンシの同期  //
        public void SyncMouseSensitivity(float _mouseSensitivity)
        {
            sensitivity = _mouseSensitivity;
            
        }
        public void GetCursorVisibility(bool _isCursor)
        {
            Cursor.visible = _isCursor;
        }
    }
}

