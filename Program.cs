namespace ColorfulObj;

public class Program
{
    static void Main(string[] args)
    {
        if (args.Length > 0)
        {
            var path = args[0];
            var output_file =
                Path.Combine(Path.GetDirectoryName(path)??"",
                Path.GetFileNameWithoutExtension(path) + 
                "-modified" + 
                Path.GetExtension(path));
            using var reader = new StreamReader(path);
            using var writer = new StreamWriter(output_file);
            string? line = null;
            while((line = reader.ReadLine()) != null)
            {
                if (line.StartsWith("v "))
                {
                    var ps = line[2..].Trim().Split(' ');
                    if (ps.Length ==3)
                    {
                        if (!double.TryParse(ps[0], out var x)) x = 1.0;
                        if (!double.TryParse(ps[1], out var y)) y = 1.0;
                        if (!double.TryParse(ps[2], out var z)) z = 1.0;

                        double round = Math.Sqrt(x*x + y*y + z*z);
                        double r = Math.Abs(x / round);
                        double g = Math.Abs(y / round);
                        double b = Math.Abs(z / round);

                        line += $" {r:0.000000} {g:0.000000} {b:0.000000}";
                    }

                    //line += $" {rand.NextDouble():0.000000} {rand.NextDouble():0.000000} {rand.NextDouble():0.000000}";
                    //line += " 1.0 0.0 0.0 ";


                }
                writer.WriteLine(line);
            }

        }
    }
}
