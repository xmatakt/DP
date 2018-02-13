using System;
using System.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using DatabaseCommunicator.Model;
using ExceptionHandler;

namespace PDFCreator.EZKODocumentation
{
    public class FormToPDF : PDFCreator
    {
        private Form form;

        public FormToPDF(string path, Form form) : base(path)
        {
            this.form = form;
        }

        public bool CreatePdf()
        {
            bool result = true;

            try
            {
                if (form == null)
                    result = false;
                else
                {
                    PdfDocument.Open();
                    PdfDocument.Add(new Paragraph(GetTitleText(form.Name)) { SpacingAfter = 10f, Alignment = HAlingmentLeft });
                    AddHorizontalLine();

                    float currentY = Y;

                    foreach (var item in form.FieldForms)
                    {
                        ColumnText ct = new ColumnText(ContentByte);
                        ct.SetSimpleColumn(LX, currentY, RX, currentY - 30);
                        ct.AddElement(new Paragraph(GetBoldText(item.Question.Value)));
                        ct.Go();
                        currentY = ct.YLine - 2;
                        ContentByte.SetLineWidth(1);
                        ContentByte.Rectangle(LX, currentY, RX - RX/3, -50);
                        ContentByte.Stroke();
                        currentY -= 50;
                        //AddPage(currentY);
                    }

                    foreach (var item in form.FieldForms)
                    {
                        ColumnText ct = new ColumnText(ContentByte);
                        ct.SetSimpleColumn(LX, currentY, RX, currentY - 30);
                        ct.AddElement(new Paragraph(GetBoldText(item.Question.Value)));
                        ct.Go();
                        currentY = ct.YLine - 2;
                        ContentByte.SetLineWidth(1);
                        ContentByte.Rectangle(LX, currentY, RX - RX / 3, -50);
                        ContentByte.Stroke();
                        currentY -= 50;
                    }

                    for (int i = 0; i < 50; i++)
                    {

                    foreach (var item in form.FieldForms)
                    {
                        ColumnText ct = new ColumnText(ContentByte);
                        ct.SetSimpleColumn(LX, currentY, RX, currentY - 30);
                        ct.AddElement(new Paragraph(GetBoldText(item.Question.Value)));
                        ct.Go();
                        currentY = ct.YLine - 2;
                        ContentByte.SetLineWidth(1);
                        ContentByte.Rectangle(LX, currentY, RX - RX / 3, -50);
                        ContentByte.Stroke();
                        currentY -= 50;

                            AddPage(ref currentY);
                    }
                    }

                    //PdfDocument.Add(new Paragraph(GetTitleText("Položky")) { SpacingAfter = 10f, Alignment = HAlingmentLeft });
                    //AddItemsTable();
                    //AddHorizontalLine();

                    PdfDocument.Close();
                }
            }
            catch (Exception ex)
            {
                BasicMessagesHandler.LogException(ex);
                result = false;
            }

            return result;
        }
    }
}
