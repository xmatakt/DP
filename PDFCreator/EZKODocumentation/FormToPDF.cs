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
                        currentY = AddTextBox(item.Question.Value, currentY, 50, 0.8f, 5f);
                    foreach (var item in form.FieldForms)
                        currentY = AddTextBox(item.Question.Value, currentY, 50, 0.8f, 5f);
                    foreach (var item in form.FieldForms)
                        currentY = AddTextBox(item.Question.Value, currentY, 50, 0.8f, 5f);
                    foreach (var item in form.FieldForms)
                        currentY = AddTextBox(item.Question.Value, currentY, 50, 0.8f, 5f);
                    foreach (var item in form.FieldForms)
                        currentY = AddTextBox(item.Question.Value, currentY, 50, 0.8f, 5f);
                    foreach (var item in form.FieldForms)
                        currentY = AddTextBox(item.Question.Value, currentY, 50, 0.8f, 5f);
                    foreach (var item in form.FieldForms)
                        currentY = AddTextBox(item.Question.Value, currentY, 50, 0.8f, 5f);
                    foreach (var item in form.FieldForms)
                        currentY = AddTextBox(item.Question.Value, currentY, 50, 0.8f, 5f);
                    foreach (var item in form.FieldForms)
                        currentY = AddTextBox(item.Question.Value, currentY, 50, 0.8f, 5f);
                    foreach (var item in form.FieldForms)
                        currentY = AddTextBox(item.Question.Value, currentY, 50, 0.8f, 5f);
                    foreach (var item in form.FieldForms)
                        currentY = AddTextBox(item.Question.Value, currentY, 50, 0.8f, 5f);
                    foreach (var item in form.FieldForms)
                        currentY = AddTextBox(item.Question.Value, currentY, 50, 0.8f, 5f);

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
