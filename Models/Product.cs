using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ModuleExam.Models
{
    public class Product
    {
        private static string id;

        [Key]
        [DataType(DataType.Text)]
        [Display(Name = "Book Id")]
        [Required(ErrorMessage = "Please enter id")]
        public int BookId { get; set; }

        [Required(ErrorMessage = "Please enter product name")]
        [Display(Name = "Book Name")]
        public string BookName { get; set; }

        [Required(ErrorMessage = "Please enter Book Rate")]
        [Display(Name = "Book Rate")]
        public decimal BookRate {get;set;}

        [Required(ErrorMessage = "Please enter Description")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter CategoryName")]
        [Display(Name = "CategoryName")]
        public string CategoryName { get; set; }

        public static List<Product> GetAllProducts()
        {
            SqlConnection cn = new SqlConnection();
                cn.ConnectionString= @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JKJuly2022;Integrated Security=True";

            List<Product> p = new List<Product>();

            try 
            {
                cn.Open();
                SqlCommand cmdIndex = new SqlCommand();
                cmdIndex.Connection = cn;
                cmdIndex.CommandType = System.Data.CommandType.StoredProcedure;
                cmdIndex.CommandText = "ShowAllProduct";

                SqlDataReader dr = cmdIndex.ExecuteReader();

                while (dr.Read())
                {
                    Product pro = new Product();
                    pro.BookId = (int)dr[0];
                    pro.BookName = (string)dr[1];
                    pro.BookRate = (decimal)dr[2];
                    pro.Description = (string)dr[3];
                    pro.CategoryName = (string)dr[4];
                    p.Add(pro);
                }
                dr.Close();
                return p;
            
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
                {
                cn.Close();
            }
            return p;
        }

        internal static void SingleProduct(int d, Product pd)
        {
            throw new NotImplementedException();
        }

        public static Product SingleProduct (int d)
        {
            SqlConnection cn = new SqlConnection();

            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JKJuly2022;Integrated Security=True";

            Product pro = new Product();

            try
            {
                cn.Open();
                SqlCommand cmdIndex = new SqlCommand();
                cmdIndex.Connection = cn;
                cmdIndex.CommandType = System.Data.CommandType.Text;
                cmdIndex.CommandText = "Select * from Product where BookId= " + id;

                SqlDataReader dr = cmdIndex.ExecuteReader();

                if(dr.Read())
                { 
                    pro.BookId = (int)dr[0];
                    pro.BookName = (string)dr[1];
                    pro.BookRate = (decimal)dr[2];
                    pro.Description = (string)dr[3];
                    pro.CategoryName = (string)dr[4];
                    
                }
                dr.Close();
                return pro;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                cn.Close();
            }
            return pro;
        }

        internal static void UpdateProduct (int id, Product pd)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString= @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = JKJuly2022; Integrated Security = True";

            try
            {
                cn.Open();
                SqlCommand cmdUpdate = new SqlCommand();
                cmdUpdate.Connection = cn;
                cmdUpdate.CommandType = System.Data.CommandType.StoredProcedure;
                cmdUpdate.CommandText = "updateproduct";

                cmdUpdate.Parameters.AddWithValue("@BookId", pd.BookId);
                cmdUpdate.Parameters.AddWithValue("@BookName", pd.BookName);
                cmdUpdate.Parameters.AddWithValue("@BookRate", pd.BookRate);
                cmdUpdate.Parameters.AddWithValue("@Description", pd.Description);
                cmdUpdate.Parameters.AddWithValue("@CategoryName", pd.CategoryName);
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            finally
                {
                cn.Close();
            }
        }

       



    }
}