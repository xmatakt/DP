using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseCommunicator.Model;
using iTextSharp.text;
using ExceptionHandler;
using iTextSharp.text.pdf;

namespace PDFCreator.EZKODocumentation
{
    public class EventToPDF : PDFCreator
    {
        CalendarEvent calendarEvent;

        public EventToPDF(string path, CalendarEvent calendarEvent) : base(path)
        {
            this.calendarEvent = calendarEvent;
        }

        public bool CreatePdf()
        {
            bool result = true;

            try
            {
                if (calendarEvent == null)
                    result = false;
                else
                {
                    PdfDocument.Open();
                    Chapter chapter = AddChapter(new Paragraph(GetTitleText("Záznam o návšteve")){ SpacingAfter = 10f, Alignment = HAlingmentLeft }, 0, 0);
                    iTextSharp.text.Section firstSection = AddSection(chapter, 0f,
                        new Paragraph(GetSectionText(calendarEvent.Patient.FullName + " " + calendarEvent.StartDate.ToString("d. MMMM yyyy, HH:mm")))
                        , 0);

                    firstSection.Add(CreateInfoTable());

                    iTextSharp.text.Section actionsSection = AddSection(chapter, 0f, new Paragraph(GetSectionText("Vykonané")), 0);
                    if(!string.IsNullOrEmpty(calendarEvent.ExecutedActionText))
                        actionsSection.Add(new Paragraph(GetText(calendarEvent.ExecutedActionText)));
                    actionsSection.Add(CreateActionsTable());

                    iTextSharp.text.Section billingSection = AddSection(chapter, 0f, new Paragraph(GetSectionText("Vyúčtovanie")), 0);
                    EventBill eventBill = calendarEvent.EventBills.FirstOrDefault();
                    if (eventBill != null && eventBill.EventBillItems.Count != 0)
                        billingSection.Add(CreateBillingTable(eventBill));
                    else
                        billingSection.Add(new Paragraph(GetBoldText("Návšteva neobsahuje žiadne účtovné položky")));

                    PdfDocument.Add(chapter);

                    AddFooter();

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

        private PdfPTable CreateInfoTable()
        {
            PdfPTable table = new PdfPTable(new[] { 60f, 40f }) { HorizontalAlignment = HAlingmentLeft, SpacingBefore = 10f, SpacingAfter = 10f };
            table.WidthPercentage = 70f;

            AddCell(table, GetText("Pacient"), System.Drawing.Color.White);
            AddCell(table, GetText(calendarEvent.Patient.FullName), System.Drawing.Color.White);
            AddCell(table, GetText("Dátum návštevy"), System.Drawing.Color.White);
            AddCell(table, GetText(calendarEvent.StartDate.ToString("dd.MM.yyyy HH:mm")), System.Drawing.Color.White);
            AddCell(table, GetText("Zaplatené dňa"), System.Drawing.Color.White);
            string payedText = "nezaplatené";
            if (calendarEvent.PaymentDate.HasValue)
                payedText = calendarEvent.PaymentDate.Value.ToString("dd.MM.yyyy HH:mm");
            AddCell(table, GetText(payedText), System.Drawing.Color.White);
            AddCell(table, GetText("Poznámka ku návšteve"), System.Drawing.Color.White);
            AddCell(table, GetText(calendarEvent.Description), System.Drawing.Color.White);

            return table;
        }

        private PdfPTable CreateActionsTable()
        {
            PdfPTable table = new PdfPTable(new[] { 40f, 60f }) { HorizontalAlignment = HAlingmentLeft, SpacingBefore = 10f, SpacingAfter = 10f };
            table.WidthPercentage = 100f;

            PdfPCell cell = GetCell(System.Drawing.Color.White, GetBoldText("Výkon"));
            cell.UseVariableBorders = true;
            cell.BorderWidthBottom = 1f;
            cell.PaddingBottom = 4f;
            cell.BorderColorBottom = BaseColor.BLACK;
            table.AddCell(cell);

            cell = GetCell(System.Drawing.Color.White, GetBoldText("Výstup"));
            cell.UseVariableBorders = true;
            cell.BorderWidthBottom = 1f;
            cell.PaddingBottom = 4f;
            cell.BorderColorBottom = BaseColor.BLACK;
            table.AddCell(cell);

            //AddCell(table, GetBoldText("Výkon"), System.Drawing.Color.White);
            //AddCell(table, GetBoldText("Výstup"), System.Drawing.Color.White);

            foreach (var item in calendarEvent.CalendarEventExecutedActions)
            {
                AddCell(table, GetText(item.Action.Name), System.Drawing.Color.White);
                AddCell(table, GetText(item.ExecutedActionNote.Note), System.Drawing.Color.White);
            }

            return table;
        }

        private PdfPTable CreateBillingTable(EventBill bill)
        {
            PdfPTable table = new PdfPTable(new[] { 50f, 10f, 20f, 20f }) { HorizontalAlignment = HAlingmentLeft, SpacingBefore = 10f, SpacingAfter = 10f };
            table.WidthPercentage = 100f;

            PdfPCell cell = GetCell(System.Drawing.Color.White, GetBoldText("Položka"));
            cell.UseVariableBorders = true;
            cell.BorderWidthBottom = 1f;
            cell.PaddingBottom = 4f;
            cell.BorderColorBottom = BaseColor.BLACK;
            table.AddCell(cell);

            cell = GetCell(System.Drawing.Color.White, GetBoldText("Počet"));
            cell.UseVariableBorders = true;
            cell.BorderWidthBottom = 1f;
            cell.PaddingBottom = 4f;
            cell.BorderColorBottom = BaseColor.BLACK;
            table.AddCell(cell);

            cell = GetCell(System.Drawing.Color.White, GetBoldText("Jedn. cena"));
            cell.UseVariableBorders = true;
            cell.BorderWidthBottom = 1f;
            cell.PaddingBottom = 4f;
            cell.BorderColorBottom = BaseColor.BLACK;
            table.AddCell(cell);

            cell = GetCell(System.Drawing.Color.White, GetBoldText("Zľava"));
            cell.UseVariableBorders = true;
            cell.BorderWidthBottom = 1f;
            cell.PaddingBottom = 4f;
            cell.BorderColorBottom = BaseColor.BLACK;
            table.AddCell(cell);

            foreach (var item in bill.EventBillItems)
            {
                AddCell(table, GetText(item.Name), System.Drawing.Color.White);
                AddCell(table, GetText(item.Count.ToString("0 ks")), System.Drawing.Color.White);
                AddCell(table, GetText(item.UnitPrice.ToString("0.00 €")), System.Drawing.Color.White);
                AddCell(table, GetText(item.Discount.ToString("0.00 €")), System.Drawing.Color.White);
            }

            cell = GetCell(System.Drawing.Color.White, GetBoldText("Spolu:"));
            cell.UseVariableBorders = true;
            cell.BorderWidthTop = 1f;
            cell.BorderColorTop = BaseColor.BLACK;
            table.AddCell(cell);

            cell = GetCell(System.Drawing.Color.White, GetBoldText(bill.EventBillItems.Sum(x => x.Count).ToString("0 ks")));
            cell.UseVariableBorders = true;
            cell.BorderWidthTop = 1f;
            cell.BorderColorTop = BaseColor.BLACK;
            table.AddCell(cell);

            cell = GetCell(System.Drawing.Color.White, GetBoldText("Cena so zľavou:"));
            cell.UseVariableBorders = true;
            cell.BorderWidthTop = 1f;
            cell.BorderColorTop = BaseColor.BLACK;
            table.AddCell(cell);

            cell = GetCell(System.Drawing.Color.White, GetBoldText(bill.EventBillItems.Sum(x => x.UnitPrice * x.Count - x.Discount).ToString("0.00 €")));
            cell.UseVariableBorders = true;
            cell.BorderWidthTop = 1f;
            cell.BorderColorTop = BaseColor.BLACK;
            table.AddCell(cell);

            return table;
        }

        private void AddFooter()
        {
            ContentByte.SetLineWidth(1f);

            ContentByte.MoveTo(LX, BY + 25);
            ContentByte.LineTo(LX + 150, BY + 25);
            ContentByte.Stroke();
            GetColumnText(new Paragraph(GetText("podpis pacienta")), LX + 38, BY + 30, false);

            ContentByte.MoveTo(RX - 150, BY + 25);
            ContentByte.LineTo(RX, BY + 25);
            ContentByte.Stroke();
            GetColumnText(new Paragraph(GetText("podpis lekára")), RX - 104, BY + 30, false);
        }
    }
}
