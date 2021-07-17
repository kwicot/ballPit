using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SimpleInputCore.Controllers
{
    public class SliderHorizontalController : InputControllerBase,IDragHandler,IEndDragHandler
    {
        public GameObject Slider;
        private float left;
        private float right;


        private RectTransform _sliderRect;
        private RectTransform _rectTransform;

        private void Start()
        {
            _sliderRect = Slider.GetComponent<RectTransform>();
            _rectTransform = GetComponent<RectTransform>();
            right = (_rectTransform.rect.width / 2) - (_sliderRect.rect.width / 2);
            left = right * -1f;
        }

        private float horizontal;

        public void OnDrag(PointerEventData eventData)
        {
            var mousePos = eventData.position;
            mousePos.y = Slider.transform.position.y;
            Slider.transform.position = mousePos;
            var sliderPos = Slider.transform.localPosition;

            if (Slider.transform.localPosition.x > right) Slider.transform.localPosition = new Vector3(right,sliderPos.y,sliderPos.z);
            if (Slider.transform.localPosition.x < left) Slider.transform.localPosition = new Vector3(left,sliderPos.y,sliderPos.z);
            
            
            Debug.Log($"Mouse position- {mousePos} \n Slider position- {sliderPos} \n Slider localPosition- {Slider.transform.localPosition}" +
                      $"\n Slider rect position- {_sliderRect.position} \n Slider rect local position- {_sliderRect.localPosition}" );
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            Slider.transform.localPosition = Vector3.zero;
        }

        public override float GetData()
        {
            var pos = Slider.GetComponent<RectTransform>().anchoredPosition;
            if (pos.x > 0)
            {
                var h = pos.x / right;
                return h;
            }
            else if (pos.x < 0)
            {
                var h = pos.x / left;
                return h * -1f;
            }
            else return 0;
        }
    }
}