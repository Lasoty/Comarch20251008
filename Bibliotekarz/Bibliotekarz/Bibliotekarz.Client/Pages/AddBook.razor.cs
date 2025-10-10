using Bibliotekarz.Common.CommunicationModel;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Net.Http.Json;

namespace Bibliotekarz.Client.Pages;

public partial class AddBook
{
    private MudForm? form;
    private UpdateBookRequest Model = new()
    {
        BorrowerFirstName = string.Empty,
        BorrowerLastName = string.Empty
    };
    private bool loading;
    private string? errorMessage;

    [Inject]
    public HttpClient Http { get; set; }

    [Parameter]
    public int? Id { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        try
        {
            var response = await Http.GetFromJsonAsync<BookDto>("Books/Get/" + Id);

            Model = new UpdateBookRequest
            {
                Id = response.Id,
                Author = response.Author,
                Title = response.Title,
                PageCount = response.PageCount,
                IsBorrowed = response.IsBorrowed,
                BorrowerFirstName = response.BorrowerFirstName,
                BorrowerLastName = response.BorrowerLastName
            };


        }
        catch (Exception ex)
        {
            Snackbar.Add($"Wystąpił błąd podczas pobierania książki o ID: {Id}!", Severity.Error);
        }
        StateHasChanged();
    }

    private void BorrowedChanged(bool value)
    {
        Model.IsBorrowed = value;
        if (!value)
        {
            Model.BorrowerFirstName = string.Empty;
            Model.BorrowerLastName = string.Empty;
        }
    }

    private async Task SubmitAsync()
    {
        errorMessage = null;

        // Ręczna walidacja podstawowa (brak DataAnnotations w modelu).
        if (string.IsNullOrWhiteSpace(Model.Title))
        {
            errorMessage = "Pole Tytuł jest wymagane.";
            return;
        }
        if (Model.PageCount < 1)
        {
            errorMessage = "Liczba stron musi być >= 1.";
            return;
        }
        if (Model.IsBorrowed)
        {
            if (string.IsNullOrWhiteSpace(Model.BorrowerFirstName) ||
                string.IsNullOrWhiteSpace(Model.BorrowerLastName))
            {
                errorMessage = "Imię i nazwisko wypożyczającego są wymagane.";
                return;
            }
        }
        else
        {
            Model.BorrowerFirstName = null;
            Model.BorrowerLastName = null;
        }

        loading = true;
        try
        {
            var response = await Http.PostAsJsonAsync("/Books/Add", Model);

            if (response.IsSuccessStatusCode)
            {
                Snackbar.Add("Książka została dodana.", Severity.Success);
                Reset();
            }
            else
            {
                var serverMsg = await response.Content.ReadAsStringAsync();
                errorMessage = $"Błąd zapisu: {serverMsg}";
            }
        }
        catch (Exception ex)
        {
            errorMessage = $"Wyjątek: {ex.Message}";
        }
        finally
        {
            loading = false;
        }
    }

    private void Reset()
    {
        Model = new UpdateBookRequest
        {
            BorrowerFirstName = string.Empty,
            BorrowerLastName = string.Empty,
            IsBorrowed = false,
            PageCount = 1
        };
        errorMessage = null;
        form?.ResetAsync();
        StateHasChanged();
    }
}
