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
        /// <summary>
        /// Get the DirectContent for drawing into PDF document
        /// </summary>
        internal PdfContentByte ContentByte
        {
            get { return pdfWriter.DirectContent; }
        }
        /// <summary>
        /// Get the left margin
        /// </summary>
        internal float LX
        {
            get { return PdfDocument.LeftMargin; }
        }
        /// <summary>
        /// Get the right margin
        /// </summary>
        internal float RX
        {
            get { return PdfDocument.PageSize.Width - PdfDocument.RightMargin; }
        }
        /// <summary>
        /// Get the top margin
        /// </summary>
        internal float UY
        {
            get { return PdfDocument.TopMargin; }
        }
        /// <summary>
        /// Get the bottom margin
        /// </summary>
        internal float BY
        {
            get { return PdfDocument.BottomMargin; }
        }
        /// <summary>
        /// Get the actual Y position in the document
        /// </summary>
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
        private Font sectionFont;
        private Font normalFont;
        private Font checkBoxFont;
        private Font noteFont;

        /// <summary>
        /// Creates new PDF document
        /// </summary>
        /// <param name="path">Location of the file</param>
        public PDFCreator(string path)
        {
            try
            {
                stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
                PdfDocument = new Document(PageSize.A4);
                pdfWriter = PdfWriter.GetInstance(PdfDocument, stream);
                titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, BaseFont.CP1250, true, 16);
                normalFont = FontFactory.GetFont(FontFactory.HELVETICA, BaseFont.CP1250, true, 10);
                boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, BaseFont.CP1250, true, 10);
                sectionFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, BaseFont.CP1250, true, 13);
                checkBoxFont = FontFactory.GetFont(FontFactory.HELVETICA, BaseFont.CP1250, true, 7);
                noteFont = FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, BaseFont.CP1250, true, 6);
            }
            catch (IOException ex)
            {
                string fileName = new FileInfo(path).Name;
                BasicMessagesHandler.ShowInformationMessage("Nie je možné vytvoriť PDF výstup.\nSúbor " + fileName + " je otvorený v inom programe");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Adds chapter into PDF document
        /// </summary>
        /// <param name="paragraph">Paragraph for chapter title</param>
        /// <param name="number">Number of the chapter</param>
        /// <param name="numberDepth">Number depth of the chapter (if 0 => number will not be visible)</param>
        /// <returns>PDF chapter</returns>
        internal Chapter AddChapter(Paragraph paragraph, int number, int numberDepth)
        {
            return new Chapter(paragraph, number) { NumberDepth = numberDepth};
        }

        /// <summary>
        /// Adds chapter into PDF document
        /// </summary>
        /// <param name="title">Chapter title</param>
        /// <param name="number">Number of the chapter</param>
        /// <param name="numberDepth">Number depth of the chapter (if 0 => number will not be visible)</param>
        internal Chapter AddChapter(string title, int number, int numberDepth)
        {
            return new Chapter(title, number) { NumberDepth = numberDepth };
        }

        /// <summary>
        /// Adds section into provided chapter
        /// </summary>
        /// <param name="chapter">Chapter in which new section will be included</param>
        /// <param name="indentation">Indentation from the left margin</param>
        /// <param name="title">Section title</param>
        /// <param name="numberDepth">Number depth of the section (if 0 => section number will not be visible)</param>
        /// <returns>PDF section</returns>
        internal Section AddSection(Chapter chapter, float indentation, string title, int numberDepth)
        {
            return chapter.AddSection(indentation, title, numberDepth);
        }

        /// <summary>
        /// Adds section into provided chapter
        /// </summary>
        /// <param name="chapter">Chapter in which new section will be included</param>
        /// <param name="indentation">Indentation from the left margin</param>
        /// <param name="paragraph">Paragraph for section title</param>
        /// <param name="numberDepth">Number depth of the section (if 0 => section number will not be visible)</param>
        /// <returns>PDF section</returns>
        internal Section AddSection(Chapter chapter, float indentation, Paragraph paragraph, int numberDepth)
        {
            return chapter.AddSection(indentation, paragraph, numberDepth);
        }

        /// <summary>
        /// Creates phrase from provided string using titleFont
        /// </summary>
        /// <param name="text">Text of the phrase</param>
        /// <returns>Title phrase</returns>
        internal Phrase GetTitleText(string text)
        {
            Phrase result = new Phrase(text, titleFont);
            return result;
        }

        /// <summary>
        /// Creates phrase from provided string using boldFont
        /// </summary>
        /// <param name="text">Text of the phrase</param>
        /// <returns>Bold phrase</returns>
        internal Phrase GetBoldText(string text)
        {
            Phrase result = new Phrase(text, boldFont);
            return result;
        }

        /// <summary>
        /// Creates phrase from provided string using normalFont
        /// </summary>
        /// <param name="text">Text of the phrase</param>
        /// <returns>Text phrase</returns>
        internal Phrase GetText(string text)
        {
            Phrase result = new Phrase(text, normalFont);
            return result;
        }

        /// <summary>
        /// Creates phrase from provided string using sectionFont
        /// </summary>
        /// <param name="text">Text of the phrase</param>
        /// <returns>Section phrase</returns>
        internal Phrase GetSectionText(string text)
        {
            Phrase result = new Phrase(text, sectionFont);
            return result;
        }

        /// <summary>
        /// Creates phrase from provided string using checkBoxFont
        /// </summary>
        /// <param name="text">Text of the phrase</param>
        /// <returns>CheckBox phrase</returns>
        internal Phrase GetCheckBoxText(string text)
        {
            Phrase result = new Phrase(text, checkBoxFont);
            return result;
        }

        /// <summary>
        /// Creates phrase from provided string using noteFont
        /// </summary>
        /// <param name="text">Text of the phrase</param>
        /// <returns>Note phrase</returns>
        internal Phrase GetNoteText(string text)
        {
            Phrase result = new Phrase(text, noteFont);
            return result;
        }

        /// <summary>
        /// Adds cell into provided PDF table
        /// </summary>
        /// <param name="table">PDF table</param>
        /// <param name="phrase">Cell content</param>
        /// <param name="borderColor">Cell border color</param>
        internal void AddCell(PdfPTable table, Phrase phrase, System.Drawing.Color borderColor)
        {
            PdfPCell cell = GetCell(borderColor, phrase);
            table.AddCell(cell);
        }

        /// <summary>
        /// Adds cell into provided PDF table
        /// </summary>
        /// <param name="table">PDF table</param>
        /// <param name="text">Cell content</param>
        /// <param name="borderColor">Cell border color</param>
        internal void AddCell(PdfPTable table, string text, System.Drawing.Color borderColor)
        {
            PdfPCell cell = GetCell(borderColor, text);
            table.AddCell(cell);
        }

        /// <summary>
        /// Creates new PDF table cell
        /// </summary>
        /// <param name="borderColor">Cell border color</param>
        /// <param name="phrase">Cell content</param>
        /// <returns>New cell</returns>
        internal PdfPCell GetCell(System.Drawing.Color borderColor, Phrase phrase)
        {
            PdfPCell cell = new PdfPCell
            {
                BorderColor = new BaseColor(borderColor),
                Phrase = phrase
            };

            return cell;
        }

        /// <summary>
        /// Creates new PDF table cell
        /// </summary>
        /// <param name="borderColor">Cell border color</param>
        /// <param name="text">Cell content</param>
        /// <returns>New cell</returns>
        internal PdfPCell GetCell(System.Drawing.Color borderColor, string text)
        {
            PdfPCell cell = new PdfPCell()
            {
                BorderColor = new BaseColor(borderColor),
                Phrase = new Phrase(text)
            };

            return cell;
        }

        /// <summary>
        /// Add horizontal line into PDF document
        /// </summary>
        internal void AddHorizontalLine()
        {
            LineSeparator horizontalLine = new LineSeparator();
            PdfDocument.Add(horizontalLine);
        }

        /// <summary>
        /// Get height of provided PDF table
        /// </summary>
        /// <param name="table">PDF table for which to compute height</param>
        /// <returns>Height of the PDF table</returns>
        internal float GetTableHeight(PdfPTable table)
        {
            ColumnText ct = new ColumnText(ContentByte);
            ct.SetSimpleColumn(
              PdfDocument.Left, PdfDocument.Bottom,
              PdfDocument.Right, PdfDocument.Top
            );
            ct.AddElement(table);
            ct.Go(true);

            return table.TotalHeight;
        }

        /// <summary>
        /// Adds new page into PDF document if needed
        /// </summary>
        /// <param name="currentY"></param>
        /// <param name="additionalY"></param>
        /// <returns>Y position in the PDF document</returns>
        internal float NewPage(float currentY, float additionalY)
        {
            if ((currentY - additionalY) < PdfDocument.BottomMargin)
            {
                PdfDocument.NewPage();
                currentY = Y;
            }

            return currentY;
        }

        /// <summary>
        /// Adds new page into PDF document
        /// </summary>
        /// <returns>Y position in the PDF document</returns>
        internal float NewPage()
        {
            PdfDocument.NewPage();
            return Y;
        }

        /// <summary>
        /// Checks if new page should be added into the PDF document
        /// </summary>
        /// <param name="currentY">Actual position in the PDF document</param>
        /// <param name="additionalY">Height of the space which needs to be added into PDF document</param>
        /// <returns>Value indicating whether the new page shoul be added</returns>
        internal bool AddPage(float currentY, float additionalY)
        {
            if ((currentY - additionalY) < PdfDocument.BottomMargin)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Get the ColumnText
        /// </summary>
        /// <param name="paragraph">ColumnText content</param>
        /// <param name="x">X position of the lower left corner of the ColumnText</param>
        /// <param name="currentY">Y position of the lower left corner of the ColumnText</param>
        /// <param name="simulate">Value indicating wheter add the ColumnText into the PDF document or only compute the needed space</param>
        /// <returns>ColumnText instance</returns>
        internal ColumnText GetColumnText(Paragraph paragraph, float x, float currentY, bool simulate)
        {
            ColumnText ct = new ColumnText(ContentByte);
            ct.SetSimpleColumn(x, currentY, RX, currentY - 3000);
            ct.AddElement(paragraph);
            ct.Go(simulate);
            return ct;
        }

        /// <summary>
        /// Add labeled TextBox rectangle into PDF document
        /// </summary>
        /// <param name="label">Label of the TextBox</param>
        /// <param name="currentY">Y position of the TextBox</param>
        /// <param name="textBoxHeight">TextBox height</param>
        /// <param name="lineWidth">TextBox border width</param>
        /// <param name="spacingAfterLabel">Size of the gap between label and TextBox</param>
        /// <param name="borderColor">Border color of the TextBox rectangle</param>
        /// <returns>Returns actual Y position in the PDF document</returns>
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

        /// <summary>
        /// Add CheckBoxes into PDF document
        /// </summary>
        /// <param name="choices">CheckBox options</param>
        /// <param name="label">Label for the CheckBox group</param>
        /// <param name="note">Note for the CheckBox group</param>
        /// <param name="currentY">Y position of the upper left corner of the CheckBox group</param>
        /// <param name="size">Size of the CheckBox square</param>
        /// <param name="lineWidth">CheckBox square border width</param>
        /// <param name="spacingAfterLabel">Spacing between label and the CheckBox group</param>
        /// <param name="borderColor">Border color of the CheckBox square</param>
        /// <returns>Actual Y position in the PDF document</returns>
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
            
                ct = GetColumnText(new Paragraph(GetCheckBoxText(choice)), LX + size + spacingAfterLabel, currentY + size - 4f, false);
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
