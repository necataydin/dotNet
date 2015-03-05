using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;



public class VTFunction
{
	public VTFunction()
	{
		
	}

    public SqlConnection connStr()
    {
        SqlConnection connString= new SqlConnection("Data Source=RCPTKSN; Initial Catalog=VTCalisma; Integrated Security=true");
        connString.Open();
        return connString;
    }

    public int cmdSQL( string sqlStr)
    {
        SqlConnection connString = this.connStr();
        SqlCommand cmdSQL = new SqlCommand(sqlStr,connString);
        int cmdSonuc=0;
        try 
	    {	        
		    cmdSonuc= cmdSQL.ExecuteNonQuery();
	    }
	    catch (Exception ex)
	    {
		
		    throw new Exception(ex.Message);
	    }
        cmdSQL.Dispose();
        connString.Close();
        connString.Dispose();
        return cmdSonuc;

    }

    public bool GetBoolExecute(string ProcName, params SqlParameter[] prmtr)
    {
        bool Result = false;
        using (SqlConnection connect = this.connStr())
        {
            using (SqlCommand command = new SqlCommand(ProcName, connect))
            {
                command.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter item in prmtr)
                {
                    command.Parameters.Add(item);
                }
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }
                Result = command.ExecuteNonQuery() > 0 ? true : false;
               
            }
        }
        return Result;
    }

    public DataTable dtTable( string sqlStr )
    {
        SqlConnection connString = this.connStr();
        SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlStr, connString);
        DataTable dataTablo = new DataTable();
        try
        {
            dataAdapter.Fill(dataTablo);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        dataAdapter.Dispose();
        connString.Close();
        connString.Dispose();
        return dataTablo;
    }


}