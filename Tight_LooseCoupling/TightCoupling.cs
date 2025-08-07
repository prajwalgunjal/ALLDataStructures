using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tight_LooseCoupling
{
    // 1️⃣ This class is tightly coupled to PdfExporter
    class Report
    {
        private PdfExporter exporter = new PdfExporter(); // Direct dependency

        public void Generate()
        {
            Console.WriteLine("Report generated.");
            exporter.Export();  // Directly calling specific class
        }
    }

    class PdfExporter
    {
        public void Export()
        {
            Console.WriteLine("Exported report as PDF.");
        }
    }

    class TightCoupling
    {
        public static void TightCoupling_()
        {
            Report report = new Report();
            report.Generate();
        }
    }
}
