using System;

namespace RelationshipsOneToOne.Tests
{
    public class CidadadoCarteiraMotoristaRelationshipsTests
    {
        [Fact]
        public void CidadaoWithCarteiraMotorista_CarteiraNotNull()
        {
            CarteiraMotorista carteira = CreateCarteiraMotorista();
            Cidadao cidadao = CreateCidadao(carteira);

            Assert.NotNull(cidadao.CarteiraMotorista);
        }
        
        [Fact]
        public void CarteiraByCidadado_CidadaoNotNull()
        {
            CarteiraMotorista carteira = CreateCarteiraMotorista();
            Cidadao cidadao = CreateCidadao(carteira);

            Assert.NotNull(carteira.Cidadao);
        }

        [Fact]
        public void CidadaoWithCarteiraMotorista_CarteiraNumeroValidFromCidadao()
        {
            CarteiraMotorista carteira = CreateCarteiraMotorista();
            Cidadao cidadao = CreateCidadao(carteira);

            Assert.Equal((UInt32)123456, cidadao.CarteiraMotorista?.Numero);
        }

        [Fact]
        public void CidadaoWithCarteiraMotorista_CategoriaValidFromCidadao()
        {
            CarteiraMotorista carteira = CreateCarteiraMotorista();
            Cidadao cidadao = CreateCidadao(carteira);

            Assert.Equal(Categoria.A, cidadao.CarteiraMotorista?.Categoria);
        }

        [Fact]
        public void CidadaoWithCarteiraMotorista_CidadaoNomeFromCarteira()
        {
            CarteiraMotorista carteira = CreateCarteiraMotorista();
            Cidadao cidadao = CreateCidadao(carteira);

            Assert.Equal("Ana Zaira", carteira.Cidadao.Nome);
        }

        // Util methods
        private static Cidadao CreateCidadao(CarteiraMotorista carteira)
        {
            return new Cidadao
            {
                Nome = "Ana Zaira",
                Cpf = 12345678901,
                Nascimento = DateOnly.FromDateTime(DateTime.Now).AddYears(-20),
                CarteiraMotorista = carteira
            };
        }

        private static CarteiraMotorista CreateCarteiraMotorista()
        {
            return new CarteiraMotorista
            {
                Numero = 123456,
                Categoria = Categoria.A,
                Emissao = DateOnly.FromDateTime(DateTime.Today)
            };
        }
    }
}
