using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotekarz.Common.CommunicationModel;
public class GetBooksResponse
{
    public List<BookDto> Books { get; set; }
}

public class BookDto
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Author { get; set; }

    public int PageCount { get; set; }

    public bool IsBorrowed { get; set; }

    public string? BorrowerFirstName { get; set; }
    public string? BorrowerLastName { get; set; }
}