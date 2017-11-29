using System.Collections.Generic;
using BookDataAccessLayerProject.DataAccess;
using BookBusinessLayerProject.Model;
using System.Data;

namespace BookBusinessLayerProject.BusinessLayer
{
    public class BookBusinessLogic
    {
        //add image to the database
        public void BookBusinessLogic_InsertImage(Book book)
        {
            BookData BookData = new BookData();
            BookData.BookData_InsertBook(book.bookImgeName, book.bookISBN, book.bookImgPath, book.userID);
        }

        //Product is FK
        public List<Book> BookBusinessLogic_BookReturnByProductId(int productId)
        {
            List<Book> books = new List<Book>();
            BookData bookData = new BookData();
            DataTable dt = new DataTable();
            dt = bookData.BookData_ProductImageByProductID(productId).Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                Book prodactImg = new Book();
                // prodactImg.productImgB64 = row["productImgB64"].ToString();
                books.Add(prodactImg);
            }
            return books;

        }

        //return all images q
        public List<Book> BookBusinessLogic_BookReturnAll()
        {
            List<Book> books = new List<Book>();


            BookData prodDa = new BookData();

            DataTable dataTable = prodDa.BookData_BookReturnAll().Tables[0];

            foreach (DataRow row in dataTable.Rows)
            {
                Book productImage = new Book();
                productImage.bookImgeName = row["productImgeName"].ToString();
                // productImage.productImgB64 = row["productImgB64"].ToString();
                books.Add(productImage);
            }
            return books;
        }
    }
}
