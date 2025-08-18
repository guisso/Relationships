namespace RelationshipsOneToOne.Tests
{
    public class UnitTest1
    {
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
    }
}