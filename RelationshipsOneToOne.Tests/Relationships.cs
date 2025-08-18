using System;

namespace RelationshipsOneToOne.Tests
{
    public class Relationships
    {
        [Fact]
        public void CidadaoWithCarteiraMotorista_CarteiraNotNull()
        {
            CarteiraMotorista carteira = new CarteiraMotorista
            {
                Numero = 123456,
                Categoria = Categoria.A,
                Emissao = DateOnly.FromDateTime(DateTime.Today)
            };

            Cidadao cidadao = new Cidadao
            {
                Nome = "Ana Zaira",
                Cpf = 12345678901,
                Nascimento = DateOnly.FromDateTime(DateTime.Now).AddYears(-20),
                CarteiraMotorista = carteira
            };

            Assert.NotNull(cidadao.CarteiraMotorista);
        }
        
        [Fact]
        public void CidadaoWithCarteiraMotorista_CidadaoNotNull()
        {
            CarteiraMotorista carteira = new CarteiraMotorista
            {
                Numero = 123456,
                Categoria = Categoria.A,
                Emissao = DateOnly.FromDateTime(DateTime.Today)
            };

            Cidadao cidadao = new Cidadao
            {
                Nome = "Ana Zaira",
                Cpf = 12345678901,
                Nascimento = DateOnly.FromDateTime(DateTime.Now).AddYears(-20),
                CarteiraMotorista = carteira
            };

            Assert.NotNull(carteira.Cidadao);
        }

        [Fact]
        public void CidadaoWithCarteiraMotorista_CarteiraNumeroValidFromCidadao()
        {
            CarteiraMotorista carteira = new CarteiraMotorista
            {
                Numero = 123456,
                Categoria = Categoria.A,
                Emissao = DateOnly.FromDateTime(DateTime.Today)
            };

            Cidadao cidadao = new Cidadao
            {
                Nome = "Ana Zaira",
                Cpf = 12345678901,
                Nascimento = DateOnly.FromDateTime(DateTime.Now).AddYears(-20),
                CarteiraMotorista = carteira
            };

            Assert.Equal((UInt32)123456, cidadao.CarteiraMotorista.Numero);
        }

        [Fact]
        public void CidadaoWithCarteiraMotorista_CategoriaValidFromCidadao()
        {
            CarteiraMotorista carteira = new CarteiraMotorista
            {
                Numero = 123456,
                Categoria = Categoria.A,
                Emissao = DateOnly.FromDateTime(DateTime.Today)
            };

            Cidadao cidadao = new Cidadao
            {
                Nome = "Ana Zaira",
                Cpf = 12345678901,
                Nascimento = DateOnly.FromDateTime(DateTime.Now).AddYears(-20),
                CarteiraMotorista = carteira
            };

            Assert.Equal(Categoria.A, cidadao.CarteiraMotorista.Categoria);
        }

        [Fact]
        public void CidadaoWithCarteiraMotorista_CidadaoNomeFromCarteira()
        {
            CarteiraMotorista carteira = new CarteiraMotorista
            {
                Numero = 123456,
                Categoria = Categoria.A,
                Emissao = DateOnly.FromDateTime(DateTime.Today)
            };

            Cidadao cidadao = new Cidadao
            {
                Nome = "Ana Zaira",
                Cpf = 12345678901,
                Nascimento = DateOnly.FromDateTime(DateTime.Now).AddYears(-20),
                CarteiraMotorista = carteira
            };

            Assert.Equal("Ana Zaira", carteira.Cidadao.Nome);
        }
    }
}
