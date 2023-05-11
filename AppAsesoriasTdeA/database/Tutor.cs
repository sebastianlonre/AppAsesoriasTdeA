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
        public string TitleTutor { get; set; }

        public string TextTutor { get; set; }

        public int InsTableId { get; set; }
    }
}