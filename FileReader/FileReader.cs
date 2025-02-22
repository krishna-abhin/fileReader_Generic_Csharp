using System.Reflection;

namespace MyConsole
{
    public static class FileReader
    {
        // T should be a class with a empty constructor
        public static List<T> Read<T>(string fileName,string seperator) where T : class, new()
        {
            List<T> result = new List<T>();
            List<string> lines = File.ReadAllLines(fileName).ToList();

            List<string> headers = lines[0].Trim().Split(seperator).ToList();
            // remove headers
            lines.RemoveAt(0);

            var properties = new T().GetType().GetProperties();

            // 1. Loop through all the lines in csv file
            // 2. For each line find each data item
            // 3. find the matching class attribute for that data item
            // 4. set the data item
            foreach (string line in lines)
            {
                T item = new T();
                var columns = line.Trim().Split(seperator).ToList();

                for (int i = 0; i < columns.Count; i++)
                {
                    string columnHeader = headers[i];

                    // find the matching class property from csv headers
                    PropertyInfo? matchedProp = properties
                        .Where(w => w.Name.ToLower().Equals(columnHeader.ToLower()))
                        .FirstOrDefault();

                    if (matchedProp != null)
                    {
                        // set object attributes dynamically (convert to the correct attribute type when setting)
                        matchedProp.SetValue(item, Convert.ChangeType(columns[i], matchedProp.PropertyType));
                    }
                }

                result.Add(item);
            }

            return result;
        }
    }
}
