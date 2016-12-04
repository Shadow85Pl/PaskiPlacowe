using System.Data.Entity;

namespace PaskiPlacowe.Model
{
    public partial class Entities : DbContext
    {
        public Entities(string ConnectionString) : base(ConnectionString)
        {

        }
    }
}
