using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AppAsesoriasTdeA.database
{

    public class CRUD
    {
        static object locker = new object();

        SQLiteConnection conect;

        public CRUD()
        {
            conect = cone();
            conect.CreateTable<insTable>();
        }


        public SQLite.SQLiteConnection cone()
        {
            try
            {
                SQLiteConnection connectionAUX;
                string nameDataBase = "BDTutorTdea.db3";
                string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                string fullPath = Path.Combine(path, nameDataBase);
                connectionAUX = new SQLite.SQLiteConnection(fullPath);
                return connectionAUX;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }

        public int save(insTable register)
        {
            lock (locker)
            {
                if (register.ID == 0)
                {
                    return conect.Insert(register);
                }
                else
                {
                    return 0;
                }
            }
        }

        public insTable SelectOne(string UsName, string Pass)
        {
            lock (locker)
            {
                return conect.Table<insTable>().FirstOrDefault(x => x.USERNAME == UsName && x.PASSWORD == Pass);
            }
        }

        public insTable SelectOneById(int j)
        {
            lock (locker)
            {
                return conect.Table<insTable>().FirstOrDefault(x => x.ID == j);
            }
        }

        public IEnumerable<insTable> SelectAll()
        {
            lock (locker)
            {
                return (from i in conect.Table<insTable>() select i).ToList();
            }
        }

        public int Update(insTable register)
        {
            lock (locker)
            {
                if (register.ID != 0)
                {
                    return conect.Update(register);
                }
                else
                {
                    return 0;
                }
            }
        }

        public int Delete(insTable register)
        {
            lock (locker)
            {
                if (register.ID != 0)
                {
                    return conect.Delete(register);
                }
                else
                {
                    return 0;
                }
            }
        }

    }
}