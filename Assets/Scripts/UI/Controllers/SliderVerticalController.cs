using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace SimpleInputCore.Controllers
{
    public class SliderVerticalController : InputControllerBase, IDragHandler, IEndDragHandler
    {
        public GameObject Slider;
        public UnityEvent OnDropAction;

        public enum SliderStartPostions
        {
            Up,
            Center,
            Down
        }

        public SliderStartPostions sliderStartPostion;


        private Vector3 SliderZeroPosition;
        private float Down;
        private float Up;

        private void Start()
        {
            var rect = Slider.GetComponent<RectTransform>();
            Down = ((GetComponent<RectTransform>().rect.height / 2) -
                    (Slider.GetComponent<RectTransform>().rect.height / 2)) * -1f;
            Up = (GetComponent<RectTransform>().rect.height / 2) -
                 (Slider.GetComponent<RectTransform>().rect.height / 2);
            switch (sliderStartPostion)
            {
                case SliderStartPostions.Up:
                {
                    SliderZeroPosition = new Vector3(0, Up, 0);

                    var size = rect.rect.height / 2;
                    var r = (GetComponent<RectTransform>().rect.height - size) /
                            GetComponent<RectTransform>().rect.height;
                    rect.anchorMax = new Vector2(0.5f, r);
                    rect.anchorMin = new Vector2(0.5f, r);
                    break;
                }
                case SliderStartPostions.Center:
                {
                    SliderZeroPosition = new Vector3(0, 0, 0);
                    break;
                }
                case SliderStartPostions.Down:
                {
                    SliderZeroPosition = new Vector3(0, Down, 0);



                    var size = rect.rect.height / 2;
                    var r = size / GetComponent<RectTransform>().rect.height;
                    rect.anchorMax = new Vector2(0.5f, r);
                    rect.anchorMin = new Vector2(0.5f, r);



                    break;
                }
            }

        }

        private float vertical;

        private void Update()
        {
        }


        public void OnDrag(PointerEventData eventData)
        {
            var pos = eventData.position;


            pos.x = Slider.transform.position.x;
            Slider.transform.position = pos;
            var sliderPos = Slider.transform.localPosition;
            if (Slider.transform.localPosition.y > Up)
                Slider.transform.localPosition = new Vector3(sliderPos.x, Up, sliderPos.z);
            if (Slider.transform.localPosition.y < Down)
                Slider.transform.localPosition = new Vector3(sliderPos.x, Down, sliderPos.z);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            Slider.transform.localPosition = SliderZeroPosition;
            OnDropAction?.Invoke();
        }

        public override float GetData()
        {
            var pos = Slider.GetComponent<RectTransform>().anchoredPosition;
            if (pos.y > 0)
            {
                var h = pos.y / Up;
                return h;
            }
            else if (pos.y < 0)
            {
                var h = pos.y / Down;
                return h * -1f;
            }
            else return 0;
        }
    }


}