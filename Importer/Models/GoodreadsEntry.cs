// See https://aka.ms/new-console-template for more information
using CsvHelper.Configuration.Attributes;

namespace Importer.Models
{
    public class GoodreadsEntry
    {
        [Name("Book Id")]
        public string BookId { get; set; }

        [Name("Title")]
        public string Title { get; set; }

        [Name("Author")]
        public string Author { get; set; }

        [Name("Author l-f")]
        public string Authorlf { get; set; }

        [Name("Additional Authors")]
        public string Additional { get; set; }

        [Name("ISBN")]
        public string ISBN { get; set; }

        [Name("ISBN13")]
        public string ISBN13 { get; set; }

        [Name("My Rating")]
        public string MyRating { get; set; }

        [Name("Average Rating")]
        public string AverageRating { get; set; }

        [Name("Publisher")]
        public string Publisher { get; set; }

        [Name("Binding")]
        public string Binding { get; set; }

        [Name("Number of Pages")]
        public string NumberOfPages { get; set; }

        [Name("Year Published")]
        public string YearPublished { get; set; }

        [Name("Original Publication Year")]
        public string OriginalPublicationYear { get; set; }

        [Name("Date Read")]
        public string DateRead { get; set; }

        [Name("Date Added")]
        public string DateAdded { get; set; }

        [Name("Bookshelves")]
        public string Bookshelves { get; set; }

        [Name("Bookshelves with positions")]
        public string BookshelvesWithPositions { get; set; }

        [Name("Exclusive Shelf")]
        public string ExclusiveShelf { get; set; }

        [Name("My Review")]
        public string MyReview { get; set; }

        [Name("Spoiler")]
        public string Spoiler { get; set; }

        [Name("Private Notes")]
        public string PrivateNotes { get; set; }

        [Name("Read Count")]
        public string ReadCount { get; set; }

        [Name("Owned Copies")]
        public string OwnedCopies { get; set; }
    }
}