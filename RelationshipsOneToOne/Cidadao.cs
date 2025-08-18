using System;

namespace RelationshipsOneToOne
{
    public class Cidadao
    {
        private String? _nome;
        public String? Nome
        {
            get
            {
                return _nome;
            }

            set
            {
                //if (value is null)
                //{
                //    throw new ArgumentNullException("O nome não pode ser nulo");
                //}
                ArgumentNullException.ThrowIfNull(value);

                if (value.Length > 45)
                {
                    throw new ArgumentException("O nome não pode ter mais do que 45 caracteres");
                }

                _nome = value;
            }
        }
    }
}
