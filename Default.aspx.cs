using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;
public partial class _Default : System.Web.UI.Page
{
    gmyodersprog islemler = new gmyodersprog();
    SqlConnection baglanti = new SqlConnection(WebConfigurationManager.ConnectionStrings["db_connection"].ToString());
    SqlCommand komut = new SqlCommand();
    SqlDataReader oku;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["yetki"] == null) Response.Redirect("../Default.aspx");

        if (Session.Count < 0)
        {
            Response.Redirect("~/Default.aspx");
        }
        else
        {
            if (Session["yetki"] == "Kordinatör")
            {
                if (!Page.IsPostBack)
                {
                    kullaniciadi();
                    isim.InnerHtml = "Hoş Geldiniz," + " <br /> " + Session["adisoyadi"].ToString();
                    isim1.InnerText = Session["unvan"].ToString() + " " + Session["adisoyadi"].ToString();
                    isim2.InnerText = isim1.InnerText = Session["unvan"].ToString() + " " + Session["adisoyadi"].ToString();
                    duyurulistele();
                }

            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }
    }

    public void kullaniciadi()
    {
        string kad = "";
        komut.CommandText = "select  kullanicilar.kad, unvanlar.unvan_adi, ogretmenler.ad + ' ' + ogretmenler.soyad as 'adsoyad' from kullanicilar ";
        komut.CommandText += "inner join ogretmenler on kullanicilar.ogretmenId = ogretmenler.id ";
        komut.CommandText += "inner join unvanlar on unvanlar.Uid = (select Uid from unvanlar where Uid=ogretmenler.unvan) ";
        komut.CommandText += " where kullanicilar.kad = '" + Session["kordinatorkadi"] + "'";
        komut.Connection = baglanti;
        baglanti.Open();
       
        oku = komut.ExecuteReader();
        while (oku.Read())
        {
            Session["kad1"] = oku[0].ToString();
            Session["unvan"] = oku[1].ToString();
            Session["adisoyadi"] = oku[2].ToString();
            kad = oku[1].ToString();
        }
        baglanti.Close();
        
    }
    public void duyurulistele()
    {

        try
        {
            komut = new SqlCommand("Select * from duyurular order by kayit_tarihi desc", baglanti);

            duyuru.InnerHtml = "";
            baglanti.Open();

            oku = komut.ExecuteReader();
            while (oku.Read())
            {
                DateTime tarih = Convert.ToDateTime(oku[3].ToString());


                if (tarih < DateTime.Now.AddDays(-7))
                {
                    duyuru.InnerHtml += "<div class=\"col-md-4\"><div class=\"box box-info\"> <div class=\"box-header\"> <h3 class=\"box-title\">" + oku[1].ToString() + "</h3>";
                    duyuru.InnerHtml += "<div class=\"box-tools pull-right\"><div class=\"label bg-aqua\">" + oku[3].ToString().Substring(0, 10) + "</div></div></div>";
                    if (oku[2].ToString().Length > 240)
                    {
                        duyuru.InnerHtml += "<div class=\"box-body\">" + oku[2].ToString().Substring(0, 240) + "..." + "</div>";
                    }
                    else
                    {
                        duyuru.InnerHtml += "<div class=\"box-body\">" + oku[2].ToString() + "..." + "</div>";
                    }
                    duyuru.InnerHtml += "<div class=\"box-footer\"> <code><a href=\"#duyuru\" onClick=\"window.open('../Duyurular/DuyuruOku.aspx?duyuru=" + oku[0].ToString() + "', '', 'width=500, height=600')\">Devamını Oku</a></code> </div> </div> </div>";

                   // duyuru.InnerHtml += "<div class=\"left\"><a href=\"\"><img src=\"../images/forms/icon_plus.gif\" width=\"21\" height=\"21\" alt=\"\" /></a></div>";
                }
                else
                {
                   // duyuru.InnerHtml += "<div class=\"left\"><a href=\"\"><img src=\"../images/forms/icon_plus_red.gif\" width=\"21\" height=\"21\" alt=\"\" /></a></div>";

                    duyuru.InnerHtml = "<div class=\"col-md-4\"><div class=\"box box-info\"> <div class=\"box-header\"> <h3 class=\"box-title\">" + oku[1].ToString() + "</h3>";
                    duyuru.InnerHtml += "<div class=\"box-tools pull-right\"><div class=\"label bg-red\">Yeni - " + oku[3].ToString().Substring(0, 10) + "</div></div></div>";
                    duyuru.InnerHtml += "<div class=\"box-body\">" + oku[2].ToString() + "..." + "</div>";
                    duyuru.InnerHtml += "<div class=\"box-footer\"> <code><a href=\"#duyuru\" onClick=\"window.open('../Duyurular/DuyuruOku.aspx?duyuru=" + oku[0].ToString() + "', '', 'width=500, height=600')\">Devamını Oku</a></code> </div> </div> </div>";

                }


                //duyuru.InnerHtml += "<div class=\"right\">" + "<h5>" + oku[1].ToString() + " - " + oku[3].ToString().Substring(0, 10) + "</h5> " + "<br />";
                //if (oku[2].ToString().Length > 75)
                //{
                //    duyuru.InnerHtml += oku[2].ToString().Substring(0, 74) + "...";
                //}
                //else
                //{
                //    duyuru.InnerHtml += oku[2].ToString();
                //}
                //duyuru.InnerHtml += "<ul class=\"greyarrow\">" + "<br />";
                //duyuru.InnerHtml += "<li><a href=\"#duyuru\" onClick=\"window.open('../Duyurular/DuyuruOku.aspx?duyuru=" + oku[0].ToString() + "', '', 'width=1050, height=%100')\">Devamını okumak için tıklayın</a></li>" + "</ul></div>";
                //duyuru.InnerHtml += "<div class=\"clear\"></div>";
                //duyuru.InnerHtml += "<div class=\"lines-dotted-short\"></div>";
            }
            baglanti.Close();
        }
        catch (Exception hata) { duyuru.InnerHtml = hata.ToString(); }
    }

}