using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using ExceptionHandler;

namespace PDFCreator
{
    public class PDFCreator
    {
        internal Document PdfDocument;
        internal PdfContentByte ContentByte
        {
            get { return pdfWriter.DirectContent; }
        }
        internal float LX
        {
            get { return PdfDocument.LeftMargin; }
        }
        internal float RX
        {
            get { return PdfDocument.PageSize.Width - PdfDocument.RightMargin; }
        }
        internal float Y
        {
            get { return pdfWriter.GetVerticalPosition(true); }
        }
        internal int HAlingmentLeft = 0;
        internal int HAlingmentCenter = 1;
        internal int HAlingmentRight = 2;

        private PdfWriter pdfWriter;
        private FileStream stream;
        private Font titleFont;
        private Font boldFont;
        private Font normalFont;

        public PDFCreator(string path)
        {
            try
            {
                stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
                PdfDocument = new Document();
                pdfWriter = PdfWriter.GetInstance(PdfDocument, stream);
                titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);
                normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);
                boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
            }
            catch (IOException)
            {
                string fileName = new FileInfo(path).Name;
                BasicMessagesHandler.ShowInformationMessage("Nie je možné vytvoriť PDF výstup.\nSúbor " + fileName + " je otvorený v inom programe");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal Phrase GetTitleText(string text)
        {
            Phrase result = new Phrase(text, titleFont);
            return result;
        }

        internal Phrase GetBoldText(string text)
        {
            Phrase result = new Phrase(text, boldFont);
            return result;
        }

        internal PdfPCell GetCell(System.Drawing.Color borderColor, Phrase phrase)
        {
            PdfPCell cell = new PdfPCell
            {
                BorderColor = new BaseColor(borderColor),
                Phrase = phrase
            };

            return cell;
        }

        internal PdfPCell GetCell(System.Drawing.Color borderColor, string text)
        {
            PdfPCell cell = new PdfPCell()
            {
                BorderColor = new BaseColor(borderColor),
                Phrase = new Phrase(text)
            };

            return cell;
        }

        internal void AddHorizontalLine()
        {
            LineSeparator horizontalLine = new LineSeparator();
            PdfDocument.Add(horizontalLine);
        }

        internal void AddPage(ref float currentY)
        {
            if (currentY < 0)
            {
                PdfDocument.NewPage();
                currentY = Y;
            }
        }
    }
}
