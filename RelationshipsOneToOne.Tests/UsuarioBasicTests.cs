using System;

namespace RelationshipsOneToOne.Tests
{
    public class UsuarioBasicTests
    {
        private Usuario _u;

        [Fact]
        public void UsuarioNullNome_ThrowsArgumentNullExecption() {
            _u = new();
            Assert.Throws<ArgumentNullException>(() => { _u.Nome = null; });
        }

        [Fact]
        public void UsuarioEmptyNome_ThrowsArgumentNullExecption() {
            _u = new();
            Assert.Throws<ArgumentNullException>(() => { _u.Nome = ""; });
        }
        
        [Fact]
        public void UsuarioFullSpacesOnNome_ThrowsArgumentNullExecption() {
            _u = new();
            Assert.Throws<ArgumentNullException>(() => { _u.Nome = "   "; });
        }
        
        [Fact]
        public void UsuarioNomeLessThan3_ThrowsArgumentExecption() {
            _u = new();
            Assert.Throws<ArgumentException>(() => { _u.Nome = "12"; });
        }
        
        [Fact]
        public void UsuarioNomeLessMoreThan45_ThrowsArgumentExecption() {
            _u = new();
            Assert.Throws<ArgumentException>(() => { _u.Nome = "123456789_123456789_123456789_123456789_123456"; });
        }
        
        [Fact]
        public void UsuarioNomeValid_SetsNome() {
            String expected = "Ana Zaira";

            _u = new();
            _u.Nome = expected;

            Assert.Equal(expected, _u.Nome);
        }

        [Fact]
        public void UsuarioEmailNull_ThrowsArgumentNullException()
        {
            _u = new();
            Assert.Throws<ArgumentNullException>(() => { _u.Email = null; });
        }

        [Fact]
        public void UsuarioEmailEmpty_ThrowsArgumentNullException()
        {
            _u = new();
            Assert.Throws<ArgumentNullException>(() => { _u.Email = ""; });
        }
        
        [Fact]
        public void UsuarioFullSpacesOnEmail_ThrowsArgumentNullException()
        {
            _u = new();
            Assert.Throws<ArgumentNullException>(() => { _u.Email = "   "; });
        }

        [Fact]
        public void UsuarioEmailInvalid_ThrowsFormatException()
        {
            _u = new();
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
                Assert.Throws<FormatException>(() => { _u.Email = email; });
            }
        }

        [Fact]
        public void UsuarioSenhaNull_ThrowsArgumentNullException()
        {
            _u = new();
            Assert.Throws<ArgumentNullException>(() => { _u.Senha = null; });
        }
        
        [Fact]
        public void UsuarioSenhaEmpty_ThrowsArgumentNullException()
        {
            _u = new();
            Assert.Throws<ArgumentNullException>(() => { _u.Senha = ""; });
        }
        
        [Fact]
        public void UsuarioFullSpacesOnSenha_ThrowsArgumentNullException()
        {
            _u = new();
            Assert.Throws<ArgumentNullException>(() => { _u.Senha = "     "; });
        }
        
        [Fact]
        public void UsuarioSenhaLessThan8_ThrowsArgumentException()
        {
            _u = new();
            Assert.Throws<ArgumentException>(() => { _u.Senha = "1!Aa2@B"; });
        }
        
        [Fact]
        public void UsuarioSenhaWeak_ThrowsArgumentException()
        {
            _u = new();
            Assert.Throws<ArgumentException>(() => { _u.Senha = "12345678"; });
        }
        
        [Fact]
        public void UsuarioSenhaStrong_SetsSenha()
        {
            String expected = "1!Aa2@Bb";
            
            _u = new();
            _u.Senha = expected;

            Assert.Equal(expected, _u.Senha);
        }

    }
}
