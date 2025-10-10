using Bibliotekarz.Common.CommunicationModel;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Net.Http.Json;

namespace Bibliotekarz.Client.Pages;

public partial class BookList
{
    List<BookDto> _books = [];

    [Inject]
    public HttpClient Client { get; set; }

    [Inject]
    NavigationManager? Navigation { get; set; }


    protected override async Task OnParametersSetAsync()
    {
        var response = await Client!.GetFromJsonAsync<GetBooksResponse>("/Books/Get");
        _books = response!.Books;
    }
    private void OnDodajClicked(MouseEventArgs args)
    {
        Navigation!.NavigateTo("add-book");
    }

    private void OnEditClick(int id)
    {
        Navigation!.NavigateTo("add-book/" + id);
    }
}
