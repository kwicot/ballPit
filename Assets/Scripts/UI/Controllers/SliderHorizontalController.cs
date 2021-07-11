using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SimpleInputCore.Controllers
{
    public class SliderHorizontalController : InputControllerBase, IBeginDragHandler,IDragHandler,IEndDragHandler
    {
        public GameObject Slider;
        private float left;
        private float right;

        private void Start()
        {
            left = ((GetComponent<RectTransform>().rect.width / 2) - (Slider.GetComponent<RectTransform>().rect.width / 2)) * -1f;
            right = (GetComponent<RectTransform>().rect.width / 2) - (Slider.GetComponent<RectTransform>().rect.width / 2);
        }

        private float horizontal;
        private void Update()
        {
            var h = Slider.GetComponent<RectTransform>().anchorMax;
        }

        private Vector3 startPosition;
        public void OnBeginDrag(PointerEventData eventData)
        {
            startPosition = eventData.position;
        }

        public void OnDrag(PointerEventData eventData)
        {
            var pos = eventData.position;
            var dir = startPosition = pos;


            pos.y = Slider.transform.position.y;
            Slider.transform.position = pos;
            var sliderPos = Slider.transform.localPosition;
            if (Slider.transform.localPosition.x > right) Slider.transform.localPosition = new Vector3(right,sliderPos.y,sliderPos.z);
            if (Slider.transform.localPosition.x < left) Slider.transform.localPosition = new Vector3(left,sliderPos.y,sliderPos.z);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            Slider.transform.localPosition = Vector3.zero;
        }

        public override float GetData()
        {
            var pos = Slider.transform.localPosition;
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