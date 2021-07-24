using System;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace UnityEngine.UI
{
    /// <summary>
    /// Simple toggle -- something that has an 'on' and 'off' states: checkbox, toggle button, radio button, etc.
    /// </summary>
    [AddComponentMenu("UI/Toggle Button", 32)]
    [RequireComponent(typeof(RectTransform))]
    public class ToggleButton : Toggle
    {
        public Color CheckedColor = Color.white;


        protected virtual void InternalToggle()
        {
            if (!IsActive() || !IsInteractable())
                return;

            isOn = !isOn;

            if (isOn) StartColorTween(this.CheckedColor, false);
        }

        /// <summary>
        /// React to clicks.
        /// </summary>
        public override void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button != PointerEventData.InputButton.Left)
                return;

            InternalToggle();
        }

        public override void OnSubmit(BaseEventData eventData)
        {
            InternalToggle();
        }

        private void StartColorTween(Color targetColor, bool instant)
        {
            if (this.image == null) return;
            var graphic = this.image as Graphic;

            graphic.CrossFadeColor(targetColor, instant ? 0f : 1f, true, true);
        }
    }
}
