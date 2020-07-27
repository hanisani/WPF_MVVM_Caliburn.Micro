using System.Collections.Generic;

namespace WpfAppCalibun.Services
{
    public interface ICalculations
    {
        List<string> Register { get; set; }
        double Add(double x, double y);
    }
}