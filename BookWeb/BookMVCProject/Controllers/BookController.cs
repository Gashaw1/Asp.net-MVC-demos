using BookBusinessLayerProject.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.File;
using System.Configuration;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Drawing;

namespace BookMVCProject.Controllers
{
    public class BookController : Controller
    {
     
        // GET: Book
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult UplodBook()
        {
            return PartialView("_bookUpload");
        }
    

        [HttpPost]
        public ActionResult PostBook(HttpPostedFileBase file)
        {
            string azureCon = ConfigurationManager.ConnectionStrings["azurStorage"].ConnectionString;
            CloudStorageAccount cloudStorage = CloudStorageAccount.Parse(azureCon);
            CloudBlobClient clint = cloudStorage.CreateCloudBlobClient();
            CloudBlobContainer container = clint.GetContainerReference("containera");
            container.CreateIfNotExists();

           
            if (file != null)
            {

                int _fileSize = file.ContentLength;
                string _fileNmae = Path.GetFileName(file.FileName);
                string _fileExtension = Path.GetExtension(_fileNmae);
                string bookName = "6149" + _fileNmae;

                string _path = Path.Combine(Server.MapPath("~/Images"), "6149" + bookName);
                file.SaveAs(_path);


                CloudBlockBlob blob = container.GetBlockBlobReference(_fileNmae);
                

           

                if (_fileExtension.ToLower() == ".jpg" || _fileExtension.ToLower() == ".png"
                || _fileExtension.ToLower() == ".gif" || _fileExtension.ToLower() == ".bmp")
                {
                    Stream stream = file.InputStream;
                    BinaryReader binaryReader = new BinaryReader(stream);
                    //return binary form the image
                    byte[] bytes = binaryReader.ReadBytes((int)stream.Length);
                    Image imge = Image.FromStream(stream);
                    string strb64 = Convert.ToBase64String(bytes);
                    blob.UploadFromStream(imge);
                            
                    Book book = new Book();
                    book.bookImgeName = bookName;
                    book.bookISBN = "99_999999999";
                    book.bookImgPath = _path;
                    book.userID = 30;

                 
                    book.BookBusinessLogic_InsertImage(book);
                 
                    TempData["result"] = "File Uploaded Successfully!!";
                  
                }
                else
                {
                    TempData["result"] = "file extension does not support!";
                }
            }
            else
            {
                TempData["result"] = "NO! file selected, Please try agin!";
            }

            // return RedirectToAction("Index", "Product");
            return View("Index");
        }

        //[HttpGet]
        //public PartialViewResult DisplayBook()
        //{
        //    Book book = new Book();

        //    var bookResult = Directory.GetFiles(Server.MapPath("~/Images"));
        //    var filename = Path.GetFileName(bookResult[0]);
        //    book.bookImgPath = filename;
        //    return PartialView("_boookView", book);

        //}

        [HttpGet]
        public PartialViewResult DisplayBook()
        {

            List<Book> bookList = new List<Book>();
            var bookResult = Directory.GetFiles(Server.MapPath("~/Images"));
            for (int i = 0; i < bookResult.Length; i++)
            {
                Book book = new Book();
                var filename = Path.GetFileName(bookResult[i]);
                book.bookImgeName = filename.ToString();
                bookList.Add(book);
            }
            return PartialView("_booksList", bookList);

        }
    }

}
