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
        private Font checkBoxFont;
        private Font noteFont;

        public PDFCreator(string path)
        {
            try
            {
                stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
                PdfDocument = new Document();
                pdfWriter = PdfWriter.GetInstance(PdfDocument, stream);
                titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, BaseFont.CP1250, true, 18);
                normalFont = FontFactory.GetFont(FontFactory.HELVETICA, BaseFont.CP1250, true, 12);
                boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, BaseFont.CP1250, true, 12);
                checkBoxFont = FontFactory.GetFont(FontFactory.HELVETICA, BaseFont.CP1250, true, 9);
                noteFont = FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, BaseFont.CP1250, true, 6);
                //noteFont = BaseFont.CreateFont(BaseFont.HELVETICA_OBLIQUE, BaseFont.CP1250, false);
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

        internal Phrase GetCheckBoxText(string text)
        {
            Phrase result = new Phrase(text, checkBoxFont);
            return result;
        }

        internal Phrase GetNoteText(string text)
        {
            Phrase result = new Phrase(text, noteFont);
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

        internal float NewPage(float currentY, float additionalY)
        {
            if ((currentY - additionalY) < PdfDocument.BottomMargin)
            {
                PdfDocument.NewPage();
                currentY = Y;
            }

            return currentY;
        }

        internal float NewPage()
        {
            PdfDocument.NewPage();
            return Y;
        }

        internal bool AddPage(float currentY, float additionalY)
        {
            if ((currentY - additionalY) < PdfDocument.BottomMargin)
            {
                return true;
            }

            return false;
        }

        internal ColumnText GetColumnText(Paragraph paragraph, float x, float currentY, bool simulate)
        {
            ColumnText ct = new ColumnText(ContentByte);
            ct.SetSimpleColumn(x, currentY, RX, currentY - 3000);
            ct.AddElement(paragraph);
            ct.Go(simulate);
            return ct;
        }

        internal float AddTextBox(string label, float currentY, float textBoxHeight, float lineWidth, float spacingAfterLabel, System.Drawing.Color borderColor)
        {
            //simulate the creation of columnText to get its height
            ColumnText ct = GetColumnText(new Paragraph(GetBoldText(label)), LX, currentY, true);

            //if there is no space for labeled TextBox, add new page to PDF document
            if(AddPage(currentY, spacingAfterLabel + (currentY - ct.YLine) + textBoxHeight))
            {
                currentY = NewPage();
            }
            ct = GetColumnText(new Paragraph(GetBoldText(label)), LX, currentY, false);
            currentY = ct.YLine - spacingAfterLabel;

            ContentByte.SetLineWidth(lineWidth);
            ContentByte.SetColorStroke(new BaseColor(borderColor));
            ContentByte.Rectangle(LX, currentY, RX - RX / 3, -textBoxHeight);
            ContentByte.Stroke();
            currentY -= textBoxHeight;

            return NewPage(currentY, 0);
        }

        internal float AddCheckBoxes(string[] choices, string label, string note, float currentY, float size, float lineWidth,
            float spacingAfterLabel, System.Drawing.Color borderColor)
        {
            //simulate the creation of columnText to get its height
            ColumnText ct = GetColumnText(new Paragraph(GetBoldText(label )), LX, currentY, true);

            //if there is no space for label and the first CheckBox, add new page to PDF document
            if (AddPage(currentY, spacingAfterLabel + (currentY - ct.YLine) + size))
                currentY = NewPage();
            
            ct = GetColumnText(new Paragraph(GetBoldText(label)), LX, currentY, false);
            currentY = ct.YLine - spacingAfterLabel;

            ContentByte.SetLineWidth(lineWidth);
            ContentByte.SetColorStroke(new BaseColor(borderColor));

            foreach (var choice in choices)
            {
                currentY = NewPage(currentY, size + spacingAfterLabel);

                ContentByte.Rectangle(LX, currentY, size, -size);
                ContentByte.Stroke();
            
                ct = GetColumnText(new Paragraph(GetCheckBoxText(choice)), LX + size + spacingAfterLabel, currentY + size - 1.5f, false);
                currentY -= (size + spacingAfterLabel);
            }

            ct = GetColumnText(new Paragraph(GetNoteText(note)), LX, currentY + size - 1.5f, true);
            if (AddPage(currentY, spacingAfterLabel + (currentY - ct.YLine)))
                currentY = NewPage();

            ct = GetColumnText(new Paragraph(GetNoteText(note)), LX, currentY + size - 1.5f, false);

            return NewPage(currentY, 0);
        }
    }
}
