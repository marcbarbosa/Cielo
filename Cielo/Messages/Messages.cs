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
    [XmlRootAttribute("requisicao-transacao", Namespace = "http://ecommerce.cbmp.com.br", IsNullable = false)]
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
        AutorizadaOuPendenteDeCaptura = 4,

        [XmlEnumAttribute("5")]
        NaoAutorizada = 5,

        [XmlEnumAttribute("6")]
        Capturada = 6,

        [XmlEnumAttribute("8")]
        NaoCapturada = 8,

        [XmlEnumAttribute("9")]
        Cancelada = 9,

        [XmlEnumAttribute("10")]
        EmAutenticacao = 10,
    }
    
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "http://ecommerce.cbmp.com.br")]
    public partial class ProcessamentoAutorizacao : Processamento
    {

        private string lrField;

        private string arpField;

        
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
    }

    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "http://ecommerce.cbmp.com.br")]
    public partial class ProcessamentoAutenticacao : Processamento
    {
        private int eciField;

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
    }

    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "http://ecommerce.cbmp.com.br")]
    public partial class FormaPagamento
    {

        private Bandeira bandeiraField;

        private FormaPagamentoProduto produtoField;

        private int parcelasField;

        
        public Bandeira bandeira
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

        [XmlEnumAttribute("3")]
        ParceladoAdministradora = 3,

        [XmlEnumAttribute("A")]
        Debito = 4
    }

    [SerializableAttribute()]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "http://ecommerce.cbmp.com.br")]
    public enum Bandeira
    {

        [XmlEnumAttribute("visa")]
        Visa = 1,

        [XmlEnumAttribute("mastercard")]
        Mastercard = 2,

        [XmlEnumAttribute("elo")]
        Elo = 3,
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

        private System.DateTime datahoraField;

        private string descricaoField;

        private Idioma idiomaField;

        
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
        Item0,

        
        [XmlEnumAttribute("1")]
        Item1,

        
        [XmlEnumAttribute("2")]
        Item2,

        
        [XmlEnumAttribute("9")]
        Item9,
    }

    [XmlIncludeAttribute(typeof(RetornoTid))]
    [XmlIncludeAttribute(typeof(RequisicaoTid))]
    [XmlIncludeAttribute(typeof(RetornoTransacao))]
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

        [XmlIgnoreAttribute()]
        public string rawXml { get; set; }
    }

    [SerializableAttribute()]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "http://ecommerce.cbmp.com.br")]
    public enum MensagemVersao
    {

        
        [XmlEnumAttribute("1.0.0")]
        v100,

        
        [XmlEnumAttribute("1.1.0")]
        v110,
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
        NaoAutorizar = 1,

        [XmlEnumAttribute("1")]
        AutorizarSomenteSeAutenticada = 2,

        [XmlEnumAttribute("2")]
        AutorizarAutenticadaENaoAutenticada = 3,

        [XmlEnumAttribute("3")]
        AutorizarSemPassarPorAutenticacao = 4,
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
