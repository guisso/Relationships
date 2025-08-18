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
    }
}