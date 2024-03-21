using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace MVRP.Models
{
    public sealed class PlayerModel : MonoBehaviour
    {
        [SerializeField] private Transform door;
        [SerializeField] private Rigidbody rb;
        /// <summary>
        /// 体力
        /// ReactivePropertyとして外部に状態をReadOnlyで公開
        /// </summary>
        public IReadOnlyReactiveProperty<int> Health => _health;
        private readonly IntReactiveProperty _health = new IntReactiveProperty(100);

        public IReadOnlyReactiveProperty<bool> IsCursor => _isCursor;// カーソル表示の監視
        private readonly BoolReactiveProperty _isCursor = new BoolReactiveProperty(false);
        bool isOpenDoor = false;//  viewの扉開閉ボタンの監視
        float maxRotationAngle = 180f;//    ドアが開く上限
        float moveSpeed = 5.0f;//   Playerの移動速度

        bool lockOpeningDoor = false;// ドアの開閉可能を監視

        void Start()
        {
            //  カーソルの固定、非表示
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            _isCursor.Value = Cursor.visible;
        }
        void Update()
        {
            float inputHorizontal = Input.GetAxis("Horizontal");
            float inputVertical = Input.GetAxis("Vertical");
            Move(inputHorizontal,inputVertical);
            
            if(lockOpeningDoor == true)
            {
                if(Input.GetKeyDown(KeyCode.E))
                {
                    //  ドアを開け閉めする
                    OpeningAndClosingDoors();
                    
                }
            }
            
            //  回転ボタンが押されたら    //
            //OpeningAndClosingDoors();
            
            
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                //  カーソルの表示、非表示を行う    //
                ChangeCursorVisible();
            }
            
        }

        public void OpenDoor(bool _isOpenDoor)
        {
            isOpenDoor = _isOpenDoor;
            
        }

        public void Move(float _inputHorizontal,float _inputVertical)
        {
            Vector3 moveMent = new Vector3(_inputHorizontal,0.0f,_inputVertical) * moveSpeed * Time.deltaTime;
            transform.Translate(moveMent); 
        }

        public void OpeningAndClosingDoors()
        {
            if(isOpenDoor == true)
            {
                //  ドアが180度以上回転しないための制限
                if(door.rotation.eulerAngles.y < maxRotationAngle)
                {
                    door.rotation *= Quaternion.Euler(0, Time.deltaTime * 50, 0); // ドアを開ける回転
                }
                
            }
            else
            {
                if(door.rotation.eulerAngles.y != 0.0f)//   開始時に自動で閉じるのを防ぐ
                {
                    if(door.rotation.eulerAngles.y < 359.0f)//  ドアが必要以上に閉じていくのを制限する
                    {
                        door.rotation *= Quaternion.Euler(0, Time.deltaTime * -50, 0); // ドアを閉める回転
                        
                    }
                    else door.rotation = Quaternion.Euler(0.0f,0.0f,0.0f);//    扉が閉じた後に初期値に戻す
                }
                
                
            }
        }

        public void ChangeCursorVisible()
        {
            if(Cursor.visible == false)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                _isCursor.Value = Cursor.visible;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                _isCursor.Value = Cursor.visible;
            }
        }

        /// <summary>
        /// 衝突イベント
        /// </summary>
        private void OnTriggerEnter(Collider collision)
        {
            // ドアの開閉を可能にする
            if (collision.gameObject.tag == "Door")
            {
                lockOpeningDoor = true;
            }
            Debug.Log("SSSS");
        }
        private void OnCollisionExit(Collision collision)
        {
            if(collision.gameObject.tag == "Door")
            {
                lockOpeningDoor = false;
            }
            Debug.Log("DDDDD");
        }

        private void OnDestroy()
        {
            _health.Dispose();
        }
    }
}

