using LanchesClean.Domain.Entidade;
using LanchesClean.Domain.Validacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LanchesClean.Domain.Model
{
    public sealed class Lanche : EntitiesBase
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public string Description { get; private set; }
        public int InStock { get; private set; }
        public string ImagemUrl { get; private set; }

        //Id e propriedade de navegação ao relacionamento
        public int CategoryId { get; set; }
        public Category Categories { get; set; }


        public Lanche(string name, decimal price, string description, int inStock, string imagemUrl)
        {
            ValidateDomain(name, price, description, inStock, imagemUrl);
        }

        public Lanche(int id, string name, decimal price, string description, int inStock, string imagemUrl)
        {
            DomainExceptionValidation.When(Id < 0, "Invalid Id value");
            Id = id;
            ValidateDomain(name, price, description, inStock, imagemUrl);
        }

        public void Update(string name, decimal price, string description, int inStock, string imagemUrl, int categoryId)
        {
            ValidateDomain(name, price, description, inStock, imagemUrl);
            CategoryId = categoryId;
        }


        private void ValidateDomain(string name, decimal price, string description, int inStock, string imagemUrl)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Is name is Invalid");

            DomainExceptionValidation.When(name.Length < 3,
                "Is name is Invalid, Too short 3 characteres");

            DomainExceptionValidation.When(description.Length < 5,
                "Is description is Invalid, Too short 5 characteres");

            DomainExceptionValidation.When(price < 0,
                "Is price value");

            DomainExceptionValidation.When(inStock < 0,
             "Is inStock value");

            DomainExceptionValidation.When(imagemUrl.Length > 250,
             "Invalid image name, too long , maximum 250 characters");

            Name = name;
            Price = price;
            Description = description;
            InStock = inStock;
            ImagemUrl = imagemUrl;
        }
    }
}
