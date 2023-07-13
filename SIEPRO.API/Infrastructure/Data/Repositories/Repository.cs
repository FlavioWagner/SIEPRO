using MongoDB.Bson;
using MongoDB.Driver;
using SIEPRO.API.Infrastructure.Data.Contexts;

namespace SIEPRO.API.Infrastructure.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IMongoCollection<T> _collection;

        public Repository(ISIEPROData dataConfig)
        {
            var client = new MongoClient(dataConfig.ConnectionString);
            var database = client.GetDatabase(dataConfig.DatabaseName);
            var colecao = typeof(T).Name;
            _collection = database.GetCollection<T>(colecao);
        }
        
        private bool GetIdValue(string id, T entity)
        {
            var entityType = typeof(T);
            var idProperty = entityType.GetProperty("Id");
            var idValue = idProperty.GetValue(entity)?.ToString();
            return idValue != null ? idValue == id : false;
        }

        public T Add(T entity)
        {
            _collection.InsertOne(entity);
            return entity;
        }

        public T Get(string id)
        {
            //precisa melhorar
            return (from l in _collection.Find(t => true).ToList()
                    where GetIdValue(id, l)
                    select l).First();
        }

        public IEnumerable<T> GetAll()
        {
            return _collection.Find(t => true).ToList();
        }

        public bool Remove(string id)
        {
            var item = Get(id);
            _collection.DeleteOne(t => t.Equals(item));
            return true;
        }

        public T Update(string id, T entity)
        {
            var item = Get(id);
            var itemProperties = item.GetType().GetProperties();

            var entityType = typeof(T);
            var updates = new Dictionary<string, object>();

            foreach (var itemProp in itemProperties)
            {
                if (itemProp.Name.ToLower() != "id")
                {
                    var entityProperty = entityType.GetProperty(itemProp.Name);
                    if (entityProperty != null)
                    {
                        updates.Add(itemProp.Name, entityProperty.GetValue(entity));
                    }
                }
            }

            // Criar um filtro para identificar o documento a ser atualizado
            var filterDefinition = Builders<T>.Filter.Eq("_id", id);

            // Criar um objeto UpdateDefinitionBuilder
            var updateBuilder = new UpdateDefinitionBuilder<T>();

            // Construir a atualização dinamicamente
            var update = new List<UpdateDefinition<T>>();
            foreach (var kvp in updates)
            {
                var fieldName = kvp.Key;
                var fieldValue = BsonValue.Create(kvp.Value);
                var updateDefinition = updateBuilder.Set(fieldName, fieldValue);
                update.Add(updateDefinition);
            }

            var combine = Builders<T>.Update.Combine(update);

            // Executar a operação de atualização
            var result = _collection.UpdateOne(filterDefinition, combine);

            // Verificar se a atualização foi aplicada com sucesso
            if (result.ModifiedCount > 0)
            {
                return Get(id);
            }
            else
            {
                return null;
            }
        }
    }
}
