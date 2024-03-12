using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace MVRP.Views
{
    public class PlayerView : MonoBehaviour
    {
        //  テキスト
        [SerializeField] private Text _homeText;
        //  ボタン
        [SerializeField] private Button _testButton;
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

        }
        public void SetText(int t)
        { 
            _homeText.text = t.ToString();;
            //Debug.Log("text");
        }
    }
}

