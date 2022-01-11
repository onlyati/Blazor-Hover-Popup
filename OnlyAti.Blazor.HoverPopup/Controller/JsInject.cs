using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace OnlyAti.Blazor.HoverPopup.Controller
{
    internal class JsInject : IAsyncDisposable
    {
        private readonly Lazy<Task<IJSObjectReference>> moduleTask;

        public JsInject(IJSRuntime jsRuntime)
        {
            moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
               "import", "./_content/OnlyAti.Blazor.HoverPopup/script.js").AsTask());
        }

        public async Task<int> GetWidth(string id)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<int>("HoverPopupGetWidth", id);
        }

        public async Task<int> GetHeight(string id)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<int>("HoverPopupGetHeight", id);
        }

        public async Task SetWidth(string id, int width)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync("HoverPopupSetWidth", id, width);
        }

        public async Task SetHeight(string id, int height)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync("HoverPopupSetHeight", id, height);
        }

        public async ValueTask DisposeAsync()
        {
            if (moduleTask.IsValueCreated)
            {
                var module = await moduleTask.Value;
                await module.DisposeAsync();
            }
        }
    }
}
