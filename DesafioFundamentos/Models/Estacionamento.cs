namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            string placa;
            do
            {
                Console.WriteLine("Digite a placa do veículo para estacionar:");
                placa = Console.ReadLine();
            }while(String.IsNullOrWhiteSpace(placa));
            bool isVeiculoDuplicado = veiculos.Any(x => x.ToUpper() == placa.ToUpper());
            if(isVeiculoDuplicado)
            {
                Console.WriteLine($"O veículo {placa} já está estacionado.");
                return;
            }
            veiculos.Add(placa);
            Console.WriteLine($"O veículo {placa} agora está estacionado.");
        }

        public void RemoverVeiculo()
        {
            string placa;
            do
            {
                Console.WriteLine("Digite a placa do veículo para remover:");

                // Pedir para o usuário digitar a placa e armazenar na variável placa
                placa = Console.ReadLine();
            } while(placa.Length == 0);
            // Verifica se o veículo existe
            if(veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                int horas = 0;
                decimal valorTotal = 0;
                bool isHoraValida = false;
                do
                {
                    Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                    string horasInput = Console.ReadLine();
                    isHoraValida = int.TryParse(horasInput, out int horaValida);
                    if(isHoraValida)
                        horas = horaValida;
                } while(!isHoraValida);
                valorTotal = precoInicial + precoPorHora * horas;
                if(veiculos.Remove(placa))
                {
                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                }
                else
                {
                    Console.WriteLine($"Não foi possível remover o veículo {placa}");
                }
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                for (int i = 0; i < veiculos.Count; i++)
                {
                    Console.WriteLine($"{i+1}. {veiculos[i]}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
