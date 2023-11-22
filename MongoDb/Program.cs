using MongoDB.Bson;
using MongoDB.Driver;

internal class Program
{
    private static void Main(string[] args)
    {
        string connectionString = "mongodb://localhost:27017"; // Coloque sua string de conexão do MongoDB aqui
        string databaseName = "CarlosTeste"; // Nome do seu banco de dados
        string collectionName = "Itens"; // Nome da coleção

        // Criando uma instância do cliente MongoDB
        var client = new MongoClient(connectionString);

        // Acessando o banco de dados
        var database = client.GetDatabase(databaseName);

        // Acessando a coleção "itens"
        var collection = database.GetCollection<BsonDocument>(collectionName);

        // Criando um filtro para a sua seleção (pode ser vazio para selecionar tudo)
        var filter = Builders<BsonDocument>.Filter.Empty;

        // Realizando a seleção
        var itens = collection.Find(filter).ToList();

        // Exibindo os resultados
        foreach (var item in itens)
        {
            Console.WriteLine(item.ToJson());
        }
    }
}