using System;

namespace RelationshipsOneToOne.Tests
{
    public class PostBasicTests
    {
        private Post _post;

        [Fact]
        public void PostConteudoNull_ThrowsArgumentNullException()
        {
            _post = new Post();
            Assert.Throws<ArgumentException>(() => _post.Conteudo = null);
        }
        
        [Fact]
        public void PostConteudoEmpty_ThrowsArgumentNullException()
        {
            _post = new Post();
            Assert.Throws<ArgumentException>(() => _post.Conteudo = "");
        }
        
        [Fact]
        public void PostFullSpacesOnConteudo_ThrowsArgumentNullException()
        {
            _post = new Post();
            Assert.Throws<ArgumentException>(() => _post.Conteudo = "   ");
        }
        
        [Fact]
        public void PostConteudoMoreThan200_ThrowsArgumentNullException()
        {
            _post = new Post();
            Assert.Throws<ArgumentException>(() => _post.Conteudo = "a".PadLeft(201));
        }

        [Fact]
        public void PostConteudoValid_SetsConteudo()
        {
            String expected = "Uma nova postagem no meu canal de rede social";

            _post = new Post();
            _post.Conteudo = expected;

            Assert.Equal(expected, _post.Conteudo);
        }

        [Fact]
        public void PostDefaultPulicacao_IsToday()
        {
            _post = new Post();
            Assert.Equal(DateTime.Now.Date, _post.Publicacao.Date);
        }
        
        [Fact]
        public void PostDefaultCurtidas_IsZero()
        {
            _post = new Post();
            Assert.Equal(0U, _post.Curtidas);
        }

        [Fact]
        public void PostCurtidasAddOneWithoutUsuario_ThrowsInvalidOperationException()
        {
            _post = new Post();
            Assert.Throws<InvalidOperationException>(() => _post.AdicionarCurtida());
        }

        [Fact]
        public void PostCurtidasAddOneWithUsuario_IncrementsCurtidas()
        {
            _post = new Post();
            _post.Usuario = new Usuario();
            _post.AdicionarCurtida();

            Assert.Equal(1U, _post.Curtidas);
        }
        
        [Fact]
        public void PostCurtidasRemoveOneWithoutUsuario_ThrowsInvalidOperationException()
        {
            _post = new Post();
            Assert.Throws<InvalidOperationException>(() => _post.RemoverCurtida());
        }

        [Fact]
        public void PostCurtidasRemoveOneWithUsuario_ThrowsInvalidOperationException()
        {
            _post = new Post();
            _post.Usuario = new Usuario();
            Assert.Throws<InvalidOperationException>(() => _post.RemoverCurtida());
        }
        
        [Fact]
        public void PostCurtidasAddTwoRemoveOneWithUsuario_ResultsOneCurtida()
        {
            _post = new Post();
            _post.Usuario = new Usuario();
            _post.AdicionarCurtida();
            _post.AdicionarCurtida();
            _post.RemoverCurtida();
            Assert.Equal(1U, _post.Curtidas);
        }
    }
}
