using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BookDataAccessLayerProject.DataAccess
{
    public class BookData
    {
        string conStrs = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
        //Insert image to the databae       
        public void BookData_InsertBook(string productImgeName, string bookISBN, string productImgPath, int productID)
        {
            using (SqlConnection con = new SqlConnection(conStrs))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_Book_Upload", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramBookImgNmae = new SqlParameter("@bookImgeName", productImgeName);
                cmd.Parameters.Add(paramBookImgNmae);


                SqlParameter paramBookISBn = new SqlParameter("@bookISBN", bookISBN);
                cmd.Parameters.Add(paramBookISBn);

                SqlParameter paramBookImagPath = new SqlParameter("@bookImgPath", productImgPath);
                cmd.Parameters.Add(paramBookImagPath);

                SqlParameter paramUserID = new SqlParameter("@userID", productID);  
                cmd.Parameters.Add(paramUserID);


                SqlParameter paramNewBookImgID = new SqlParameter("@NewBookImgID", -1);
                cmd.Parameters.Add(paramNewBookImgID);

                int rowAffected = cmd.ExecuteNonQuery();
            }
        }
        //Get image by UserId
        //return IMAGE AND IMAGEID
        public DataSet BookData_ProductImageByProductID(int procuctID)
        {
            DataSet dataSet = new DataSet();
            using (SqlConnection con = new SqlConnection(conStrs))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_ProductImages_ReturnBYProductID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramUserID = new SqlParameter("@prroductID", procuctID);
                cmd.Parameters.Add(paramUserID);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dataSet);
                return dataSet;
            }

        }
        //return all image
        public DataSet BookData_BookReturnAll()
        {
            DataSet dataSet = new DataSet();
            using (SqlConnection con = new SqlConnection(conStrs))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from ProductImages", con);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);

                dataAdapter.Fill(dataSet);
                return dataSet;
            }

        }
    }
}

