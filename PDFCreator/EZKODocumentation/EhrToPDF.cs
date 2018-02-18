using System;
using System.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using DatabaseCommunicator.Model;
using ExceptionHandler;
using DatabaseCommunicator.Controllers;
using DatabaseCommunicator.Enums;
using System.Collections;
using System.Text;
using System.Collections.Generic;

namespace PDFCreator.EZKODocumentation
{
    public class EhrToPDF : PDFCreator
    {
        Patient patient;
        User doctor;
        EzkoController ezkoController;

        public EhrToPDF(string path, Patient patient, User doctor, EzkoController ezkoController) : base(path)
        {
            this.ezkoController = ezkoController;
            this.doctor = doctor;
            this.patient = patient;
        }

        public bool CreatePdf()
        {
            bool result = true;

            try
            {
                if (patient == null || doctor == null)
                    result = false;
                else
                {
                    PdfDocument.Open();

                    Chapter chapter1 = AddChapter(
                        new Paragraph(GetTitleText(patient.FullName)) { Alignment = HAlingmentCenter, SpacingAfter = 10f},
                        0, 0);
                    iTextSharp.text.Section personalInfoSection = AddSection(chapter1, 0f, new Paragraph(GetSectionText("Osobné údaje")), 0);

                    PdfPTable table = new PdfPTable(new[] { 60f, 40f })
                    { HorizontalAlignment = HAlingmentLeft, SpacingBefore = 10f, SpacingAfter = 10f, WidthPercentage = 100f };

                    PdfPTable personalInfoTable = CreatePersonalInfoTable();
                    Image pic = null;
                    if (patient.AvatarImagePath != null && System.IO.File.Exists(patient.AvatarImagePath))
                    {
                        pic = Image.GetInstance(patient.AvatarImagePath);
                        pic.ScaleToFit((RX - LX) / 2f, GetTableHeight(personalInfoTable));
                    }
                    else
                        pic = Image.GetInstance((System.Drawing.Image)Properties.Resources.noUserImage, System.Drawing.Imaging.ImageFormat.Png);

                    PdfPCell imageCell = new PdfPCell(pic, false) { PaddingTop = 5f, BorderColor = BaseColor.WHITE };
                    PdfPCell tableCell = new PdfPCell(personalInfoTable) { PaddingTop = 5f, BorderColor = BaseColor.WHITE };

                    table.AddCell(tableCell);
                    table.AddCell(imageCell);
                    personalInfoSection.Add(table);

                    iTextSharp.text.Section addressAndContactSection = AddSection(chapter1, 0f, new Paragraph(GetSectionText("Adresa a kontaktné údaje")), 0);
                    table = new PdfPTable(new[] { 100f })
                    { HorizontalAlignment = HAlingmentLeft, SpacingBefore = 10f, WidthPercentage = 100f };
                    PdfPCell addressCell = new PdfPCell(CreateAddressTable()) { PaddingTop = 5f, BorderColor = BaseColor.WHITE };
                    PdfPCell contactCell = new PdfPCell(CreateContactTable()) { PaddingTop = 5f, BorderColor = BaseColor.WHITE };
                    table.AddCell(addressCell);
                    table.AddCell(contactCell);
                    addressAndContactSection.Add(table);

                    Chapter chapter2 = AddChapter(
                        new Paragraph(GetTitleText("Zdravotná karta pacienta")) { SpacingAfter = 10f },
                        0, 0);

                    foreach (var ezkoSection in ezkoController.GetSections().OrderBy(x => x.Name))
                    {
                        iTextSharp.text.Section pdfSection = AddSection(chapter2, 0f, new Paragraph(GetSectionText(ezkoSection.Name)), 0);
                        PdfPTable sectionTable = CreateEzkoSectionTable(pdfSection, ezkoSection);
                        pdfSection.Add(sectionTable);
                    }

                    Chapter chapter3 = null;
                    if (patient.CalendarEvents.Count > 0)
                    {
                       chapter3 = AddChapter(
                       new Paragraph(GetTitleText("Návštevy pacienta")) { SpacingAfter = 10f },
                       0, 0);
                    }
                    
                    PdfDocument.Add(chapter1);
                    PdfDocument.Add(chapter2);
                    if(chapter3 != null)
                        PdfDocument.Add(chapter3);
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

        private PdfPTable CreateEzkoSectionTable(iTextSharp.text.Section pdfSection, DatabaseCommunicator.Model.Section ezkoSection)
        {
            PdfPTable table = new PdfPTable(3) { HorizontalAlignment = HAlingmentLeft, SpacingBefore = 10f, SpacingAfter = 10f };
            table.WidthPercentage = 100f;

            //PdfPCell cell = GetCell(System.Drawing.Color.White, " ");
            //cell.BorderWidthTop = 1f;
            //cell.UseVariableBorders = true;
            //cell.BorderColorTop = BaseColor.BLACK;
            //table.AddCell(cell);

            //cell = GetCell(System.Drawing.Color.White, GetBoldText("Zistené lekárom"));
            //cell.BorderWidthTop = 1f;
            //cell.UseVariableBorders = true;
            //cell.BorderColorTop = BaseColor.BLACK;
            //table.AddCell(cell);

            //cell = GetCell(System.Drawing.Color.White, GetBoldText("Odpoveď pacienta"));
            //cell.BorderWidthTop = 1f;
            //cell.UseVariableBorders = true;
            //cell.BorderColorTop = BaseColor.BLACK;
            //table.AddCell(cell);

            AddCell(table, " ", System.Drawing.Color.White);
            AddCell(table, GetBoldText("Zistené lekárom"), System.Drawing.Color.White);
            AddCell(table, GetBoldText("Odpoveď pacienta"), System.Drawing.Color.White);

            foreach (var field in ezkoSection.Fields)
            {
                AddCell(table, GetBoldText(field.Name), System.Drawing.Color.White);
                switch (field.TypeID)
                {
                    case (int)FieldTypeEnum.Text:
                    case (int)FieldTypeEnum.LongText:
                        string doctorsAnswer = field.FilledFields.Where(x => x.UserID == doctor.ID && x.PatientID == patient.ID).FirstOrDefault()?.FieldAnswer?.TextValue ?? "nevyplnené";
                        AddCell(table, GetText(doctorsAnswer), System.Drawing.Color.White);
                        string patientsAnswer = field.FilledFields.Where(x => x.UserID == null && x.PatientID == patient.ID).FirstOrDefault()?.FieldAnswer?.TextValue ?? "nevyplnené";
                        AddCell(table, GetText(patientsAnswer), System.Drawing.Color.White);
                        break;
                    case (int)FieldTypeEnum.RadioBox:
                    case (int)FieldTypeEnum.SelectBox:
                        doctorsAnswer = field.FilledFields.Where(x => x.UserID == doctor.ID && x.PatientID == patient.ID).FirstOrDefault()?.FieldValueAnswers.FirstOrDefault()?.FieldValue.Value ?? "nevyplnené";
                        AddCell(table, GetText(doctorsAnswer), System.Drawing.Color.White);
                        patientsAnswer = field.FilledFields.Where(x => x.UserID == null && x.PatientID == patient.ID).FirstOrDefault()?.FieldValueAnswers.FirstOrDefault()?.FieldValue.Value ?? "nevyplnené";
                        AddCell(table, GetText(patientsAnswer), System.Drawing.Color.White);
                        break;
                    case (int)FieldTypeEnum.CheckBox:
                        doctorsAnswer = GetAnswers(field.FilledFields.Where(x => x.UserID == doctor.ID && x.PatientID == patient.ID).FirstOrDefault()?.FieldValueAnswers);
                        AddCell(table, GetText(doctorsAnswer), System.Drawing.Color.White);
                        patientsAnswer = GetAnswers(field.FilledFields.Where(x => x.UserID == null && x.PatientID == patient.ID).FirstOrDefault()?.FieldValueAnswers);
                        AddCell(table, GetText(patientsAnswer), System.Drawing.Color.White);
                        break;
                    default:
                        break;
                }
            }

            return table;
        }

        private string GetAnswers(IEnumerable<FieldValueAnswer> answers)
        {
            if (answers == null || answers.Count() == 0)
                return "nevyplnené";

            StringBuilder stringBuilder = new StringBuilder();
            bool isFirst = true;

            foreach (var answer in answers)
            {
                if (isFirst)
                    isFirst = false;
                else
                    stringBuilder.Append(", ");

                stringBuilder.Append(answer.FieldValue.Value);
            }

            return stringBuilder.ToString();
        }

        private PdfPTable CreatePersonalInfoTable()
        {
            PdfPTable table = new PdfPTable(2) { HorizontalAlignment = HAlingmentLeft, SpacingBefore = 0f, SpacingAfter = 0f };
            table.WidthPercentage = 100f;

            AddCell(table, GetBoldText("Meno"), System.Drawing.Color.White);
            AddCell(table, patient.Name, System.Drawing.Color.White);

            AddCell(table, GetBoldText("Priezvisko"), System.Drawing.Color.White);
            AddCell(table, patient.Surname, System.Drawing.Color.White);

            AddCell(table, GetBoldText("Tituly pred meno"), System.Drawing.Color.White);
            AddCell(table, patient.TitleBefore ?? "neudané", System.Drawing.Color.White);

            AddCell(table, GetBoldText("Tituly za menom"), System.Drawing.Color.White);
            AddCell(table, patient.TitleAfter ?? "neudané", System.Drawing.Color.White);

            AddCell(table, GetBoldText("Rodné číslo"), System.Drawing.Color.White);
            AddCell(table, patient.BirthNumber ?? "neudané", System.Drawing.Color.White);

            AddCell(table, GetBoldText("Pohlavie"), System.Drawing.Color.White);
            AddCell(table, patient.Sex.ToString(), System.Drawing.Color.White);

            AddCell(table, " ", System.Drawing.Color.White);
            AddCell(table, " ", System.Drawing.Color.White);

            AddCell(table, GetBoldText("Zamestnanie"), System.Drawing.Color.White);
            AddCell(table, patient.Employment ?? "neudané", System.Drawing.Color.White);

            AddCell(table, GetBoldText("Poznámka"), System.Drawing.Color.White);
            AddCell(table, patient.Note ?? "", System.Drawing.Color.White);

            return table;
        }

        private PdfPTable CreateAddressTable()
        {
            PdfPTable table = new PdfPTable(2) { HorizontalAlignment = HAlingmentLeft, SpacingBefore = 0f, SpacingAfter = 0f };
            table.WidthPercentage = 100f;

            PdfPCell cell = GetCell(System.Drawing.Color.White, GetSectionText("Adresa"));
            cell.Colspan = 2;
            cell.PaddingTop = 0f;
            cell.PaddingBottom = 7f;
            cell.BorderWidthBottom = 1f;
            cell.UseVariableBorders = true;
            cell.BorderColorBottom = BaseColor.BLACK;
            table.AddCell(cell);

            AddCell(table, GetBoldText("Ulica"), System.Drawing.Color.White);
            AddCell(table, patient.Address?.Street ?? "neudané", System.Drawing.Color.White);

            AddCell(table, GetBoldText("Číslo"), System.Drawing.Color.White);
            AddCell(table, patient.Address?.StreetNumber ?? "neudané", System.Drawing.Color.White);

            AddCell(table, GetBoldText("Mesto"), System.Drawing.Color.White);
            AddCell(table, patient.Address?.City ?? "neudané", System.Drawing.Color.White);

            AddCell(table, GetBoldText("PSČ"), System.Drawing.Color.White);
            AddCell(table, patient.Address?.PostNumber ?? "neudané", System.Drawing.Color.White);

            AddCell(table, GetBoldText("Štát"), System.Drawing.Color.White);
            AddCell(table, patient.Address?.Country ?? "neudané", System.Drawing.Color.White);

            return table;
        }

        private PdfPTable CreateContactTable()
        {
            PdfPTable table = new PdfPTable(2) { HorizontalAlignment = HAlingmentLeft, SpacingBefore = 0f, SpacingAfter = 0f };
            table.WidthPercentage = 100f;

            PdfPCell cell = GetCell(System.Drawing.Color.White, GetSectionText("Kontakt"));
            cell.Colspan = 2;
            cell.PaddingTop = 7f;
            cell.PaddingBottom = 7f;
            cell.BorderWidthBottom = 1f;
            cell.UseVariableBorders = true;
            cell.BorderColorBottom = BaseColor.BLACK;
            table.AddCell(cell);

            AddCell(table, GetBoldText("Telefón"), System.Drawing.Color.White);
            AddCell(table, patient.Contact.Phone ?? "neudané", System.Drawing.Color.White);

            AddCell(table, GetBoldText("Email"), System.Drawing.Color.White);
            AddCell(table, patient.Contact.Email ?? "neudané", System.Drawing.Color.White);

            AddCell(table, GetBoldText("Pracovný/alternatívny telefón"), System.Drawing.Color.White);
            AddCell(table, patient.Contact.AlternativePhone ?? "neudané", System.Drawing.Color.White);

            AddCell(table, GetBoldText("Pracovný/alternatívny email"), System.Drawing.Color.White);
            AddCell(table, patient.Contact.AlternativeEmail ?? "neudané", System.Drawing.Color.White);

            AddCell(table, GetBoldText("Facebook"), System.Drawing.Color.White);
            AddCell(table, patient.Contact.Facebook ?? "neudané", System.Drawing.Color.White);

            return table;
        }
    }
}
