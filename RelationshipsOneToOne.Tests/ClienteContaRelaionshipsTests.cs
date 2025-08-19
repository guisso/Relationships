namespace RelationshipsOneToOne.Tests
{
    public class ClienteContaRelaionshipsTests
    {
        [Fact]
        public void ClienteContaBancariaNullClienteOnContaBancaria_ThrowsArgumentNullException()
        {
            ContaBancaria conta = new ContaBancaria();
            Assert.Throws<ArgumentNullException>(() => conta.Cliente = null);
        }

        [Fact]
        public void ClienteContaBancariaNullContaBancariaOnCliente_ThrowsArgumentNullException()
        {
            ContaBancaria conta = new ContaBancaria
            {
                Abertura = DateTime.Now
            };
            Assert.Throws<ArgumentNullException>(() => new Cliente { ContaBancaria = null });
        }

        [Fact]
        public void ClienteContaBancariaManualBidirectional_AssignsSuccessfully()
        {
            ContaBancaria conta = new ContaBancaria
            {
                Abertura = DateTime.Now
            };

            Cliente cliente = new Cliente
            {
                Nome = "Ana Zaira",
                Cpf = 999_999_999_99,
                Telefone = 11987654321
            };

            cliente.ContaBancaria = conta;

            Assert.Equal(cliente, conta.Cliente);
        }

        [Fact]
        public void ClienteContaBancariaAutomaticBidirectional_AssignsSuccessfully()
        {
            ContaBancaria conta = new ContaBancaria
            {
                Abertura = DateTime.Now
            };

            Cliente cliente = new Cliente
            {
                Nome = "Ana Zaira",
                Cpf = 999_999_999_99,
                Telefone = 11987654321,
                ContaBancaria = conta
            };

            Assert.Equal(cliente, conta.Cliente);
        }
    }
}
