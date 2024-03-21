using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UniRx;
namespace MVRP.Views
{
    public class PlayerView : MonoBehaviour
    {
        //  テキスト
        [SerializeField] private Text _homeText;
        //  ボタン
        [SerializeField] private Button _testButton;

        public IReadOnlyReactiveProperty<bool> OnTestButton => _onTestButton;
        private readonly BoolReactiveProperty _onTestButton = new BoolReactiveProperty(false);

        public UnityAction testEvent;
        bool isHidden;
        void Start()
        {
            _testButton.onClick.AddListener(OnClickTest);
        }

        // Update is called once per frame
        void Update()
        {
            
            
        }
        public void OnClickTest()
        {
            _onTestButton.Value = !_onTestButton.Value;
            //Debug.Log(_onTestButton.Value);
        }
        public void SetText(int t)
        { 
            _homeText.text = t.ToString();;
            //Debug.Log("text");
        }
        //  カーソルの表示に合わせてUI表示  //
        public void GetCursorVisibility(bool _isCursor)
        {
            if(_isCursor == true)
            {
                gameObject.SetActive(true);
            }
            else gameObject.SetActive(false);
        }
    }
}

