using SQLite;

namespace AppAsesoriasTdeA.database
{
    public class Tutor
    {
        public Tutor()
        {

        }

        //TABLE ATRIBUTES

        [PrimaryKey, AutoIncrement]

        public int IDTutor { get; set; }
        public string className { get; set; }

        public string classDescription { get; set; }

        public string classClock { get; set; }

        public int InsTableId { get; set; }
    }
}