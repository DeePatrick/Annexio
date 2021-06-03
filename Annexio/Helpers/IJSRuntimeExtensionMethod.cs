using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Annexio.Helpers
{
    public static class IJSRuntimeExtensionMethod
    {
        public static async ValueTask<bool> Confirm(this IJSRuntime js, string message)
        {
            return await js.InvokeAsync<bool>("confirm", message);
        }


        public static async ValueTask ConsoleLog(this IJSRuntime js, string message)
        {
            await js.InvokeVoidAsync("console.log", message);
        }


        public static async ValueTask Alert(this IJSRuntime js, string message)
        {
            await js.InvokeVoidAsync("alert", message);
        }

    }
}
