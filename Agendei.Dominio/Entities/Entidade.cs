using System;
using System.ComponentModel.DataAnnotations;
using FluentValidator;

namespace Agendei.Dominio.Entities
{
    public abstract class Entidade : IEquatable<Entidade>
    {
        protected Entidade()
        {
            Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; private set; }

        public bool Equals(Entidade entidade)
        {
            return Id == entidade.Id;
        }
    }
}