using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;
namespace MVRP.Views
{
    public class SettingView : MonoBehaviour
    {
        [SerializeField] private Slider mouseSensitivitySlider;

        public IReadOnlyReactiveProperty<float> Sensitivity => _sensitivity;
        private readonly FloatReactiveProperty _sensitivity = new FloatReactiveProperty(0.0f);
        // Start is called before the first frame update
        void Start()
        {
            mouseSensitivitySlider.onValueChanged.AddListener(delegate { OnSliderValueChanged(); });
            mouseSensitivitySlider.value = 1.0f;
        }

        // Update is called once per frame
        void Update()
        {

        }
        // Sliderの値が変更されたときに呼び出される関数
        void OnSliderValueChanged()
        {
            // Sliderの値をログに表示する
            _sensitivity.Value = mouseSensitivitySlider.value;
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

