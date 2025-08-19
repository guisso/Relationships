using NuGet.Frameworks;

namespace RelationshipsOneToOne.Tests
{
    public class ClienteContaBasicTests
    {
        #region Cliente/CPF Tests
        [Fact]
        public void ClienteCpfNull_ThrowsArgumentNullException()
        {
            Cliente cliente = new();
            Assert.Throws<ArgumentNullException>(() => cliente.Cpf = null);
        }

        [Fact]
        public void ClienteCpfInvalid_ThrowsArgumentException()
        {
            Cliente cliente = new();
            Assert.Throws<ArgumentException>(() => cliente.Cpf = 100000000000);
        }

        [Fact]
        public void ClienteCpfValid_SetsCpf()
        {
            UInt64 expected = 99999999999;

            Cliente cliente = new();
            cliente.Cpf = expected;

            Assert.Equal(expected, cliente.Cpf);
        }
        #endregion

        #region Cliente/Nome Tests
        [Fact]
        public void ClienteNomeNull_ThrowsArgumentNullException()
        {
            Cliente cliente = new();
            Assert.Throws<ArgumentNullException>(() => cliente.Nome = null);
        }

        [Fact]
        public void ClienteNomeLongerThan45_ThrowsArgumentException()
        {
            Cliente cliente = new();
            Assert.Throws<ArgumentException>(() => cliente.Nome = "123456789_123456789_123456789_123456789_123456");
        }

        [Fact]
        public void ClienteNomeValid_SetsNome()
        {
            String expected = "123456789_123456789_123456789_123456789_12345";

            Cliente cliente = new();
            cliente.Nome = expected;

            Assert.Equal(expected, cliente.Nome);
        }
        #endregion

        #region Cliente/Telefone Tests
        [Fact]
        public void ClienteTelefoneNull_ThrowsArgumentNullException()
        {
            Cliente cliente = new();
            Assert.Throws<ArgumentNullException>(() => cliente.Telefone = null);
        }

        [Fact]
        public void ClienteTelefoneLongerThan15_ThrowsArgumentException()
        {
            Cliente cliente = new();
            Assert.Throws<ArgumentException>(() => cliente.Telefone = 1_000_00_000_000_000);
        }

        [Fact]
        public void ClienteTelefoneValid_SetsTelefone()
        {
            UInt64 expected = 999_99_999_999_999;

            Cliente cliente = new();
            cliente.Telefone = expected;

            Assert.Equal(expected, cliente.Telefone);
        }
        #endregion

        #region ContaBancaria/Numero Tests
        [Fact]
        public void ContaBancariaNumeroNull_ThrowsArgumentNullException()
        {
            ContaBancaria conta = new();
            Assert.Throws<ArgumentNullException>(() => conta.Numero = null);
        }

        [Fact]
        public void ContaBancariaNumeroLessThan8Digits_ThrowArgumentException()
        {
            ContaBancaria conta = new();
            Assert.Throws<ArgumentException>(() => conta.Numero = 999_999_9);
        }

        [Fact]
        public void ContaBancariaNumeroMoreThan8Digits_ThrowArgumentException()
        {
            ContaBancaria conta = new();
            Assert.Throws<ArgumentException>(() => conta.Numero = 100_000_000);
        }

        [Fact]
        public void ContaBancariaNumeroValid_SetsNumero()
        {
            UInt32 expected = 9999_9999;

            ContaBancaria conta = new();
            conta.Numero = expected;

            Assert.Equal(expected, conta.Numero);
        }
        #endregion

        #region ContaBancaria/Saldo Tests
        [Fact]
        public void ContaBancariaSadoNull_ThrowsArgumentNullException()
        {
            ContaBancaria conta = new();

            Assert.Throws<ArgumentNullException>(() => conta.Saldo = null);
        }

        [Fact]
        public void ContaBancariaSaldoNegativeLimiteNull_ThrowsArgumentException()
        {
            ContaBancaria conta = new();
            Assert.Throws<ArgumentException>(() => conta.Saldo = -.01m);
        }

        [Fact]
        public void ContaBancariaSaldoLessThanLimite_ThrowsArgumentException()
        {
            ContaBancaria conta = new();
            conta.Limite = 0;

            Assert.Throws<ArgumentException>(() => conta.Saldo = -.01m);
        }

