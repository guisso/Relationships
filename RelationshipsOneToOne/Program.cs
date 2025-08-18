using System;

namespace RelationshipsOneToOne
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Custom test to demonstrate the ArgumentNullException
            Cidadao cidadao = new Cidadao();

            try
            {
                cidadao.Nome = null;
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Exceção capturada: {ex.Message}");
            }
        }
    }
}
