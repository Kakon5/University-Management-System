using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iTextSharp.text;
using iTextSharp.text.pdf;
using UniversityManagementSystem.Manager;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class ResultController : Controller
    {
        //
        // GET: /Result/
        public ActionResult Index()
        {
            return View();
        }

        StudentManager aStudentManager = new StudentManager();
        ResultManager aResultManager = new ResultManager();
        CourseEnrollManager aCourseEnrollManager = new CourseEnrollManager();
        public ActionResult ViewResult()
        {
            ViewBag.Students = aStudentManager.GetAllStudents();
            return View();
        }
        [HttpPost]
        public ActionResult ViewResult(int studentId)
        {
            ViewBag.Students = aStudentManager.GetAllStudents();
            MakePdf(studentId);
            return View();
        }

        public JsonResult GetStudentInformation(int studentId)
        {
            var student = aStudentManager.GetStudentInformationByStudentId(studentId);
            return Json(student);
        }

        public JsonResult GetStudentResults(int studentId)
        {
            var student = aResultManager.GetResultsByStudentId(studentId);
            return Json(student);
        }

        public ActionResult SaveResult()
        {
            ViewBag.Students = aStudentManager.GetAllStudents();

            return View();
        }
        [HttpPost]
        public ActionResult SaveResult(CourseEnroll aCourseEnroll)
        {
            ViewBag.Students = aStudentManager.GetAllStudents();
            ViewBag.Message = aCourseEnrollManager.UpdateStudentGrade(aCourseEnroll);
            return View();
        }

        public JsonResult GetCoursesByStudent(int studentId)
        {
            var courseEnrolls = aCourseEnrollManager.GetEnrolledCoursesByStudentId(studentId);
            return Json(courseEnrolls);
        }

        public void MakePdf(int studentId)
        {
            try
            {
                var student = aStudentManager.GetStudentInformationByStudentId(studentId);
                var results = aResultManager.GetResultsByStudentId(studentId);
                PdfPTable tableBlank = new PdfPTable(1);
                tableBlank.DefaultCell.BorderWidth = 0;
                tableBlank.WidthPercentage = 100;
                tableBlank.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                Chunk cnkBlank = new Chunk("  ", FontFactory.GetFont("Times New Roman"));
                cnkBlank.Font.Size = 10;
                tableBlank.AddCell(new Phrase(cnkBlank));

                //footer section
                PdfPTable tablefooter = new PdfPTable(1);
                tablefooter.DefaultCell.BorderWidth = 0;
                tablefooter.WidthPercentage = 100;
                tablefooter.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;

                Chunk cnkfooter = new Chunk("End of Transcript", FontFactory.GetFont("Times New Roman"));
                cnkfooter.Font.SetStyle(1);
                cnkfooter.Font.Size = 10;
                tablefooter.AddCell(new Phrase(cnkfooter));
                //end of footer section

                PdfPTable titleTable = new PdfPTable(1);
                PdfPTable semiTitleTable = new PdfPTable(1);
                PdfPTable semiTitleTable2 = new PdfPTable(1);
                PdfPTable semiTitleTable3 = new PdfPTable(1);
                PdfPTable studentInformation = new PdfPTable(1);
                PdfPTable courseInformation = new PdfPTable(1);
                PdfPTable resultInformation = new PdfPTable(6);
                PdfPTable totalTable = new PdfPTable(1);
                PdfPTable gradingSystemTitle = new PdfPTable(1);
                PdfPTable gradingSystem = new PdfPTable(3);


                //font style
                Font font = FontFactory.GetFont("Currier", 8, Font.NORMAL, BaseColor.BLACK);
                Font font1 = FontFactory.GetFont("Currier", 9, Font.BOLD, BaseColor.BLACK);
                titleTable.WidthPercentage = 80;
                titleTable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                titleTable.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;
                titleTable.DefaultCell.BorderWidth = 0;

                gradingSystemTitle.WidthPercentage = 80;
                gradingSystemTitle.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                gradingSystemTitle.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;
                gradingSystemTitle.DefaultCell.BorderWidth = 0;
                gradingSystem.WidthPercentage = 50;



                semiTitleTable.WidthPercentage = 80;
                semiTitleTable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                semiTitleTable.DefaultCell.BorderWidth = 0;

                semiTitleTable2.WidthPercentage = 80;
                semiTitleTable2.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                semiTitleTable2.DefaultCell.BorderWidth = 0;

                semiTitleTable3.WidthPercentage = 80;
                semiTitleTable3.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                semiTitleTable3.DefaultCell.BorderWidth = 0;

                totalTable.WidthPercentage = 80;
                totalTable.DefaultCell.BorderWidth = 0;

                studentInformation.WidthPercentage = 80;
                studentInformation.DefaultCell.BorderWidth = 0;


                courseInformation.DefaultCell.BorderWidthTop = 0.5f;
                courseInformation.DefaultCell.BorderWidthBottom = 0.5f;
                resultInformation.DefaultCell.BorderWidthLeft = 0f;
                //resultInformation.DefaultCell.BorderColorLeft = BaseColor.WHITE;
                resultInformation.DefaultCell.BorderColorRight = BaseColor.WHITE;

                float[] widths = new float[] { 30f, 80f, 30f, 30f, 30f, 30f };
                resultInformation.SetWidths(widths);


                Chunk c1 = new Chunk("ASIAN POINT UNIVERSITY", FontFactory.GetFont("Times New Roman"));
                c1.Font.SetStyle(0);
                c1.Font.Size = 18;
                c1.Font.SetStyle(Font.BOLD);
                c1.Font.Color = BaseColor.DARK_GRAY;
                Phrase p1 = new Phrase();
                p1.Add(c1);
                titleTable.AddCell(p1);

                Chunk c3 = new Chunk("Gulshan Complex, Road # 95, Nasirabad", FontFactory.GetFont("HELVETICA"));
                c3.Font.SetStyle(0);
                c3.Font.Size = 10;
                c3.Font.Color = BaseColor.DARK_GRAY;

                Phrase p3 = new Phrase();
                p3.Add(c3);
                semiTitleTable.AddCell(p3);

                Chunk c4 = new Chunk("Chittagong-4000, Bangladesh", FontFactory.GetFont("HELVETICA"));
                c4.Font.SetStyle(0);
                c4.Font.Size = 10;
                c4.Font.Color = BaseColor.DARK_GRAY;

                Phrase p4 = new Phrase();
                p4.Add(c4);
                semiTitleTable2.AddCell(p4);

                Chunk c5 = new Chunk("ACADEMIC TRANSCRIPT", FontFactory.GetFont("HELVETICA"));
                c5.Font.SetStyle(0);
                c5.SetBackground(BaseColor.LIGHT_GRAY);
                c5.Font.Size = 12;
                c5.Font.Color = BaseColor.DARK_GRAY;


                Phrase p5 = new Phrase();
                p5.Add(c5);
                semiTitleTable3.AddCell(p5);

                Chunk c6 = new Chunk("Registration No    :  " + student.RegistrationNo
                                    + "\nName                   :  " + student.Name
                                    + "\nEmail                   :  " + student.Email
                                    + "\nAddress               :  " + student.Address
                                    + "\nMajor                   :  " + student.DepartmentName
                                    + "\nTime                    :  " + DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss tt")
                                    + "\nCopy                    :  Student Copy");
                c6.Font.SetStyle(0);
                c6.Font.Size = 8;
                c6.Font.Color = BaseColor.DARK_GRAY;

                Phrase p6 = new Phrase();
                p6.Add(c6);
                studentInformation.AddCell(p6);

                string[] resultHeader = new string[]
                {
                    "Course","Course Title", "Grade","Course Credit", "Credit Earned","Grade Point"
                };
                for (int j = 0; j < 6; j++)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(resultHeader[j], font1));
                    //cell.FixedHeight = 20f;

                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    cell.BorderColor = BaseColor.DARK_GRAY;
                    cell.BorderWidth = 1f;
                    resultInformation.AddCell(cell);
                }

                double totalCourseCredit = 0;
                double totalCreditEarned = 0;
                double totalGradePoint = 0;
                double CGPA = 0;
                double creditEarned = 0;
                double gradePoint = 0;
                foreach (Result aResult in results)
                {
                    if (aResult.Grade != "Not Graded Yet")
                    {
                        gradePoint = ConvertToGradePoint(aResult.Grade);
                        gradePoint = gradePoint * aResult.Credit;
                        if (aResult.Grade == "F")
                        {
                            creditEarned = 0;
                            PdfPCell cell1 = new PdfPCell(new Phrase(aResult.CourseCode, font));
                            cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
                            resultInformation.AddCell(cell1);

                            PdfPCell cell2 = new PdfPCell(new Phrase(aResult.CourseName, font));
                            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                            resultInformation.AddCell(cell2);

                            PdfPCell cell3 = new PdfPCell(new Phrase(aResult.Grade, font));
                            cell3.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell3.VerticalAlignment = Element.ALIGN_MIDDLE;
                            resultInformation.AddCell(cell3);

                            PdfPCell cell4 = new PdfPCell(new Phrase(aResult.Credit.ToString(), font));
                            cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell4.VerticalAlignment = Element.ALIGN_MIDDLE;
                            resultInformation.AddCell(cell4);

                            PdfPCell cell5 = new PdfPCell(new Phrase(creditEarned.ToString(), font));
                            cell5.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell5.VerticalAlignment = Element.ALIGN_MIDDLE;
                            resultInformation.AddCell(cell5);

                            PdfPCell cell6 = new PdfPCell(new Phrase(gradePoint.ToString(), font));
                            cell6.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell6.VerticalAlignment = Element.ALIGN_MIDDLE;
                            resultInformation.AddCell(cell6);

                        }
                        else
                        {
                            creditEarned = aResult.Credit;
                            PdfPCell cell1 = new PdfPCell(new Phrase(aResult.CourseCode, font));
                            cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
                            resultInformation.AddCell(cell1);

                            PdfPCell cell2 = new PdfPCell(new Phrase(aResult.CourseName, font));
                            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                            resultInformation.AddCell(cell2);

                            PdfPCell cell3 = new PdfPCell(new Phrase(aResult.Grade, font));
                            cell3.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell3.VerticalAlignment = Element.ALIGN_MIDDLE;
                            resultInformation.AddCell(cell3);

                            PdfPCell cell4 = new PdfPCell(new Phrase(aResult.Credit.ToString(), font));
                            cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell4.VerticalAlignment = Element.ALIGN_MIDDLE;
                            resultInformation.AddCell(cell4);

                            PdfPCell cell5 = new PdfPCell(new Phrase(creditEarned.ToString(), font));
                            cell5.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell5.VerticalAlignment = Element.ALIGN_MIDDLE;
                            resultInformation.AddCell(cell5);

                            PdfPCell cell6 = new PdfPCell(new Phrase(gradePoint.ToString(), font));
                            cell6.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell6.VerticalAlignment = Element.ALIGN_MIDDLE;
                            resultInformation.AddCell(cell6);
                        }
                        totalCourseCredit += aResult.Credit;
                        totalCreditEarned += creditEarned;
                        totalGradePoint += gradePoint;
                    }
                }
                CGPA = Math.Round((totalGradePoint / totalCourseCredit), 2);
                Chunk c8 = new Chunk("Total Credits Attempted  :  " + totalCourseCredit
                                 + "\nTotal Credits Earned  :      " + totalCreditEarned
                                 + "\nTotal Grade Point  :          " + totalGradePoint
                                 + "\nCumulative GPA  :            " + CGPA);
                c8.Font.SetStyle(0);
                c8.Font.Size = 8;
                c8.Font.Color = BaseColor.DARK_GRAY;

                Phrase p8 = new Phrase();
                p8.Add(c8);
                totalTable.AddCell(p8);

                //Explanation of grading system

                Chunk c9 = new Chunk("EXPLANATION OF GRADING SYSTEM", FontFactory.GetFont("Times New Roman"));
                c9.Font.SetStyle(0);
                c9.Font.Size = 12;
                c9.Font.Color = BaseColor.DARK_GRAY;
                Phrase p9 = new Phrase();
                p9.Add(c9);
                gradingSystemTitle.AddCell(p9);

                string[] grade = new string[]
                {
                    "A+", "A", "A-", "B+", "B", "B-", "C+", "C", "C-", "D+", "D", "D-", "F"
                };
                string[] explanation = new string[]
                {
                    "Excellent","Excellent","Excellent","Good","Good","Good","Passing","Passing","Passing","Deficient Passing","Deficient Passing","Deficient Passing","Failing"
                };
                string[] qualityPoints = new string[]
                {
                    "4.0","3.9","3.7","3.3","3.0","2.7","2.3","2.0","1.7","1.3","1.2","1.0","0"
                };

                string[] header = new string[]
                {
                    "Grade", "Explanation", "Quality Points"
                };
                for (int j = 0; j < 3; j++)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(header[j],font1));
                    cell.FixedHeight = 20f;
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    cell.BorderColor = BaseColor.DARK_GRAY;
                    cell.BackgroundColor = new BaseColor(150, 175, 140);
                    cell.BorderWidth = 2f;
                    gradingSystem.AddCell(cell);
                }

                for (int i = 0; i < 13; i++)
                {
                    PdfPCell cell1 = new PdfPCell(new Phrase(grade[i],font));
                    cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
                    gradingSystem.AddCell(cell1);

                    PdfPCell cell2 = new PdfPCell(new Phrase(explanation[i],font));
                    cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                    gradingSystem.AddCell(cell2);

                    PdfPCell cell3 = new PdfPCell(new Phrase(qualityPoints[i],font));
                    cell3.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell3.VerticalAlignment = Element.ALIGN_MIDDLE;
                    gradingSystem.AddCell(cell3);
                }

                string folderPath = "D:\\PDF\\";
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                int fileCount = Directory.GetFiles(@"D:\\PDF").Length;
                string strFileName = "Transcript" + (fileCount + 1) + ".pdf";
                using (FileStream stream = new FileStream(folderPath + strFileName, FileMode.Create))
                {
                    Document pdfDocument = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
                    PdfWriter.GetInstance(pdfDocument, stream);
                    pdfDocument.Open();
                    pdfDocument.Add(tableBlank);
                    pdfDocument.Add(titleTable);
                    pdfDocument.Add(semiTitleTable);
                    pdfDocument.Add(semiTitleTable2);
                    pdfDocument.Add(semiTitleTable3);
                    pdfDocument.Add(tableBlank);
                    pdfDocument.Add(studentInformation);
                    pdfDocument.Add(tableBlank);
                    //pdfDocument.Add(courseInformation);
                    pdfDocument.Add(resultInformation);
                    pdfDocument.Add(tableBlank);
                    pdfDocument.Add(totalTable);
                    pdfDocument.Add(tableBlank);
                    pdfDocument.Add(gradingSystemTitle);
                    pdfDocument.Add(tableBlank);
                    pdfDocument.Add(gradingSystem);
                    pdfDocument.Add(tableBlank);
                    pdfDocument.Add(tablefooter);
                    pdfDocument.NewPage();

                    pdfDocument.Close();
                    stream.Close();
                    System.Diagnostics.Process.Start(folderPath + "\\" + strFileName);
                }

            }
            catch (Exception)
            {
                ViewBag.Message = "Can't create PDF file!";
            }
        }

        public double ConvertToGradePoint(string grade)
        {
            double point = 0;
            switch (grade)
            {
                case "A+":
                    point = 4.0;
                    break;
                case "A":
                    point = 3.9;
                    break;
                case "A-":
                    point = 3.7;
                    break;
                case "B+":
                    point = 3.3;
                    break;
                case "B":
                    point = 3.0;
                    break;
                case "B-":
                    point = 2.7;
                    break;
                case "C+":
                    point = 2.3;
                    break;
                case "C":
                    point = 2.0;
                    break;
                case "C-":
                    point = 1.7;
                    break;
                case "D+":
                    point = 1.3;
                    break;
                case "D":
                    point = 1.2;
                    break;
                case "D-":
                    point = 1.0;
                    break;
                case "F":
                    point = 0;
                    break;

            }
            return point;
        }

	}
}