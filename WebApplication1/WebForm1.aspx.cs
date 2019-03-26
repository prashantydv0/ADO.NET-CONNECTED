using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection con;
        public SqlConnection getconnection()
        {
            return (new SqlConnection(@"data source=DESKTOP-7F3S625;initial catalog= addressbook; integrated security=true;"));
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            con = getconnection();
            SqlDataAdapter ada = new SqlDataAdapter("select * from addrsbook", con);
            DataSet ds = new DataSet();
            ada.Fill(ds);
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {
          
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (con = getconnection())
            {

                using (SqlCommand com = new SqlCommand("updaterecord", con))
                {
                    com.CommandType = System.Data.CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@address_id", addressid.Text);
                    com.Parameters.AddWithValue("@lname", lname.Text);
                    con.Open();
                    int flag = com.ExecuteNonQuery();
                    con.Close();
                    if (flag > 0)
                        TextBox1.Text = "record updated";
                    else
                        TextBox1.Text = "rocord not present";
                }
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            using (con = getconnection())
            {

                using (SqlCommand com = new SqlCommand("deleterecord", con))
                {
                    com.CommandType = System.Data.CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@address_id", addressid.Text);
                    con.Open();
                    int flag = com.ExecuteNonQuery();
                    con.Close();
                    if (flag > 0)
                        TextBox1.Text = "record delted";
                    else
                        TextBox1.Text = "rocord not present";
                }
            }


        }

        protected void Button3_Click(object sender, EventArgs e)
        {

            using (con = getconnection())
            {

                using (SqlCommand com = new SqlCommand("insertrecord", con))
                {
                    com.CommandType = System.Data.CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@address_id", addressid.Text);
                    com.Parameters.AddWithValue("@lname", lname.Text);
                    com.Parameters.AddWithValue("@fname", fname.Text);
                    com.Parameters.AddWithValue("@phn_no", phnno.Text);
                    con.Open();
                    int flag = com.ExecuteNonQuery();
                    con.Close();
                    if (flag > 0)
                        TextBox1.Text = "record inserted";
                    else
                        TextBox1.Text = "rocord not inserted";
                }
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {

            using (con = getconnection())
            {

                using (SqlCommand com = new SqlCommand("searchrecord", con))
                {
                    com.CommandType = System.Data.CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@lname", lname.Text);
                   SqlParameter p1 = new SqlParameter("@fname", System.Data.SqlDbType.VarChar, 20);
                    SqlParameter p2 = new SqlParameter("@address_id", System.Data.SqlDbType.Int);
                    SqlParameter p3 = new SqlParameter("@phn_no", System.Data.SqlDbType.NChar, 30);
                    SqlParameter p4 = new SqlParameter("@flag", System.Data.SqlDbType.Int);

                    p1.Direction = System.Data.ParameterDirection.Output;
                    p2.Direction = System.Data.ParameterDirection.Output;
                    p3.Direction = System.Data.ParameterDirection.Output;
                    p4.Direction = System.Data.ParameterDirection.ReturnValue;
                     com.Parameters.Add(p1);
                    com.Parameters.Add(p2);
                    com.Parameters.Add(p3);
                    com.Parameters.Add(p4);



                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();
                   fname.Text = com.Parameters["@fname"].Value.ToString();
                    phnno.Text = com.Parameters["@phn_no"].Value.ToString();
                    addressid.Text = com.Parameters["@address_id"].Value.ToString();
                    int flag = (int)com.Parameters["@flag"].Value;

                    if (flag == 1)
                        TextBox1.Text = "record is searched";
                    else
                        TextBox1.Text = "record not present";

                }
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}