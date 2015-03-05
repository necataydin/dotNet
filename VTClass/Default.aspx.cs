using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    VTFunction vtIslemleri = new VTFunction();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        vtIslemleri.cmdSQL("update Uyeler set AdSoyad='Lezgin Basaran' where ID=1");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        DataTable dtTbl= vtIslemleri.dtTable("select * from Uyeler");
        for (int i = 0; i < dtTbl.Rows.Count; i++)
        {
            DataRow dtRow = dtTbl.Rows[i];
            Response.Write(dtRow["AdSoyad"].ToString() + "<br />");
            
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        string adSoyad = "", ePosta = "", psw = "";
        adSoyad = TextBox1.Text;
        ePosta = TextBox2.Text;
        psw = TextBox3.Text;
        if (adSoyad != "" && ePosta != "" & psw != "")
        {
            SqlCommand cmdSQL = new SqlCommand();
            SqlParameter prmAd = new SqlParameter("@ADI",adSoyad);
            SqlParameter prmEmail = new SqlParameter("@EMAIL", ePosta);
            SqlParameter prmSifre = new SqlParameter("@SIFRE", psw);

            vtIslemleri.GetBoolExecute("UYE_Insert", prmAd, prmEmail, prmSifre);

            
            
        }
    }
}