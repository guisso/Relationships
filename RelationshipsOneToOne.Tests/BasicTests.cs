namespace RelationshipsOneToOne.Tests
{
    public class BasicTests
    {
        //
        // Nome
        //

        [Fact]
        public void NomeNull_ThrowsArgumentNullException()
        {
            Cidadao cidadao = new();

            Assert.Throws<ArgumentNullException>(() => cidadao.Nome = null);
        }
        
        [Fact]
        public void NomeEmpty_ThrowsArgumentException()
        {
            Cidadao cidadao = new();

            Assert.Throws<ArgumentException>(() => cidadao.Nome = "");
        }

        [Fact]
        public void NomeMoreThan45Characteres_ThrowsArgumentException()
        {
            Cidadao cidadao = new();

            Assert.Throws<ArgumentException>(() => cidadao.Nome = "123456789_123456789_123456789_123456789_123456");
        }

        [Fact]
        public void NomeLessThan45Characteres_SetsNome()
        {
            String nome = "123456789_123456789_123456789_123456789_12345";

            Cidadao cidadao = new();
            cidadao.Nome = nome;

            Assert.Equal(nome, cidadao.Nome);
        }

        //
        // CPF
        //

        [Fact]
        public void CpfNull_ThrowsArgumentNullException()
        {
            Cidadao cidadao = new();

            Assert.Throws<ArgumentNullException>(() => cidadao.Cpf = null);
        }

        [Fact]
        public void CpfMoreThan11Characteres_ThrowsArgumentException()
        {
            Cidadao cidadao = new();

            Assert.Throws<ArgumentException>(() => cidadao.Cpf = 100000000000);
        }

        [Fact]
        public void CpfUntil11Characteres_SetsCpf()
        {
            UInt64 cpf = 123456789_01;

            Cidadao cidadao = new();
            cidadao.Cpf = cpf;

            Assert.Equal(cpf, cidadao.Cpf);
        }

        //
        // Nascimento
        //

        [Fact]
        public void NascimentoNull_ThrowsArgumentNullException()
        {
            Cidadao cidadao = new();
            Assert.Throws<ArgumentNullException>(() => cidadao.Nascimento = null);
        }

        [Fact]
        public void NascimentoLessThan18Years_ThrowArgumentException()
        {
            Cidadao cidadao = new();
            Assert.Throws<ArgumentException>(
                () => cidadao.Nascimento = DateOnly.FromDateTime(DateTime.Now).AddYears(-18).AddDays(1)
             );
        }

        [Fact]
        public void Nascimento18Years_SetsNascimento()
        {
            DateOnly idade18 = DateOnly.FromDateTime(DateTime.Now).AddYears(-18);

            Cidadao cidadao = new();
            cidadao.Nascimento = idade18;

            Assert.Equal(idade18, cidadao.Nascimento);
        }

        [Fact]
        public void Nascimento18Years1Day_SetsNascimento()
        {
            DateOnly idade18Mais = DateOnly.FromDateTime(DateTime.Now).AddYears(-18).AddDays(-1);

            Cidadao cidadao = new();
            cidadao.Nascimento = DateOnly.FromDateTime(DateTime.Now).AddYears(-18).AddDays(-1);

            Assert.Equal(idade18Mais, cidadao.Nascimento);
        }

        //
        // Categoria
        //

        [Fact]
        public void CategoriaSize_Size5()
        {
            Int32 total = Enum.GetValues(typeof(Categoria)).Length;

            Assert.Equal(5, total);
        }

        [Fact]
        public void CategoriaValues_ContainsAtoE()
        {
            String[] expected = new[] { "A", "B", "C", "D", "E" };
            String[] values = Enum.GetNames(typeof(Categoria));

            Assert.Equal(expected, values);
        }

        //
        // CarteiraMotorista
        //

        [Fact]
        public void CarteiraMotoristaEmissaoNull_ThrowsArgumentNullException()
        {
            CarteiraMotorista carteira = new();
            Assert.Throws<ArgumentNullException>(() => carteira.Emissao = null);
        }

        [Fact]
        public void CarteiraMotoristaEmissaoFuture_ThrowsArgumentException()
        {
            CarteiraMotorista carteira = new();
            Assert.Throws<ArgumentException>(
                () => carteira.Emissao = DateOnly.FromDateTime(DateTime.Now).AddDays(1)
            );
        }

        [Fact]
        public void CarteiraMotoristaEmissaoValid_SetsEmissao()
        {
            DateOnly emissao = DateOnly.FromDateTime(DateTime.Now).AddDays(-1);

            CarteiraMotorista carteira = new();
            carteira.Emissao = emissao;

            Assert.Equal(emissao, carteira.Emissao);
        }
        
        [Fact]
        public void CarteiraMotoristaEmissaoValid_DefaultValidade()
        {
            DateOnly emissao = DateOnly.FromDateTime(DateTime.Now).AddDays(-1);

            CarteiraMotorista carteira = new();
            carteira.Emissao = emissao;

            Assert.Equal(emissao.AddYears(5), carteira.Validade);
        }

        [Fact]
        public void CarteiraMotoristaValidadeNull_ThrowsArgumentNullException()
        {
            CarteiraMotorista carteira = new();
            Assert.Throws<ArgumentNullException>(() => carteira.Validade = null);
        }

        [Fact]
        public void CarteiraMotoristaValidadePast_ThrowsArgumentException()
        {
            CarteiraMotorista carteira = new();
            Assert.Throws<ArgumentException>(
                () => carteira.Validade = DateOnly.FromDateTime(DateTime.Now).AddDays(-1)
            );
        }

        [Fact]
        public void CarteiraMotoristaValidadeBeforeEmissao_ThrowsArgumentException()
        {
            DateOnly emissao = DateOnly.FromDateTime(DateTime.Now).AddDays(-1);
            DateOnly validade = emissao.AddDays(-1);

            CarteiraMotorista carteira = new();
            carteira.Emissao = emissao;

            Assert.Throws<ArgumentException>(() => carteira.Validade = validade);
        }

        [Fact]
        public void CarteiraMotoristaValidadeAfterEmissao_SetsValidade()
        {
            DateOnly emissao = DateOnly.FromDateTime(DateTime.Now).AddDays(-10);
            DateOnly validade = emissao.AddYears(2);

            CarteiraMotorista carteira = new();
            carteira.Emissao = emissao;
            carteira.Validade = validade;

            Assert.Equal(validade, carteira.Validade);
        }
        
        [Fact]
        public void CarteiraMotoristaEmissao10DaysBeforeNow_ValidadeIsValida()
        {
            DateOnly emissao = DateOnly.FromDateTime(DateTime.Now).AddDays(-10);
            DateOnly validade = emissao.AddYears(2);

            CarteiraMotorista carteira = new();
            carteira.Emissao = emissao;
            carteira.Validade = validade;

            Assert.True(carteira.IsValida());
        }
        
        [Fact]
        public void CarteiraMotoristaEmissao10YearsBeforeNow_ValidadeIsNotValida()
        {
            DateOnly emissao = DateOnly.FromDateTime(DateTime.Now).AddYears(-10);

            CarteiraMotorista carteira = new();
            carteira.Emissao = emissao;

            Assert.False(carteira.IsValida());
        }

    }
}