using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using WSPizzariaPoloh;
using WSPizzariaPoloh.Serviços;

namespace WSPizzariaPolohHospedagem
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost hospedagem = new ServiceHost(typeof(ProdutoService));
            Uri endereco = new Uri("http://localhost:8080/produtos");
            hospedagem.AddServiceEndpoint(typeof(IProdutoService), new BasicHttpBinding(), endereco);

            try
            {
                hospedagem.Open();
                ExibeInformacoesServico(hospedagem);
                Console.ReadLine();
                hospedagem.Close();
            }
            catch (Exception ex)
            {
                hospedagem.Abort();
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
        public static void ExibeInformacoesServico(ServiceHost sh)
        {
            Console.WriteLine("{0} online", sh.Description.ServiceType);
            foreach (ServiceEndpoint se in sh.Description.Endpoints)
            {
                Console.WriteLine(se.Address);
            }
        
        }
    }
}
