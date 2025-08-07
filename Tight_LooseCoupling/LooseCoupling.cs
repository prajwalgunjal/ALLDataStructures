using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tight_LooseCoupling
{
    // 1️⃣ Interface for abstraction
    public interface IExporter
    {
        void Export();
    }

    // 2️⃣ PDF exporter implementation
    public class PdfExporter_ : IExporter
    {
        public void Export()
        {
            Console.WriteLine("Exported report as PDF.");
        }
    }

    // 3️⃣ Word exporter implementation
    public class WordExporter : IExporter
    {
        public void Export()
        {
            Console.WriteLine("Exported report as Word document.");
        }
    }

    // 4️⃣ Report class now depends on abstraction (interface)
    public class Report_
    {
        private readonly IExporter _exporter;

        // ✅ Dependency is injected from outside
        public Report_(IExporter exporter)
        {
            _exporter = exporter;
        }

        public void Generate()
        {
            Console.WriteLine("Report generated.");
            _exporter.Export();  // Doesn't care what kind of exporter it is
        }
    }

    // 5️⃣ Main program
    class LooseCoupling
    {
        public static void LooseCoupling_()
        {
            // You can switch implementation here
            IExporter exporter = new WordExporter(); // Or use PdfExporter

            Report_ report = new Report_(exporter); // Injecting dependency
            report.Generate();
        }
    }
}
