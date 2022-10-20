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
        public Category(string name, string description)
        {
            Name = name;
            ValidateDomain(name , description);
        }

        public void Update(string name, string description)
        {
            ValidateDomain(name, description);
        }

        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value");
            Id = id;
            Name = name;
        }

        public void ValidateDomain(string name, string description)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name, is Required");

            DomainExceptionValidation.When(name.Length < 3,
                "Invalid name, Is name too short, minimum 3 caracteres ");

            DomainExceptionValidation.When(description.Length < 5 ,
                "Invalid description, Is description too short, minimum 5 caracteres");

            DomainExceptionValidation.When(description.Length > 250,
             "Invalid description, Is description too long, maximum 250 caracteres");

            Name = name;
            Description = description;
        }
    }
}
