using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace DatabaseCommunicator.Model
{
    public partial class EzkoEntities
    {
        public EzkoEntities(string connectionString)
            : this(new SqlConnection(connectionString), true)
        {

        }
        
        public EzkoEntities(SqlConnection connection, bool contextOwnsConnection)
            : base(new EntityConnection(new MetadataWorkspace(new string[] { "res://*/" }, new List<Assembly>() { Assembly.GetExecutingAssembly() }), connection), contextOwnsConnection)
        {

        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }
    }
}
