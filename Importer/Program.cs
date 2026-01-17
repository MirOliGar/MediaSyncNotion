// See https://aka.ms/new-console-template for more information
using CsvHelper;
using DotNetEnv;
using Importer.Models;
using Notion.Client;
using System.Globalization;

Console.WriteLine("Hello, World!");

IEnumerable<GoodreadsEntry> records;

Env.Load();

using (var reader = new StreamReader(Environment.GetEnvironmentVariable("CSV_PATH")))
using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
{
    records = csv.GetRecords<GoodreadsEntry>().ToList();
}

var client = NotionClientFactory.Create(new ClientOptions
{
    AuthToken = Environment.GetEnvironmentVariable("NOTION_ID_TOKEN"),
});


var cosesDatabase = await client.Databases.RetrieveAsync(Environment.GetEnvironmentVariable("COSES_DATABASE_ID"));
var coses = await client.Databases.QueryAsync(Environment.GetEnvironmentVariable("COSES_DATABASE_ID"), new DatabasesQueryParameters());

var goodreadsRecord = records.FirstOrDefault();
var cosaCreateParameters = PagesCreateParametersBuilder
            .Create(new NotionDatabaseParentRequest { DatabaseId = Environment.GetEnvironmentVariable("COSES_DATABASE_ID") })
            .AddProperty("nom",
                new TitlePropertyValue
                {
                    Title = new List<RichTextBase>
                    {
                        new RichTextText { Text = new Text { Content = goodreadsRecord?.Title } }
                    }
                })
            .AddProperty("total",
                new NumberPropertyValue
                {
                    //Number = goodreadsRecord?.NumberOfPages
                })
            .AddProperty("autor/a - artista",
                new RelationPropertyValue
                {
                    Relation = new List<ObjectId> { new ObjectId() }
                })
            .AddProperty("tipus",
                new MultiSelectPropertyValue
                {

                })
            .Build();

await client.Pages.CreateAsync(cosaCreateParameters);

if (goodreadsRecord?.ExclusiveShelf == "to-read")
{
    return;
}
else
{
    var cosesquefemDatabase = await client.Databases.RetrieveAsync("");

    var cosaQueFemCreateParameters = PagesCreateParametersBuilder
                .Create(new NotionDatabaseParentRequest { DatabaseId = cosesquefemDatabase.Id })
                .AddProperty("nom",
                    new TitlePropertyValue
                    {
                        Title = new List<RichTextBase>
                        {
                        new RichTextText { Text = new Text { Content = goodreadsRecord?.Title } }
                        }
                    })
                .AddProperty("estat",
                    new StatusPropertyValue
                    {
                        Status = new StatusPropertyValue.Data() { Name = "" }
                    })
                .AddProperty("persona",
                    new PeoplePropertyValue
                    {
                        People = new List<User> { }
                    })
                .AddProperty("any",
                    new RelationPropertyValue
                    {
                        Relation = new List<ObjectId> { new ObjectId() }
                    })
                .AddProperty("estrelles",
                    new SelectPropertyValue
                    {
                    })
                .Build();

    await client.Pages.CreateAsync(cosaQueFemCreateParameters);
}



Console.WriteLine("jaja the end");