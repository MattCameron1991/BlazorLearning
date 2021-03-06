#pragma checksum "C:\Users\The Void Box\Documents\GitHub\BlazorLearning\BlazorLearningToDo\Client\Pages\Index.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "25e681949870b25b9d284e1e3dbcdca4cecbf518"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace BlazorLearningToDo.Client.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\The Void Box\Documents\GitHub\BlazorLearning\BlazorLearningToDo\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\The Void Box\Documents\GitHub\BlazorLearning\BlazorLearningToDo\Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\The Void Box\Documents\GitHub\BlazorLearning\BlazorLearningToDo\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\The Void Box\Documents\GitHub\BlazorLearning\BlazorLearningToDo\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\The Void Box\Documents\GitHub\BlazorLearning\BlazorLearningToDo\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\The Void Box\Documents\GitHub\BlazorLearning\BlazorLearningToDo\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\The Void Box\Documents\GitHub\BlazorLearning\BlazorLearningToDo\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\The Void Box\Documents\GitHub\BlazorLearning\BlazorLearningToDo\Client\_Imports.razor"
using BlazorLearningToDo.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\The Void Box\Documents\GitHub\BlazorLearning\BlazorLearningToDo\Client\_Imports.razor"
using BlazorLearningToDo.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\The Void Box\Documents\GitHub\BlazorLearning\BlazorLearningToDo\Client\Pages\Index.razor"
using Microsoft.AspNetCore.SignalR.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\The Void Box\Documents\GitHub\BlazorLearning\BlazorLearningToDo\Client\Pages\Index.razor"
using BlazorLearningToDo.Shared;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Index : Microsoft.AspNetCore.Components.ComponentBase, IDisposable
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 48 "C:\Users\The Void Box\Documents\GitHub\BlazorLearning\BlazorLearningToDo\Client\Pages\Index.razor"
 
	private string LoggedInUser;
	private string loggingInUser;

	public void SignIn()
	{
		LoggedInUser = loggingInUser;
	}
	public void SignOut()
	{
		LoggedInUser = string.Empty;
	}

	private HubConnection hubConnection;
	private List<ChatMessage> messages = new List<ChatMessage>();
	private string messageInput;
	private bool hasReceivedServer;

	protected override async Task OnInitializedAsync()
	{
		hubConnection = new HubConnectionBuilder()
			.WithUrl(NavigationManager.ToAbsoluteUri("/chathub"))
			.Build();

		hubConnection.On<string, string>("ReceiveMessage", (user, message) =>
		{
			messages.Add(new ChatMessage
			{
				User = user,
				Content = message
			});
			StateHasChanged();
		});

		hasReceivedServer = false;
		hubConnection.On<ChatMessage[]>("ReceiveServerState", stateMessageList =>
		{
			if (hasReceivedServer) return;
			hasReceivedServer = true;

			messages.AddRange(stateMessageList);
			StateHasChanged();
		});

		await hubConnection.StartAsync();

		await hubConnection.SendAsync("FetchState");
	}

	async Task Send()
	{
		await hubConnection.SendAsync("SendMessage", LoggedInUser, messageInput);
		messageInput = string.Empty;
	}

	public bool IsConnected =>
		hubConnection.State == HubConnectionState.Connected;

	public void Dispose()
	{
		_ = hubConnection.DisposeAsync();
	}

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
    }
}
#pragma warning restore 1591
