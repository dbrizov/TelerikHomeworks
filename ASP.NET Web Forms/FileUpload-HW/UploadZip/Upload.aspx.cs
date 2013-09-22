using Ionic.Zip;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using UploadZip.Models;

namespace UploadZip
{
    public partial class Upload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Expires = -1;
            HttpPostedFile file = Request.Files["uploaded"];

            ZipFile zipFile = ZipFile.Read(file.InputStream);
            StringBuilder zipContent = new StringBuilder();
            foreach (var zipEntry in zipFile.Entries)
            {
                MemoryStream memoryStream = new MemoryStream();
                zipEntry.Extract(memoryStream);

                memoryStream.Position = 0;
                StreamReader reader = new StreamReader(memoryStream);
                zipContent.AppendLine(reader.ReadToEnd());
            }

            using (FilesDbContext db = new FilesDbContext())
            {
                db.Files.Add(new Models.File()
                {
                    Content = zipContent.ToString()
                });

                db.SaveChanges();
            }

            Response.ContentType = "application/json";
            Response.Write("{}");
        }
    }
}