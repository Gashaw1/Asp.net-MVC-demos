using BookBusinessLayerProject.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBusinessLayerProject.Model
{
    public class Book : BookBusinessLogic
    {
        int bookID { get; set; }
        public string bookImgeName { get; set; }
        public string bookISBN { get; set; }
        public string bookImgPath { get; set; }
        public int userID { get; set; }


        public Book()
        {
        }
        Book(string productImgeName, string productImgPath, int userID)
        {
            this.bookImgeName = productImgeName;        
            this.bookImgPath = productImgPath;
            this.userID = userID;
        }

    }
}
            