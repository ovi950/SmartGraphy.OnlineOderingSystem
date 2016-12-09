using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using SmartGraphy.OnlineOrderingSystem.Core.DTO;

namespace SmartGraphy.OnlineOrderingSystem.Core.BL
{
    public class orderFormHeader : PdfPageEventHelper
    {
        PdfContentByte cb;
        PdfTemplate template;

        FileStream SGLogo;
        Image logo;
        TB_OrderHeader headerDetalis;
        TB_Customer customerDetails;

        public orderFormHeader(FileStream logo, TB_OrderHeader header)
        {
            SGLogo = logo;
            headerDetalis = header;
            this.logo = iTextSharp.text.Image.GetInstance(SGLogo);
            customerDetails = header.TB_Customer;
        }

        public override void OnStartPage(PdfWriter writer, iTextSharp.text.Document document)
        {
            Paragraph DocumentHeader = new Paragraph("Order Invoice", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 18f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.GRAY));
            DocumentHeader.Alignment = Element.ALIGN_CENTER;
            Paragraph line = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(1.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
            //document.Add(logo);
            //document.Add(new Phrase(Environment.NewLine));
            document.Add(line);
            document.Add(DocumentHeader);
            document.Add(line);
            PdfPTable headerTable = new PdfPTable(3);
            headerTable.WidthPercentage = 100;
            var font = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);

            PdfPCell cell;
            PdfPCell emptyCell = new PdfPCell();
            emptyCell.Border = 0;

            string[] companyDetails = { "Smart Graphy",
                                        customerDetails.FirstName+" "+customerDetails.LastName,
                                        "55/5B",
                                        customerDetails.AddressLine1,
                                        "Malwaththa Rd",
                                        customerDetails.AddressLine2,
                                        "petah",
                                        customerDetails.AddressLine3
                                      };
            for (var i = 0; i < companyDetails.Length; i++)
            {
                cell = new PdfPCell(new Paragraph(companyDetails[i] + Environment.NewLine, font));

                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.Border = 0;
                if (i % 2 == 0)
                {
                    headerTable.AddCell(cell);
                    headerTable.AddCell(emptyCell);
                }

                else
                {

                    headerTable.AddCell(cell);
                }
            }

            document.Add(headerTable);
            document.Add(line);
        }
    }
}

