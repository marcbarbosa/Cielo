using System;
using System.Configuration;

namespace Cielo.Helpers
{
    public class CieloConfig : ConfigurationSection
    {
        private const string ChaveProperty = "chave";

        private const string NumeroProperty = "numero";

        private const string AmbienteProperty = "ambiente";

        private const string EndpointsProperty = "endpoints";

        [ConfigurationProperty(ChaveProperty, IsRequired = true)]
        public string Chave
        {
            get
            {
                return this[ChaveProperty].ToString();
            }
            set
            {
                this[ChaveProperty] = value;
            }
        }

        [ConfigurationProperty(NumeroProperty, IsRequired = true)]
        public string Numero
        {
            get
            {
                return this[NumeroProperty].ToString();
            }
            set
            {
                this[NumeroProperty] = value;
            }
        }

        [ConfigurationProperty(AmbienteProperty, IsRequired = true, DefaultValue = "dev")]
        [RegexStringValidator("dev|prod")]
        public string Ambiente
        {
            get
            {
                return this[AmbienteProperty].ToString();
            }
            set
            {
                this[AmbienteProperty] = value;
            }
        }

        [ConfigurationProperty(EndpointsProperty, IsRequired = true)]
        [ConfigurationCollection(typeof(EndpointCollection))]
        public EndpointCollection Endpoints
        {
            get
            {
                return (EndpointCollection)this[EndpointsProperty];
            }
        }

        public Uri Endpoint
        {
            get
            {
                if (Ambiente.ToLower().Equals("prod"))
                {
                    return new Uri(Endpoints.Get("prod").Url);
                }

                return new Uri(Endpoints.Get("dev").Url);
            }
        }
    }

    public class EndpointCollection : ConfigurationElementCollection
    {
        public EndpointElement Get(string name)
        {
            return BaseGet(name) as EndpointElement;
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new EndpointElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((EndpointElement)element).Name;
        }
    }

    public class EndpointElement : ConfigurationElement
    {
        private const string NameProperty = "name";

        private const string UrlProperty = "url";

        [ConfigurationProperty(NameProperty, IsKey = true)]
        public string Name
        {
            get
            {
                return this[NameProperty].ToString();
            }
            set
            {
                this[Name] = value;
            }
        }

        [ConfigurationProperty(UrlProperty, IsRequired = true)]
        public string Url
        {
            get
            {
                return this[UrlProperty].ToString();
            }
            set
            {
                this[UrlProperty] = value;
            }
        }
    }
}
