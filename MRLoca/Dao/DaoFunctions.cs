using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRLoca.Dao
{
    public class DaoFunctions : DataAccess
    {
        public DaoFunctions() : base()
        {

        }        public void InsertMessageErreur(string Message)
        {
            try
            {
                string message = Message.ToString().ToString().Trim().Replace("'", " ");
                string sql = "INSERT INTO LogSQL (DateInsert, Error) VALUES (SYSDATETIME(),'" + message + "')";
                this.SetData(sql, null);

            }
            catch (Exception ex)
            {
                ErrorMsg = ex.Message;

            }

        }
    }
}