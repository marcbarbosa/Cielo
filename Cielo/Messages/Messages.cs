using Cielo.Helpers;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Xml.Serialization;

namespace Cielo.Messages
{
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "http://ecommerce.cbmp.com.br")]
    [XmlRootAttribute("requisicao-transacao", Namespace = "http://ecommerce.cbmp.com.br", IsNullable = false)]
    public partial class RequisicaoTransacao : Mensagem
    {
        [XmlElementAttribute("dados-ec")]
        public DadosEc DadosEc { get; set; }

        [XmlElementAttribute("dados-portador")]
        public DadosPortador DadosPortador { get; set; }

        [XmlElementAttribute("dados-pedido")]
        public DadosPedido DadosPedido { get; set; }

        [XmlElementAttribute("forma-pagamento")]
        public FormaPagamento FormaPagamento { get; set; }

        [XmlElementAttribute("url-retorno")]
        public string UrlRetorno { get; set; }

        [XmlElementAttribute("autorizar")]
        public RequisicaoTransacaoAutorizar Autorizar { get; set; }

        [XmlElementAttribute("capturar")]
        public bool Capturar { get; set; }

        [XmlElementAttribute("campo-livre")]
        public string CampoLivre { get; set; }

        [XmlElementAttribute("bin")]
        public string Bin { get; set; }

        [XmlElementAttribute("gerar-token")]
        public bool GerarToken { get; set; }

        [XmlElementAttribute("avs")]
        public RequisicaoTransacaoAvs Avs { get; set; }
    }



    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "http://ecommerce.cbmp.com.br")]
    public partial class DadosEcAutenticacao : DadosEc
    {

        private string nomeField;

        private string codigopaisField;


        public string nome
        {
            get
            {
                return this.nomeField;
            }
            set
            {
                this.nomeField = value;
            }
        }


        [XmlElementAttribute("codigo-pais")]
        public string codigopais
        {
            get
            {
                return this.codigopaisField;
            }
            set
            {
                this.codigopaisField = value;
            }
        }
    }



    [XmlIncludeAttribute(typeof(DadosEcAutenticacao))]

    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "http://ecommerce.cbmp.com.br")]
    public partial class DadosEc
    {
        [XmlElementAttribute("numero")]
        public string Numero { get; set; }

        [XmlElementAttribute("chave")]
        public string Chave { get; set; }
    }



    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "http://ecommerce.cbmp.com.br")]
    public partial class DadosAvs
    {

        private string enderecoField;

        private string complementoField;

        private string numeroField;

        private string bairroField;

        private string cepField;


        public string endereco
        {
            get
            {
                return this.enderecoField;
            }
            set
            {
                this.enderecoField = value;
            }
        }


        public string complemento
        {
            get
            {
                return this.complementoField;
            }
            set
            {
                this.complementoField = value;
            }
        }


        public string numero
        {
            get
            {
                return this.numeroField;
            }
            set
            {
                this.numeroField = value;
            }
        }


        public string bairro
        {
            get
            {
                return this.bairroField;
            }
            set
            {
                this.bairroField = value;
            }
        }


        public string cep
        {
            get
            {
                return this.cepField;
            }
            set
            {
                this.cepField = value;
            }
        }
    }



    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "http://ecommerce.cbmp.com.br")]
    public partial class FormaPagamentoCelular
    {

        private string produtoField;

        private int parcelasField;


        public string produto
        {
            get
            {
                return this.produtoField;
            }
            set
            {
                this.produtoField = value;
            }
        }


        public int parcelas
        {
            get
            {
                return this.parcelasField;
            }
            set
            {
                this.parcelasField = value;
            }
        }
    }



    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "http://ecommerce.cbmp.com.br")]
    public partial class DadosCelular
    {
        [XmlElementAttribute("ddd")]
        public string Ddd { get; set; }

        [XmlElementAttribute("numero")]
        public string Numero { get; set; }
    }



    [XmlIncludeAttribute(typeof(ProcessamentoAutorizacao))]
    [XmlIncludeAttribute(typeof(ProcessamentoAutenticacao))]

    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "http://ecommerce.cbmp.com.br")]
    public partial class Processamento
    {
        [XmlElementAttribute("codigo")]
        public Status Codigo { get; set; }

        [XmlElementAttribute("mensagem")]
        public string Mensagem { get; set; }

        [XmlElementAttribute("data-hora")]
        public DateTime DataHora { get; set; }

        [XmlElementAttribute("valor")]
        public string Valor { get; set; }
    }



    [SerializableAttribute()]
    [XmlTypeAttribute(Namespace = "http://ecommerce.cbmp.com.br")]
    public enum Status
    {
        [XmlEnumAttribute("0")]
        Criada = 0,

        [XmlEnumAttribute("1")]
        EmAndamento = 1,

        [XmlEnumAttribute("2")]
        Autenticada = 2,

        [XmlEnumAttribute("3")]
        NaoAutenticada = 3,

        [XmlEnumAttribute("4")]
        Autorizada = 4,

        [XmlEnumAttribute("5")]
        NaoAutorizada,

        [XmlEnumAttribute("6")]
        Capturada,

        [XmlEnumAttribute("9")]
        Cancelada = 9,

        [XmlEnumAttribute("10")]
        EmAutenticacao = 10,

        [XmlEnumAttribute("12")]
        EmCancelamento = 12,
    }



    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "http://ecommerce.cbmp.com.br")]
    public partial class ProcessamentoAutorizacao : Processamento
    {

        private string lrField;

        private string arpField;

        private string nsuField;


        public string lr
        {
            get
            {
                return this.lrField;
            }
            set
            {
                this.lrField = value;
            }
        }


        public string arp
        {
            get
            {
                return this.arpField;
            }
            set
            {
                this.arpField = value;
            }
        }


        public string nsu
        {
            get
            {
                return this.nsuField;
            }
            set
            {
                this.nsuField = value;
            }
        }
    }



    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "http://ecommerce.cbmp.com.br")]
    public partial class ProcessamentoAutenticacao : Processamento
    {

        private int eciField;

        private bool eciFieldSpecified;


        public int eci
        {
            get
            {
                return this.eciField;
            }
            set
            {
                this.eciField = value;
            }
        }


        [XmlIgnoreAttribute()]
        public bool eciSpecified
        {
            get
            {
                return this.eciFieldSpecified;
            }
            set
            {
                this.eciFieldSpecified = value;
            }
        }
    }



    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "http://ecommerce.cbmp.com.br")]
    public partial class FormaPagamento
    {
        [XmlElementAttribute("bandeira")]
        public FormaPagamentoBandeira Bandeira { get; set; }

        [XmlIgnoreAttribute()]
        public bool BandeiraSpecified { get; set; }

        [XmlElementAttribute("produto")]
        public FormaPagamentoProduto Produto { get; set; }

        [XmlElementAttribute("parcelas")]
        public int Parcelas { get; set; }
    }



    [SerializableAttribute()]
    [XmlTypeAttribute()]
    public enum FormaPagamentoProduto
    {
        [XmlEnumAttribute("1")]
        CreditoAVista = 1,

        [XmlEnumAttribute("2")]
        ParceladoLoja = 2,

        [XmlEnumAttribute("A")]
        Debito = 4
    }



    [SerializableAttribute()]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "http://ecommerce.cbmp.com.br")]
    public enum FormaPagamentoBandeira
    {
        [XmlEnumAttribute("visa")]
        Visa,

        [XmlEnumAttribute("mastercard")]
        Mastercard,

        [XmlEnumAttribute("elo")]
        Elo,


        [XmlEnumAttribute("diners")]
        Diners,

        [XmlEnumAttribute("discover")]
        Discover,

        [XmlEnumAttribute("amex")]
        Amex,
    }



    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "http://ecommerce.cbmp.com.br")]
    public partial class DadosPedido
    {
        [XmlElementAttribute("numero")]
        public string Numero { get; set; }

        [XmlElementAttribute("valor")]
        public int Valor { get; set; }

        [XmlElementAttribute("moeda")]
        public Moeda Moeda { get; set; }

        [XmlElementAttribute("data-hora")]
        public string DataHoraStr
        {
            get
            { 
                return DataHora.ToString("yyyy-MM-ddTHH:mm:ss"); 
            }
            set
            {
                DataHora = DateTime.Parse(value);
            }
        }

        [XmlIgnore]
        public DateTime DataHora { get; set; }

        [XmlElementAttribute("descricao")]
        public string Descricao { get; set; }

        [XmlElementAttribute("idioma")]
        public Idioma Idioma { get; set; }

        [XmlIgnoreAttribute()]
        public bool IdiomaSpecified { get; set; }

        [XmlElementAttribute("soft-descriptor")]
        public string SoftDescriptor { get; set; }

        [XmlElementAttribute("taxa-embarque")]
        public int TaxaEmbarque { get; set; }
    }



    [SerializableAttribute()]
    [XmlTypeAttribute()]
    public enum Moeda
    {
        [XmlEnumAttribute("986")]
        Real,

        [XmlEnumAttribute("840")]
        Dolar,

        [XmlEnumAttribute("978")]
        Euro
    }


    [SerializableAttribute()]
    [XmlTypeAttribute(Namespace = "http://ecommerce.cbmp.com.br")]
    public enum Idioma
    {
        PT,

        EN,

        ES,
    }



    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "http://ecommerce.cbmp.com.br")]
    public partial class DadosPortador
    {
        [XmlElementAttribute("numero")]
        public string Numero { get; set; }

        [XmlElementAttribute("validade")]
        public string Validade { get; set; }

        [XmlElementAttribute("indicador")]
        public DadosCartaoIndicador Indicador { get; set; }

        [XmlElementAttribute("codigo-seguranca")]
        public string CodigoSeguranca { get; set; }

        [XmlElementAttribute("nome-portador")]
        public string NomePortador { get; set; }

        [XmlElementAttribute("token")]
        public string Token { get; set; }
    }



    [SerializableAttribute()]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "http://ecommerce.cbmp.com.br")]
    public enum DadosCartaoIndicador
    {
        [XmlEnumAttribute("0")]
        NaoInformado = 0,

        [XmlEnumAttribute("1")]
        Informado = 1,

        [XmlEnumAttribute("2")]
        Ilegivel = 2,

        [XmlEnumAttribute("9")]
        Inexistente = 9,
    }



    [XmlIncludeAttribute(typeof(RequisicaoNovaTransacaoCelular))]
    [XmlIncludeAttribute(typeof(RetornoTid))]
    [XmlIncludeAttribute(typeof(RequisicaoTid))]
    [XmlIncludeAttribute(typeof(Retorno))]
    [XmlIncludeAttribute(typeof(RequisicaoConsultaChSec))]
    [XmlIncludeAttribute(typeof(Requisicao))]
    [XmlIncludeAttribute(typeof(RequisicaoAutorizacaoPortador))]
    [XmlIncludeAttribute(typeof(RequisicaoAutorizacaoTid))]
    [XmlIncludeAttribute(typeof(RequisicaoConsulta))]
    [XmlIncludeAttribute(typeof(RequisicaoCancelamento))]
    [XmlIncludeAttribute(typeof(RequisicaoCaptura))]
    [XmlIncludeAttribute(typeof(RequisicaoTransacao))]
    [XmlIncludeAttribute(typeof(RequisicaoToken))]

    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "http://ecommerce.cbmp.com.br")]
    public partial class Mensagem
    {
        [XmlAttributeAttribute("id")]
        public string Id { get; set; }

        [XmlAttributeAttribute("versao")]
        public MensagemVersao Versao { get; set; }
    }



    [SerializableAttribute()]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "http://ecommerce.cbmp.com.br")]
    public enum MensagemVersao
    {
        [XmlEnumAttribute("1.0.0")]
        v100,

        [XmlEnumAttribute("1.1.0")]
        v110,

        [XmlEnumAttribute("1.1.1")]
        v111,

        [XmlEnumAttribute("1.2.0")]
        v120,

        [XmlEnumAttribute("1.3.0")]
        v130,

        [XmlEnumAttribute("1.4.0")]
        v140,
    }



    [XmlIncludeAttribute(typeof(RequisicaoAutorizacaoPortador))]
    [XmlIncludeAttribute(typeof(RequisicaoAutorizacaoTid))]
    [XmlIncludeAttribute(typeof(RequisicaoConsulta))]
    [XmlIncludeAttribute(typeof(RequisicaoCancelamento))]
    [XmlIncludeAttribute(typeof(RequisicaoCaptura))]

    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "http://ecommerce.cbmp.com.br")]
    public partial class Requisicao : Mensagem
    {
        [XmlElementAttribute("tid")]
        public string Tid { get; set; }

        [XmlElementAttribute("dados-ec")]
        public DadosEc DadosEc { get; set; }
    }



    [SerializableAttribute()]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "http://ecommerce.cbmp.com.br")]
    public enum RequisicaoTransacaoAutorizar
    {
        [XmlEnumAttribute("0")]
        NaoAutorizar = 0,

        [XmlEnumAttribute("1")]
        AutorizarSomenteSeAutenticada = 1,


        [XmlEnumAttribute("2")]
        AutorizarAutenticadaENaoAutenticada = 2,


        [XmlEnumAttribute("3")]
        AutorizarSemPassarPorAutenticacao = 3,

        [XmlEnumAttribute("4")]
        TransacaoRecorrente = 4,
    }



    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "http://ecommerce.cbmp.com.br")]
    public partial class RequisicaoTransacaoAvs
    {
        [XmlElementAttribute("dados-avs")]
        public DadosAvs DadosAvs { get; set; }
    }



    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "http://ecommerce.cbmp.com.br")]
    [XmlRootAttribute("requisicao-autorizacao-portador", Namespace = "http://ecommerce.cbmp.com.br", IsNullable = false)]
    public partial class RequisicaoAutorizacaoPortador : Requisicao
    {

        private DadosPortador dadoscartaoField;

        private DadosPedido dadospedidoField;

        private FormaPagamento formapagamentoField;

        private bool capturarautomaticamenteField;

        private string campolivreField;


        [XmlElementAttribute("dados-cartao")]
        public DadosPortador dadoscartao
        {
            get
            {
                return this.dadoscartaoField;
            }
            set
            {
                this.dadoscartaoField = value;
            }
        }


        [XmlElementAttribute("dados-pedido")]
        public DadosPedido dadospedido
        {
            get
            {
                return this.dadospedidoField;
            }
            set
            {
                this.dadospedidoField = value;
            }
        }


        [XmlElementAttribute("forma-pagamento")]
        public FormaPagamento formapagamento
        {
            get
            {
                return this.formapagamentoField;
            }
            set
            {
                this.formapagamentoField = value;
            }
        }


        [XmlElementAttribute("capturar-automaticamente")]
        public bool capturarautomaticamente
        {
            get
            {
                return this.capturarautomaticamenteField;
            }
            set
            {
                this.capturarautomaticamenteField = value;
            }
        }


        [XmlElementAttribute("campo-livre")]
        public string campolivre
        {
            get
            {
                return this.campolivreField;
            }
            set
            {
                this.campolivreField = value;
            }
        }
    }



    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "http://ecommerce.cbmp.com.br")]
    [XmlRootAttribute("requisicao-autorizacao-tid", Namespace = "http://ecommerce.cbmp.com.br", IsNullable = false)]
    public partial class RequisicaoAutorizacaoTid : Requisicao
    {
    }



    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "http://ecommerce.cbmp.com.br")]
    [XmlRootAttribute("requisicao-cancelamento", Namespace = "http://ecommerce.cbmp.com.br", IsNullable = false)]
    public partial class RequisicaoCancelamento : Requisicao
    {
    }



    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "http://ecommerce.cbmp.com.br")]
    [XmlRootAttribute("requisicao-cancelamento", Namespace = "http://ecommerce.cbmp.com.br", IsNullable = false)]
    public partial class RequisicaoCancelamentoParcial : RequisicaoCancelamento
    {

        private int valorField;

        public int valor
        {
            get
            {
                return this.valorField;
            }
            set
            {
                this.valorField = value;
            }
        }
    }



    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "http://ecommerce.cbmp.com.br")]
    [XmlRootAttribute("requisicao-captura", Namespace = "http://ecommerce.cbmp.com.br", IsNullable = false)]
    public partial class RequisicaoCaptura : Requisicao
    {

        private int valorField;

        private bool valorFieldSpecified;

        private string anexoField;

        private int taxaembarqueField;


        public int valor
        {
            get
            {
                return this.valorField;
            }
            set
            {
                this.valorField = value;
            }
        }


        [XmlIgnoreAttribute()]
        public bool valorSpecified
        {
            get
            {
                return this.valorFieldSpecified;
            }
            set
            {
                this.valorFieldSpecified = value;
            }
        }


        public string anexo
        {
            get
            {
                return this.anexoField;
            }
            set
            {
                this.anexoField = value;
            }
        }


        public int taxaembarque
        {
            get
            {
                return this.taxaembarqueField;
            }
            set
            {
                this.taxaembarqueField = value;
            }
        }
    }



    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "http://ecommerce.cbmp.com.br")]
    [XmlRootAttribute("requisicao-consulta", Namespace = "http://ecommerce.cbmp.com.br", IsNullable = false)]
    public partial class RequisicaoConsulta : Requisicao
    {
    }



    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "http://ecommerce.cbmp.com.br")]
    [XmlRootAttribute("requisicao-token", Namespace = "http://ecommerce.cbmp.com.br", IsNullable = false)]
    public partial class RequisicaoToken : Requisicao
    {
        private DadosPortador dadosPortadorField;

        [XmlElementAttribute("dados-portador")]
        public DadosPortador dadosPortador
        {
            get
            {
                return this.dadosPortadorField;
            }
            set
            {
                this.dadosPortadorField = value;
            }
        }
    }



    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "http://ecommerce.cbmp.com.br")]
    [XmlRootAttribute("requisicao-consulta-chsec", Namespace = "http://ecommerce.cbmp.com.br", IsNullable = false)]
    public partial class RequisicaoConsultaChSec : Mensagem
    {

        private string numeropedidoField;

        private DadosEc dadosecField;


        [XmlElementAttribute("numero-pedido")]
        public string numeropedido
        {
            get
            {
                return this.numeropedidoField;
            }
            set
            {
                this.numeropedidoField = value;
            }
        }


        [XmlElementAttribute("dados-ec")]
        public DadosEc dadosec
        {
            get
            {
                return this.dadosecField;
            }
            set
            {
                this.dadosecField = value;
            }
        }
    }



    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "http://ecommerce.cbmp.com.br")]
    [XmlRootAttribute("transacao", Namespace = "http://ecommerce.cbmp.com.br", IsNullable = false)]
    public partial class RetornoTransacao : Mensagem
    {
        [XmlElementAttribute("tid")]
        public string Tid { get; set; }

        [XmlElementAttribute("pan")]
        public string Pan { get; set; }

        [XmlElementAttribute("dados-pedido")]
        public DadosPedido DadosPedido { get; set; }

        [XmlElementAttribute("forma-pagamento")]
        public FormaPagamento FormaPagamento { get; set; }

        [XmlElementAttribute("status")]
        public Status Status { get; set; }

        [XmlElementAttribute("autenticacao")]
        public ProcessamentoAutenticacao Autenticacao { get; set; }

        [XmlElementAttribute("autorizacao")]
        public ProcessamentoAutorizacao Autorizacao { get; set; }

        [XmlElementAttribute("captura")]
        public Processamento Captura { get; set; }

        [XmlElementAttribute("cancelamento")]
        public Processamento Cancelamento { get; set; }

        [XmlElementAttribute("url-autenticacao")]
        public string UrlAutenticacao { get; set; }

        [XmlElementAttribute("token")]
        public Token Token { get; set; }
    }



    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "http://ecommerce.cbmp.com.br")]
    [XmlRootAttribute("erro", Namespace = "http://ecommerce.cbmp.com.br", IsNullable = false)]
    public partial class RetornoErro : Mensagem
    {

        private string codigoField;

        private string mensagemField;


        public string codigo
        {
            get
            {
                return this.codigoField;
            }
            set
            {
                this.codigoField = value;
            }
        }


        public string mensagem
        {
            get
            {
                return this.mensagemField;
            }
            set
            {
                this.mensagemField = value;
            }
        }
    }



    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "http://ecommerce.cbmp.com.br")]
    [XmlRootAttribute("retorno-token", Namespace = "http://ecommerce.cbmp.com.br", IsNullable = false)]
    public partial class RetornoToken : Mensagem
    {
        private Token tokenField;

        public Token token
        {
            get
            {
                return this.tokenField;
            }
            set
            {
                this.tokenField = value;
            }
        }
    }



    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "http://ecommerce.cbmp.com.br")]
    public partial class Token
    {

        private DadosToken dadostokenField;


        [XmlElementAttribute("dados-token")]
        public DadosToken dadostoken
        {
            get
            {
                return this.dadostokenField;
            }
            set
            {
                this.dadostokenField = value;
            }
        }
    }



    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "http://ecommerce.cbmp.com.br")]
    public partial class DadosToken
    {
        private string codigotokenField;

        private TokenStatus statusField;

        private string numerocartaotruncadoField;


        [XmlElementAttribute("codigo-token")]
        public string codigotoken
        {
            get
            {
                return this.codigotokenField;
            }
            set
            {
                this.codigotokenField = value;
            }
        }


        public TokenStatus status
        {
            get
            {
                return this.statusField;
            }
            set
            {
                this.statusField = value;
            }
        }


        [XmlElementAttribute("numero-cartao-truncado")]
        public string numerocartaotruncado
        {
            get
            {
                return this.numerocartaotruncadoField;
            }
            set
            {
                this.numerocartaotruncadoField = value;
            }
        }
    }



    [SerializableAttribute()]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "http://ecommerce.cbmp.com.br")]
    public enum TokenStatus
    {
        [XmlEnumAttribute("0")]
        Bloqueado,

        [XmlEnumAttribute("1")]
        Desbloqueado,
    }



    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "http://ecommerce.cbmp.com.br")]
    [XmlRootAttribute("requisicao-tid", Namespace = "http://ecommerce.cbmp.com.br", IsNullable = false)]
    public partial class RequisicaoTid : Mensagem
    {

        private DadosEc dadosecField;

        private FormaPagamento formapagamentoField;


        [XmlElementAttribute("dados-ec")]
        public DadosEc dadosec
        {
            get
            {
                return this.dadosecField;
            }
            set
            {
                this.dadosecField = value;
            }
        }


        [XmlElementAttribute("forma-pagamento")]
        public FormaPagamento formapagamento
        {
            get
            {
                return this.formapagamentoField;
            }
            set
            {
                this.formapagamentoField = value;
            }
        }
    }



    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "http://ecommerce.cbmp.com.br")]
    [XmlRootAttribute("retorno-tid", Namespace = "http://ecommerce.cbmp.com.br", IsNullable = false)]
    public partial class RetornoTid : Mensagem
    {

        private string tidField;


        public string tid
        {
            get
            {
                return this.tidField;
            }
            set
            {
                this.tidField = value;
            }
        }
    }



    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "http://ecommerce.cbmp.com.br")]
    [XmlRootAttribute("mensagem-info", Namespace = "http://ecommerce.cbmp.com.br", IsNullable = false)]
    public partial class RequisicaoMensagemInfo
    {

        private string codigoField;

        private string mensagemField;


        public string codigo
        {
            get
            {
                return this.codigoField;
            }
            set
            {
                this.codigoField = value;
            }
        }


        public string mensagem
        {
            get
            {
                return this.mensagemField;
            }
            set
            {
                this.mensagemField = value;
            }
        }
    }



    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "http://ecommerce.cbmp.com.br")]
    [XmlRootAttribute("requisicao-nova-transacao-celular", Namespace = "http://ecommerce.cbmp.com.br", IsNullable = false)]
    public partial class RequisicaoNovaTransacaoCelular : Mensagem
    {

        private DadosEcAutenticacao dadosecField;

        private DadosCelular dadosportadorField;

        private DadosPedido dadospedidoField;

        private FormaPagamentoCelular formapagamentoField;

        private string urlretornoField;

        private bool capturarField;

        private string campolivreField;

        private bool gerartokenField;

        private bool gerartokenFieldSpecified;

        private string avsField;


        [XmlElementAttribute("dados-ec")]
        public DadosEcAutenticacao dadosec
        {
            get
            {
                return this.dadosecField;
            }
            set
            {
                this.dadosecField = value;
            }
        }


        [XmlElementAttribute("dados-portador")]
        public DadosCelular dadosportador
        {
            get
            {
                return this.dadosportadorField;
            }
            set
            {
                this.dadosportadorField = value;
            }
        }


        [XmlElementAttribute("dados-pedido")]
        public DadosPedido dadospedido
        {
            get
            {
                return this.dadospedidoField;
            }
            set
            {
                this.dadospedidoField = value;
            }
        }


        [XmlElementAttribute("forma-pagamento")]
        public FormaPagamentoCelular formapagamento
        {
            get
            {
                return this.formapagamentoField;
            }
            set
            {
                this.formapagamentoField = value;
            }
        }


        [XmlElementAttribute("url-retorno")]
        public string urlretorno
        {
            get
            {
                return this.urlretornoField;
            }
            set
            {
                this.urlretornoField = value;
            }
        }


        public bool capturar
        {
            get
            {
                return this.capturarField;
            }
            set
            {
                this.capturarField = value;
            }
        }


        [XmlElementAttribute("campo-livre")]
        public string campolivre
        {
            get
            {
                return this.campolivreField;
            }
            set
            {
                this.campolivreField = value;
            }
        }


        [XmlElementAttribute("gerar-token")]
        public bool gerartoken
        {
            get
            {
                return this.gerartokenField;
            }
            set
            {
                this.gerartokenField = value;
            }
        }


        [XmlIgnoreAttribute()]
        public bool gerartokenSpecified
        {
            get
            {
                return this.gerartokenFieldSpecified;
            }
            set
            {
                this.gerartokenFieldSpecified = value;
            }
        }


        public string avs
        {
            get
            {
                return this.avsField;
            }
            set
            {
                this.avsField = value;
            }
        }
    }

    public partial class Retorno
    {
        public Retorno() { }

        public Retorno(string xml)
        {
            if (!string.IsNullOrWhiteSpace(xml))
            {
                RawXml = xml;

                if (!string.IsNullOrEmpty(xml))
                {
                    var encoding = Encoding.GetEncoding("ISO-8859-1");

                    if (xml.Contains("</transacao>"))
                    {
                        Transacao = xml.ToType<RetornoTransacao>(encoding);
                    }
                    else if (xml.Contains("</erro>"))
                    {
                        Erro = xml.ToType<RetornoErro>(encoding);
                    }
                    else if (xml.Contains("</retorno-token>"))
                    {
                        Token = xml.ToType<RetornoToken>(encoding);
                    }
                }
            }
        }

        public RetornoTransacao Transacao { get; set; }

        public RetornoErro Erro { get; set; }

        public RetornoToken Token { get; set; }

        public string RawXml { get; set; }

        public bool IsTransacao { get { return Transacao != null; } }

        public bool IsErro { get { return Erro != null; } }

        public bool IsToken { get { return Token != null; } }
    }
}
