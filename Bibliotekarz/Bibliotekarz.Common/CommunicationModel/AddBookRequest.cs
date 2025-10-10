using System.ComponentModel;

namespace Bibliotekarz.Common.CommunicationModel;

public class AddBookRequest : INotifyPropertyChanged
{
    private bool isBorrowed;

    public string Title { get; set; } = null!;

    public string? Author { get; set; }

    public int PageCount { get; set; }

    public bool IsBorrowed
    {
        get => isBorrowed;
        set
        {
            isBorrowed = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsBorrowed)));
        }
    }

    public string? BorrowerFirstName { get; set; }

    public string? BorrowerLastName { get; set; }

    public event PropertyChangedEventHandler? PropertyChanged;
}

public class UpdateBookRequest : AddBookRequest
{
    public int Id { get; set; }
}