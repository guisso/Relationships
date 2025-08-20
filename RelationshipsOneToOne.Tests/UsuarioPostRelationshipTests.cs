using System;
using System.Collections.Generic;

namespace RelationshipsOneToOne.Tests
{
    public class UsuarioPostRelationshipTests
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
        public void PostUsuarioRelationshipDuplicatePost_ThrowsArgumentException()
        {
            _usuario = new();
            _post = new();

            _usuario.AdicionarPost(_post);

            Assert.Throws<ArgumentException>(() => { _usuario.AdicionarPost(_post); });
        }

        [Fact]
        public void PostUsuarioRelationshipAddAnotherPostWithSameConteudo_ThrowsArgumentException()
        {
            _usuario = new();
            _post = new() { Conteudo = "Conteúdo do post" };
            Post outroPost = new() { Conteudo = "Conteúdo do post" };

            _usuario.AdicionarPost(_post);

            Assert.Throws<ArgumentException>(() => { _usuario.AdicionarPost(outroPost); });
        }

        [Fact]
        public void UsuarioPostRelationshipAddPost_Success()
        {
            _usuario = new();
            _post = new();

            _usuario.AdicionarPost(_post);

            Assert.Contains(_post, _usuario.Posts);
        }
        
        [Fact]
        public void UsuarioPostRelationshipAddPost_AutomaticBidirectionalSuccess()
        {
            _usuario = new();
            _post = new();

            _usuario.AdicionarPost(_post);

            Assert.Equal(_post.Usuario, _usuario);
        }

        [Fact]
        public void UsuarioPostRelationshipRemoveNullPost_ThrowsArgumentNullException()
        {
            _usuario = new();
            Assert.Throws<ArgumentNullException>(() => { _usuario.RemoverPost(null); });
        }

        [Fact]
        public void UsuarioPostRelationshipRemovePostNotInCollection_ThrowsArgumentException()
        {
            _usuario = new();
            _post = new();

            _usuario.AdicionarPost(new Post());

            Assert.Throws<ArgumentException>(() => { _usuario.RemoverPost(_post); });
        }

        [Fact]
        public void UsuarioPostRelationshipRemovePost_Success()
        {
            _usuario = new();
            _post = new();

            _usuario.AdicionarPost(_post);
            _usuario.RemoverPost(_post);

            Assert.DoesNotContain(_post, _usuario.Posts);
        }
        
        [Fact]
        public void UsuarioPostRelationshipRemovePostAndBidirectionalRelationship_Success()
        {
            _usuario = new();
            _post = new();

            _usuario.AdicionarPost(_post);
            _usuario.RemoverPost(_post);

            Assert.Null(_post.Usuario);
        }
    }
}
