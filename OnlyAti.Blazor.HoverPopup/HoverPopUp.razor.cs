using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using OnlyAti.Blazor.HoverPopup.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlyAti.Blazor.HoverPopup
{
    public partial class HoverPopUp : ComponentBase
    {
        /// <summary>
        /// That render fragment which is normally displayed
        /// </summary>
        [Parameter]
        public RenderFragment? NormalDisplay { get; set; } 

        /// <summary>
        /// That render fragment which is displayed when mouse was over on NormalDisplay fragement
        /// </summary>
        [Parameter]
        public RenderFragment? PopupDisplay { get; set; }

        /// <summary>
        /// Javascript runtime from DI
        /// </summary>
        [Parameter]
        public IJSRuntime? JSRuntime { get; set; }

        private bool ShowPopup = false;
        private int left, top;
        private string normalId = Guid.NewGuid().ToString();
        private string popupId = Guid.NewGuid().ToString();

        private async void DisplayPopup(MouseEventArgs e)
        {
            if (JSRuntime == null)
                throw new ArgumentNullException("JSRuntime");

            JsInject HandleJS = new(JSRuntime);

            int normalWidth = await HandleJS.GetWidth(normalId);
            int normalHeight = await HandleJS.GetHeight(normalId);

            ShowPopup = true;
            StateHasChanged();

            int popupWidth = await HandleJS.GetWidth(popupId);
            int popupHeight = await HandleJS.GetHeight(popupId);

            if(popupWidth < normalWidth)
            {
                await HandleJS.SetWidth(popupId, normalWidth);
                left = 0;
            }
            else
                left = (normalWidth - popupWidth) / 2;

            if(popupHeight < normalHeight)
            {
                await HandleJS.SetHeight(popupId, normalHeight);
                top = 0;
            }
            else
                top = (normalHeight - popupHeight) / 2;

            StateHasChanged();
        }
    }
}
