namespace ElementStatistic
{
    using System.Collections.Generic;

    public class Program
    {
        static void Main(string[] args)
        {
            List<dynamic> inputData = new List<dynamic>();

            List<string> elementNames = new List<string>() { "Fe", "Al", "Mg", "Mn", "Si", "Ni", "Co" };

            List<ElementStatistic> statistics = new List<ElementStatistic>();

            foreach (var row in inputData)
            {
                List<double> elementValues = InitializeElementValues(row);
                List<double> usedValues = new List<double>();

                foreach (var currentElementValue in elementValues)
                {
                    if (usedValues.Contains(currentElementValue))
                    {
                        continue;
                    }

                    usedValues.Add(currentElementValue);

                    var indexes = GetIndexesByValue(elementValues, currentElementValue);

                    if (indexes.Count != 0)
                    {
                        List<string> currentElementNames = new List<string>();

                        foreach (var index in indexes)
                        {
                            currentElementNames.Add(elementNames[index]);
                        }

                        statistics.Add(new ElementStatistic()
                        {
                            Value = currentElementValue,
                            Repetitions = indexes.Count,
                            Elements = currentElementNames
                        });
                    }
                }
            }
        }

        private static List<double> InitializeElementValues(dynamic item)
        {
            List<double> elements = new List<double>()
            {
                double.Parse(item[0]),
                double.Parse(item[1]),
                double.Parse(item[2])
                //......
            };

            return elements;
        }

        private static List<int> GetIndexesByValue(List<double> elements, double value)
        {
            List<int> indexes = new List<int>();

            for (int index = 0; index < elements.Count; index++)
            {
                if (elements[index] == value)
                {
                    indexes.Add(index);
                }
            }

            return indexes;
        }
    }

    public class ElementStatistic
    {
        public double Value { get; set; }

        public int Repetitions { get; set; }

        public List<string> Elements { get; set; }
    }
}

