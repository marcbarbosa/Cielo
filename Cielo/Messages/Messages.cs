using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;
using Cielo.Helpers;


namespace Cielo.Messages
{
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "http://ecommerce.cbmp.com.br")]
    [XmlRootAttribute("requisicao-autenticacao", Namespace = "http://ecommerce.cbmp.com.br", IsNullable = false)]
    public partial class RequisicaoNovaTransacao : Mensagem
    {

        private DadosEcAutenticacao dadosecField;

        private DadosCartao dadosportadorField;

        private DadosPedido dadospedidoField;

        private FormaPagamento formapagamentoField;

        private string urlretornoField;

        private RequisicaoNovaTransacaoAutorizar autorizarField;

        private bool capturarField;

        private string campolivreField;

        private string binField;


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
        public DadosCartao dadosportador
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


        public RequisicaoNovaTransacaoAutorizar autorizar
        {
            get
            {
                return this.autorizarField;
            }
            set
            {
                this.autorizarField = value;
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


        public string bin
        {
            get
            {
                return this.binField;
            }
            set
            {
                this.binField = value;
            }
        }
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

        private string numeroField;

        private string chaveField;


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


        public string chave
        {
            get
            {
                return this.chaveField;
            }
            set
            {
                this.chaveField = value;
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

        private string dddField;

        private string numeroField;


        public string ddd
        {
            get
            {
                return this.dddField;
            }
            set
            {
                this.dddField = value;
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
    }


    [XmlIncludeAttribute(typeof(ProcessamentoAutorizacao))]
    [XmlIncludeAttribute(typeof(ProcessamentoAutenticacao))]

    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "http://ecommerce.cbmp.com.br")]
    public partial class Processamento
    {

        private Status codigoField;

        private string mensagemField;

        private System.DateTime datahoraField;

        private string valorField;


        public Status codigo
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


        [XmlElementAttribute("data-hora")]
        public System.DateTime datahora
        {
            get
            {
                return this.datahoraField;
            }
            set
            {
                this.datahoraField = value;
            }
        }


        public string valor
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

        private FormaPagamentoBandeira bandeiraField;

        private bool bandeiraFieldSpecified;

        private FormaPagamentoProduto produtoField;

        private int parcelasField;


        public FormaPagamentoBandeira bandeira
        {
            get
            {
                return this.bandeiraField;
            }
            set
            {
                this.bandeiraField = value;
            }
        }


        [XmlIgnoreAttribute()]
        public bool bandeiraSpecified
        {
            get
            {
                return this.bandeiraFieldSpecified;
            }
            set
            {
                this.bandeiraFieldSpecified = value;
            }
        }


        public FormaPagamentoProduto produto
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
        public DadosPedido()
        {
        }

        public DadosPedido(string numero, decimal valor, string descricao)
        {
            numeroField = numero;
            valorField = valor.ToFormatoCielo();
            moedaField = Moeda.Real;
            datahoraField = DateTime.Now;
            descricaoField = descricao;
            idiomaField = Idioma.PT;
        }

        private string numeroField;

        private int valorField;

        private Moeda moedaField;

        private DateTime datahoraField;

        private string descricaoField;

        private Idioma idiomaField;

        private bool idiomaFieldSpecified;


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


        public Moeda moeda
        {
            get
            {
                return this.moedaField;
            }
            set
            {
                this.moedaField = value;
            }
        }


        [XmlElementAttribute("data-hora")]
        public DateTime datahora
        {
            get
            {
                return this.datahoraField;
            }
            set
            {
                this.datahoraField = value;
            }
        }


        public string descricao
        {
            get
            {
                return this.descricaoField;
            }
            set
            {
                this.descricaoField = value;
            }
        }


        public Idioma idioma
        {
            get
            {
                return this.idiomaField;
            }
            set
            {
                this.idiomaField = value;
            }
        }


        [XmlIgnoreAttribute()]
        public bool idiomaSpecified
        {
            get
            {
                return this.idiomaFieldSpecified;
            }
            set
            {
                this.idiomaFieldSpecified = value;
            }
        }
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
    public partial class DadosCartao
    {

        private string numeroField;

        private string validadeField;

        private DadosCartaoIndicador indicadorField;

        private string codigosegurancaField;

        private string nomeportadorField;


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


        public string validade
        {
            get
            {
                return this.validadeField;
            }
            set
            {
                this.validadeField = value;
            }
        }


        public DadosCartaoIndicador indicador
        {
            get
            {
                return this.indicadorField;
            }
            set
            {
                this.indicadorField = value;
            }
        }


        [XmlElementAttribute("codigo-seguranca")]
        public string codigoseguranca
        {
            get
            {
                return this.codigosegurancaField;
            }
            set
            {
                this.codigosegurancaField = value;
            }
        }


        [XmlElementAttribute("nome-portador")]
        public string nomeportador
        {
            get
            {
                return this.nomeportadorField;
            }
            set
            {
                this.nomeportadorField = value;
            }
        }
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
    [XmlIncludeAttribute(typeof(RequisicaoNovaTransacao))]

    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "http://ecommerce.cbmp.com.br")]
    public partial class Mensagem
    {

        private string idField;

        private MensagemVersao versaoField;


        [XmlAttributeAttribute()]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }


        [XmlAttributeAttribute()]
        public MensagemVersao versao
        {
            get
            {
                return this.versaoField;
            }
            set
            {
                this.versaoField = value;
            }
        }
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

        private string tidField;

        private DadosEc dadosecField;


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
    [XmlTypeAttribute(AnonymousType = true, Namespace = "http://ecommerce.cbmp.com.br")]
    public enum RequisicaoNovaTransacaoAutorizar
    {


        [XmlEnumAttribute("0")]
        NaoAutorizar = 0,


        [XmlEnumAttribute("1")]
        AutorizarSomenteSeAutenticada = 1,


        [XmlEnumAttribute("2")]
        AutorizarAutenticadaENaoAutenticada = 2,


        [XmlEnumAttribute("3")]
        AutorizarSemPassarPorAutenticacao = 3,
    }



    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "http://ecommerce.cbmp.com.br")]
    [XmlRootAttribute("requisicao-autorizacao-portador", Namespace = "http://ecommerce.cbmp.com.br", IsNullable = false)]
    public partial class RequisicaoAutorizacaoPortador : Requisicao
    {

        private DadosCartao dadoscartaoField;

        private DadosPedido dadospedidoField;

        private FormaPagamento formapagamentoField;

        private bool capturarautomaticamenteField;

        private string campolivreField;


        [XmlElementAttribute("dados-cartao")]
        public DadosCartao dadoscartao
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
    [XmlRootAttribute("requisicao-captura", Namespace = "http://ecommerce.cbmp.com.br", IsNullable = false)]
    public partial class RequisicaoCaptura : Requisicao
    {

        private int valorField;

        private bool valorFieldSpecified;

        private string anexoField;


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

        private string tidField;

        private string panField;

        private DadosPedido dadospedidoField;

        private FormaPagamento formapagamentoField;

        private Status statusField;

        private ProcessamentoAutenticacao autenticacaoField;

        private ProcessamentoAutorizacao autorizacaoField;

        private Processamento capturaField;

        private Processamento cancelamentoField;

        private string urlautenticacaoField;


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


        public string pan
        {
            get
            {
                return this.panField;
            }
            set
            {
                this.panField = value;
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


        public Status status
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


        public ProcessamentoAutenticacao autenticacao
        {
            get
            {
                return this.autenticacaoField;
            }
            set
            {
                this.autenticacaoField = value;
            }
        }


        public ProcessamentoAutorizacao autorizacao
        {
            get
            {
                return this.autorizacaoField;
            }
            set
            {
                this.autorizacaoField = value;
            }
        }


        public Processamento captura
        {
            get
            {
                return this.capturaField;
            }
            set
            {
                this.capturaField = value;
            }
        }


        public Processamento cancelamento
        {
            get
            {
                return this.cancelamentoField;
            }
            set
            {
                this.cancelamentoField = value;
            }
        }


        [XmlElementAttribute("url-autenticacao")]
        public string urlautenticacao
        {
            get
            {
                return this.urlautenticacaoField;
            }
            set
            {
                this.urlautenticacaoField = value;
            }
        }

        [XmlIgnoreAttribute()]
        public string rawXml { get; set; }

    }



    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "http://ecommerce.cbmp.com.br")]
    [XmlRootAttribute("erro", Namespace = "http://ecommerce.cbmp.com.br", IsNullable = false)]
    public partial class RetornoErro
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

        [XmlIgnoreAttribute()]
        public string rawXml { get; set; }

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
        public RetornoTransacao Transacao { get; set; }

        public RetornoErro Erro { get; set; }

        public bool IsTransacao()
        {
            return Transacao != null;
        }

        public bool IsErro()
        {
            return Erro != null;
        }
    }
}
