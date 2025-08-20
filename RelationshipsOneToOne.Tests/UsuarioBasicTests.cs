using System;

namespace RelationshipsOneToOne.Tests
{
    public class UsuarioBasicTests
    {
        private Usuario u;

        [Fact]
        public void UsuarioNullNome_ThrowsArgumentNullExecption() {
            u = new();
            Assert.Throws<ArgumentNullException>(() => { u.Nome = null; });
        }

        [Fact]
        public void UsuarioEmptyNome_ThrowsArgumentNullExecption() {
            u = new();
            Assert.Throws<ArgumentNullException>(() => { u.Nome = ""; });
        }
        
        [Fact]
        public void UsuarioFullSpacesOnNome_ThrowsArgumentNullExecption() {
            u = new();
            Assert.Throws<ArgumentNullException>(() => { u.Nome = "   "; });
        }
        
        [Fact]
        public void UsuarioNomeLessThan3_ThrowsArgumentExecption() {
            u = new();
            Assert.Throws<ArgumentException>(() => { u.Nome = "12"; });
        }
        
        [Fact]
        public void UsuarioNomeLessMoreThan45_ThrowsArgumentExecption() {
            u = new();
            Assert.Throws<ArgumentException>(() => { u.Nome = "123456789_123456789_123456789_123456789_123456"; });
        }
        
        [Fact]
        public void UsuarioNomeValid_SetsNome() {
            String expected = "Ana Zaira";

            u = new();
            u.Nome = expected;

            Assert.Equal(expected, u.Nome);
        }

        [Fact]
        public void UsuarioEmailNull_ThrowsArgumentNullException()
        {
            u = new();
            Assert.Throws<ArgumentNullException>(() => { u.Email = null; });
        }

        [Fact]
        public void UsuarioEmailEmpty_ThrowsArgumentNullException()
        {
            u = new();
            Assert.Throws<ArgumentNullException>(() => { u.Email = ""; });
        }
        
        [Fact]
        public void UsuarioFullSpacesOnEmail_ThrowsArgumentNullException()
        {
            u = new();
            Assert.Throws<ArgumentNullException>(() => { u.Email = "   "; });
        }

        [Fact]
        public void UsuarioEmailInvalid_ThrowsFormatException()
        {
            u = new();
            String[] invalidEmails =
            {
                "user@",
                "user@domain.",
                ".user@domain",
                "userdomain.com",
                "user@domain,com",
                "user@domain com",
                "user@domain..com",
                "user@domain@com",
                "user@.domain.com",
                "@domain.com",
                "user name@domain.com",
                "plainstring"
            };

            foreach (String email in invalidEmails)
            {
                Console.WriteLine($">> {email}");
                Assert.Throws<FormatException>(() => { u.Email = email; });
            }
        }

        [Fact]
        public void UsuarioSenhaNull_ThrowsArgumentNullException()
        {
            u = new();
            Assert.Throws<ArgumentNullException>(() => { u.Senha = null; });
        }
        
        [Fact]
        public void UsuarioSenhaEmpty_ThrowsArgumentNullException()
        {
            u = new();
            Assert.Throws<ArgumentNullException>(() => { u.Senha = ""; });
        }
        
        [Fact]
        public void UsuarioFullSpacesOnSenha_ThrowsArgumentNullException()
        {
            u = new();
            Assert.Throws<ArgumentNullException>(() => { u.Senha = "     "; });
        }
        
        [Fact]
        public void UsuarioSenhaLessThan8_ThrowsArgumentException()
        {
            u = new();
            Assert.Throws<ArgumentException>(() => { u.Senha = "1!Aa2@B"; });
        }
        
        [Fact]
        public void UsuarioSenhaWeak_ThrowsArgumentException()
        {
            u = new();
            Assert.Throws<ArgumentException>(() => { u.Senha = "12345678"; });
        }
        
        [Fact]
        public void UsuarioSenhaStrong_SetsSenha()
        {
            String expected = "1!Aa2@Bb";
            
            u = new();
            u.Senha = expected;

            Assert.Equal(expected, u.Senha);
        }

    }
}
