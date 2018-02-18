using System;
using System.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using DatabaseCommunicator.Model;
using DatabaseCommunicator.Enums;
using ExceptionHandler;

namespace PDFCreator.EZKODocumentation
{
    public class FormToPDF : PDFCreator
    {
        private Form form;
        private float richTextBoxHeight = 50f;
        private float textBoxHeight = 12.5f;
        private float checkBoxSize = 8f;

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
                    Chapter chapter = AddChapter(new Paragraph(GetTitleText(form.Name)) { SpacingAfter = 10f, Alignment = HAlingmentLeft }, 0, 0);
                    PdfDocument.Add(chapter);
                    AddHorizontalLine();

                    float currentY = Y;

                    foreach (var item in form.FieldForms)
                    {
                        switch (item.Field.TypeID)
                        {
                            case (int)FieldTypeEnum.LongText:
                                currentY = AddTextBox(item.Question.Value, currentY, richTextBoxHeight, 0.8f, 5f, System.Drawing.Color.Black);
                                break;
                            case (int)FieldTypeEnum.Text:
                                currentY = AddTextBox(item.Question.Value, currentY, textBoxHeight, 0.8f, 5f, System.Drawing.Color.Black);
                                break;
                            case (int)FieldTypeEnum.CheckBox:
                                string[] choices = item.Field.FieldValues.Select(x => x.Value).ToArray();
                                currentY = AddCheckBoxes(choices, item.Question.Value, "(Môžete označiť viacero možností)",
                                    currentY, checkBoxSize, 0.8f, 5f, System.Drawing.Color.Black);
                                break;
                            case (int)FieldTypeEnum.RadioBox:
                                choices = item.Field.FieldValues.Select(x => x.Value).ToArray();
                                currentY = AddCheckBoxes(choices, item.Question.Value, "(Vyberte jednu z možností)",
                                    currentY, checkBoxSize, 0.8f, 5f, System.Drawing.Color.Black);
                                break;
                            case (int)FieldTypeEnum.SelectBox:
                                choices = item.Field.FieldValues.Select(x => x.Value).ToArray();
                                currentY = AddCheckBoxes(choices, item.Question.Value, "(Vyberte jednu z možností)",
                                    currentY, checkBoxSize, 0.8f, 5f, System.Drawing.Color.Black);
                                break;
                            default:
                                break;
                        }
                        
                    }

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
