namespace RelationshipsOneToOne.Tests
{
    public class UnitTest1
    {
        //
        // Nome
        //

        [Fact]
        public void NomeNull_ThrowsArgumentNullException()
        {
            Cidadao cidadao = new Cidadao();

            Assert.Throws<ArgumentNullException>(() => cidadao.Nome = null);
        }

        [Fact]
        public void NomeMoreThan45Characteres_ThrowsArgumentException()
        {
            Cidadao cidadao = new Cidadao();

            Assert.Throws<ArgumentException>(() => cidadao.Nome = "123456789_123456789_123456789_123456789_123456");
        }

        [Fact]
        public void NomeLessThan45Characteres_SetsNome()
        {
            String nome = "123456789_123456789_123456789_123456789_12345";

            Cidadao cidadao = new Cidadao();
            cidadao.Nome = nome;

            Assert.Equal(nome, cidadao.Nome);
        }

        //
        // CPF
        //

        [Fact]
        public void CpfNull_ThrowsArgumentNullException()
        {
            Cidadao cidadao = new Cidadao();

            Assert.Throws<ArgumentNullException>(() => cidadao.Cpf = null);
        }

        [Fact]
        public void CpfMoreThan11Characteres_ThrowsArgumentException()
        {
            Cidadao cidadao = new Cidadao();

            Assert.Throws<ArgumentException>(() => cidadao.Cpf = 100000000000);
        }

        [Fact]
        public void CpfUntil11Characteres_SetsCpf()
        {
            UInt64 cpf = 123456789_01;

            Cidadao cidadao = new Cidadao();
            cidadao.Cpf = cpf;

            Assert.Equal(cpf, cidadao.Cpf);
        }

        //
        // Nascimento
        //

        [Fact]
        public void NascimentoNull_ThrowsArgumentNullException()
        {
            Cidadao cidadao = new Cidadao();
            Assert.Throws<ArgumentNullException>(() => cidadao.Nascimento = null);
        }

        [Fact]
        public void NascimentoLessThan18Years_ThrowArgumentException()
        {
            Cidadao cidadao = new Cidadao();
            cidadao.Nascimento = DateOnly.FromDateTime(DateTime.Now).AddYears(-18).AddDays(1);
        }

        [Fact]
        public void Nascimento18Years_SetsNascimento()
        {
            DateOnly idade18 = DateOnly.FromDateTime(DateTime.Now).AddYears(-18);

            Cidadao cidadao = new Cidadao();
            cidadao.Nascimento = DateOnly.FromDateTime(DateTime.Now).AddYears(-18);

            Assert.Equal(idade18, cidadao.Nascimento);
        }

        [Fact]
        public void Nascimento18Years1Day_SetsNascimento()
        {
            DateOnly idade18Mais = DateOnly.FromDateTime(DateTime.Now).AddYears(-18).AddDays(-1);

            Cidadao cidadao = new Cidadao();
            cidadao.Nascimento = DateOnly.FromDateTime(DateTime.Now).AddYears(-18).AddDays(-1);

            Assert.Equal(idade18Mais, cidadao.Nascimento);
        }

    }
}