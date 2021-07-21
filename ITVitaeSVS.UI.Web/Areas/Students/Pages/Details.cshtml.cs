using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ITVitaeSVS.Core.Application.Interfaces.Services;
using ITVitaeSVS.Core.Domain.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.StaticFiles;

namespace ITVitaeSVS.UI.Web.Areas.Students.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly IStudentService students;
        private readonly IPDFWriter pdfWriter;
        private readonly IWebHostEnvironment webHost;

        public Student Student { get; set; }
        public DetailsModel(IStudentService students,
            IPDFWriter pdfWriter,
            IWebHostEnvironment webHost) {
            this.students = students;
            this.pdfWriter = pdfWriter;
            this.webHost = webHost;
        }
        public void OnGet(int id)
        {
            Student = students.GetById(id);
        }

        public IActionResult OnPostSavePDF(int id)
        {
            Student = students.GetById(id);
            if(Student != null)
            {
                string dir = Path.Combine(webHost.WebRootPath, "pdf");
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);
                string fileName = $"{DateTime.Now:yyyyMMddHHmmss} {Student.Name}.pdf";
                string path = Path.Combine(dir, fileName);
                string logoPath = Path.Combine(webHost.WebRootPath, "itvitaelogoliggend.png");

                pdfWriter.CreateDocument(path, logoPath, Student);
                
                string mimeType;
                new FileExtensionContentTypeProvider().TryGetContentType(fileName, out mimeType);
                byte[] fileBytes = System.IO.File.ReadAllBytes(path);

                return File(fileBytes, mimeType ?? "application/octet-stream", fileName);
            }

            return RedirectToPage("Details", new { id });
        }
    }
}
