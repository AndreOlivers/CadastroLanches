using LanchesClean.Domain.Entidade;
using LanchesClean.Domain.Validacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanchesClean.Domain.Model
{
    public sealed class Category : EntitiesBase
    {
        public string Name { get; private set; }
        public string Description { get; private set; }


        //PROPRIEDADE DE NAVEGAÇÃO
        public ICollection<Lanche> Lanches { get; set; }

        //CONSTRUTORES
        public Category(string name)
        {
            Name = name;
            ValidateDomain(name);
        }

        public void Update(string name)
        {
            ValidateDomain(name);
        }

        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value");
            Id = id;
            Name = name;
        }

        public void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name, is Required");

            DomainExceptionValidation.When(name.Length < 3,
                "Invalid name, Is name too short, minimum 3 caracteres ");

            Name = name;
        }
    }
}
