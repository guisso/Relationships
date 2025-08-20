using System;
using System.Collections.Generic;

namespace RelationshipsOneToOne.Tests
{
    public class PostUsuarioRelationshipTests
    {
        private Usuario _usuario;
        private Post _post;

        [Fact]
        public void PostUsuarioRelationshipNullUsuario_ThrowsArgumentNullException()
        {
            _post = new();
            Assert.Throws<ArgumentNullException>(() => { _post.Usuario = null; });
        }
        
        [Fact]
        public void PostUsuarioRelationshipValidUsuarioSetAnotherUsuario_ThrowsInvalidOperationException()
        {
            _usuario = new();
            _post = new();
            _post.Usuario = _usuario;

            Assert.Throws<InvalidOperationException>(() => { _post.Usuario = new(); });
        }
        
        [Fact]
        public void PostUsuarioRelationshipSetUsuario_Success()
        {
            // Arrange
            _usuario = new();
            _post = new();
            _post.Conteudo = "Este é um post de teste";
            
            // Act
            _post.Usuario = _usuario;
            
            // Assert
            Assert.Equal(_usuario, _post.Usuario);
        }

        [Fact]
        public void PostUsuarioRelationshipRemoveDefaultNullUsuario_ThrowsInvalidOperationException()
        {
            _usuario = new();
            _post = new();
            Assert.Throws<InvalidOperationException>(() => { _post.RemoverUsuario(_usuario); });
        }

        [Fact]
        public void PostUsuarioRelationshipRemoveWrongUsuario_ThrowsInvalidOperationException()
        {
            _usuario = new();
            _post = new();
            _post.Usuario = _usuario;

            Usuario outroUsuario = new();

            Assert.Throws<InvalidOperationException>(() => { _post.RemoverUsuario(outroUsuario); });
        }

        [Fact]
        public void PostUsuarioRelationshipRemoveValidUsuario_Success()
        {
            _usuario = new();
            _post = new();
            _post.Usuario = _usuario;
            
            _post.RemoverUsuario(_usuario);
            
            Assert.Null(_post.Usuario);
        }
    }
}
