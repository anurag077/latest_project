﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Configuration; 

public partial class site_Default4 : System.Web.UI.Page
{
    string str;
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        str = "select isnull(max(ID),0)+1 from regtable";
        DataSet ds = new DataSet();
        ds.Clear();
        SqlDataAdapter da = new SqlDataAdapter(str, con);
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            Label8.Text = ds.Tables[0].Rows[0][0].ToString();
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
       

    }
protected void  Button1_Click1(object sender, EventArgs e)
{

}
protected void Button2_Click(object sender, EventArgs e)
{
    str = "insert into dealerreg(id,firstname,email,mob,pass,password,type) values('" + Label8.Text + "','"+txtname.Text+"','"+txtemail.Text+"','"+txtmob.Text+"','"+txtpass.Text+"','"+txtpassword.Text+"','"+TextBox1.Text+"')";
    SqlCommand cmd = new SqlCommand(str, con);
    con.Open();
    cmd.ExecuteNonQuery();
    con.Close();
    Response.Write("<script> alert('Registration Successfull,Login now!') </script>");
    Response.Redirect("~/site/newlogin.aspx");
}
protected void clear_Click(object sender, EventArgs e)
{
    txtname.Text = "";
    txtemail.Text = "";
    txtmob.Text = "";
    txtpass.Text = "";
    txtpassword.Text = "";

}
}