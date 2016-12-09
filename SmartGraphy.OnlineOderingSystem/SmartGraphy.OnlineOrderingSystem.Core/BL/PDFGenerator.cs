using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using iTextSharp.text.io;
using iTextSharp.text;
using SmartGraphy.OnlineOrderingSystem.Core.Entities;
using SmartGraphy.OnlineOrderingSystem.Core.DTO;

namespace SmartGraphy.OnlineOrderingSystem.Core.BL
{
    public class PDFGenerator
    {
        Document invoice;
        PdfWriter writer;
        
        TB_OrderHeader order;
        public PDFGenerator(TB_OrderHeader order,FileStream pdfFile, FileStream headerLogo)
        {
            this.order = order;
            invoice = new Document(PageSize.A4, 20f, 20f, 20f, 20f);
            writer = PdfWriter.GetInstance(invoice, pdfFile);
            writer.PageEvent = new orderFormHeader(headerLogo, order);
            invoice.Open();

        }

        public void GenerateInvoce()
        {
            PdfPCell cell = new PdfPCell();
            invoice.Add(new Paragraph(Environment.NewLine));
            var font = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
            string[] invoiceHeaders = {"#","Product","Template", "Unit Price", "Qty", "Sub Total" };
            PdfPTable invoiceGrid = new PdfPTable(6);
            invoiceGrid.WidthPercentage = 100;
            //invoiceGrid.HeaderRows = 1;
            foreach (var item in invoiceHeaders)
            {
                cell = new PdfPCell(new Phrase(item, font));
                invoiceGrid.AddCell(cell);
            }
            var c = 1;
            var orderDetails = order.TB_OrderDetails;
            foreach (var detail in orderDetails)
            {
                cell = new PdfPCell(new Phrase(c++.ToString(),font));
                invoiceGrid.AddCell(cell);
                cell = new PdfPCell(new Phrase(detail.TB_ItemTemplateDetail.TB_ItemCategory.CategoryName,font));
                invoiceGrid.AddCell(cell);
                cell = new PdfPCell(new Phrase(detail.TB_ItemTemplateDetail.TemplateName,font));
                invoiceGrid.AddCell(cell);
                cell = new PdfPCell(new Phrase(detail.TB_ItemTemplateDetail.UnitPrice.ToString(), font));
                invoiceGrid.AddCell(cell);
                cell = new PdfPCell(new Phrase(detail.Qty.ToString(), font));
                invoiceGrid.AddCell(cell);
                cell = new PdfPCell(new Phrase(detail.SubTotal.ToString(),font));
                invoiceGrid.AddCell(cell);

            }
            
            invoice.Add(invoiceGrid);
            invoice.Add(new Paragraph( Environment.NewLine));
            invoice.Add(new Paragraph("Total Amount: Rs " + order.TotalPrice,font));
            invoice.Add(new Paragraph("Order Date: "+order.OrderedDateTime,font));
            
            invoice.Close();
        }
    }
}
