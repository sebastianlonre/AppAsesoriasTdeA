//AGG SQLITE
using SQLite;

namespace AppAsesoriasTdeA.database
{
    //IT MUST BE PUBLIC
    public class insTable
    {

        //CREATE OBJECT
        public insTable()
        {

        }

        //TABLE ATRIBUTES

        [PrimaryKey, AutoIncrement]

        public int ID { get; set; }
        public string USERNAME { get; set; }

        public string EMAIL { get; set; }

        public string PASSWORD { get; set; }

    }
}