        [Fact]
        public void ContaBancariaSaldo5000Valid_SetsSaldo()
        {
            Decimal expected = 5000m;

            ContaBancaria conta = new();
            conta.Saldo = expected;

            Assert.Equal(expected, conta.Saldo);
        }
        #endregion

        #region ContaBancaria/Limite Tests
        [Fact]
        public void ContaBancariaLimiteNull_ThrowsArgumentNullException()
        {
            ContaBancaria conta = new();

            Assert.Throws<ArgumentNullException>(() => conta.Limite = null);
        }

        [Fact]
        public void ContaBancariaLimiteNegative_ThrowsArgumentException()
        {
            ContaBancaria conta = new();
            Assert.Throws<ArgumentException>(() => conta.Limite = -.01m);
        }

        [Fact]
        public void ContaBancariaLimiteGreatherThan5000_ThrowsArgumentException()
        {
            ContaBancaria conta = new();
            Assert.Throws<ArgumentException>(() => conta.Limite = 5000.01m);
        }

        [Fact]
        public void ContaBancariaLimite5000Valid_SetsLimite()
        {
            Decimal expected = 5000m;

            ContaBancaria conta = new();
            conta.Limite = expected;

            Assert.Equal(expected, conta.Limite);
        }
        #endregion

        #region ContaBancaria/DataAbertura Tests
        [Fact]
        public void ContaBancariaAberturaNull_ThrowsArgumentNullException()
        {
            ContaBancaria conta = new();
            Assert.Throws<ArgumentNullException>(() => conta.Abertura = null);
        }

        [Fact]
        public void ContaBanCariaAberturaFuture_ThrowsArgumentException()
        {
            ContaBancaria conta = new();

            Assert.Throws<ArgumentException>(() => conta.Abertura = DateTime.Now.AddMinutes(1));
        }

        [Fact]
        public void ContaBancariaAberturaPast5DaysValid_SetsAbertura()
        {
            DateTime expected = DateTime.Now.AddDays(-5);
            
            ContaBancaria conta = new ContaBancaria();
            conta.Abertura = expected;

            Assert.Equal(expected, conta.Abertura);
        }
        
        [Fact]
        public void ContaBancariaAberturaNowValid_SetsAbertura()
        {
            DateTime expected = DateTime.Now;
            
            ContaBancaria conta = new ContaBancaria();
            conta.Abertura = expected;

            Assert.Equal(expected, conta.Abertura);
        }
        #endregion

        #region ContaBancaria/Depositar Tests
        [Fact]
        public void ContaBancariaDepositar1000WithoutSaldo_ThrowsInvalidOperationException()
        {
            ContaBancaria conta = new ContaBancaria();
            //conta.Saldo = 0m;

            Assert.Throws<InvalidOperationException>(() => conta.Depositar(1000m));
        }
        
        [Fact]
        public void ContaBancariaSaldo1000Depositar1000_Succeeds()
        {
            ContaBancaria conta = new ContaBancaria();
            conta.Saldo = 1000m;
            conta.Depositar(1000m);

            Assert.Equal(2000m, conta.Saldo);
        }
        #endregion

        #region ContaBancaria/Sacar Tests
        [Fact]
        public void ContaBancariaSacarWithoutLimite_ThrowsInvalidOperationException()
        {
            ContaBancaria conta = new ContaBancaria();
            conta.Saldo = 0m;

            Assert.Throws<InvalidOperationException>(() => conta.Sacar(.01m));
        }

        [Fact]
        public void ContaBancariaSacarWithoutSaldo_ThrowsInvalidOperationException()
        {
            ContaBancaria conta = new ContaBancaria();
            conta.Limite = 1000m;
            
            Assert.Throws<InvalidOperationException>(() => conta.Sacar(.01m));
        }

        [Fact]
        public void ContaBancariaSacarAboveLimite_ThrowsInvalidOperationException()
        {
            ContaBancaria conta = new ContaBancaria();
            conta.Saldo = 1000m;
            conta.Limite = 500m;

            Decimal valorSaque = 1500.01m;

            Assert.Throws<InvalidOperationException>(() => conta.Sacar(valorSaque));
        }

        [Fact]
        public void ContaBancariaSacarWithSaldoAndLimiteValid_Succeeds()
        {
            ContaBancaria conta = new ContaBancaria();
            conta.Saldo = 1000m;
            conta.Limite = 500m;

            Decimal valorSaque = 1200m;
            conta.Sacar(valorSaque);

            Assert.Equal(-200m, conta.Saldo);
        }
        #endregion
    }
}
