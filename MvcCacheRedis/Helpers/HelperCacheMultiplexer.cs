using StackExchange.Redis;

namespace MvcCacheRedis.Helpers
{
    public class HelperCacheMultiplexer
    {
        //CLASE PARA PROPORCIONARNOS LA CADENA DE CONEXION. DEBE DE SER STATIC
        private static Lazy<ConnectionMultiplexer> CreateConnection =
            new Lazy<ConnectionMultiplexer>(() =>
            {
                string cnn = "bbddproductoscachentc.redis.cache.windows.net:6380,password=gt0XfKbXSYYAvn4w7oIX5EmruQWkdK6jCAzCaOAFpVc=,ssl=True,abortConnect=False";
                return ConnectionMultiplexer.Connect(cnn);
            });

        public static ConnectionMultiplexer GetConnection
        {
            get
            {
                return CreateConnection.Value;
            }
        }
    }
}
